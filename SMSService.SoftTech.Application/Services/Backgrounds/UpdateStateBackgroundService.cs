using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SMSService.SoftTech.Application.DTOs;
using SMSService.SoftTech.Application.Services.DataServices.Interfaces;
using SMSService.SoftTech.Data.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SMSService.SoftTech.Application.Services.Backgrounds
{
    internal class UpdateStateBackgroundService : BackgroundService
    {
        private readonly Random _random;
        private readonly IServiceProvider _serviceProvider;
        private readonly UpdateQueueService _updateQueue;
        private readonly ILogger _logger;

        private const int DelayTimeout = 1000;

        public UpdateStateBackgroundService(IServiceProvider serviceProvider,
            UpdateQueueService updateQueue, ILogger<UpdateStateBackgroundService> logger)
        {
            _random = new Random();
            _serviceProvider = serviceProvider;
            _updateQueue = updateQueue;
            _logger = logger;
        }

        /// <summary>
        /// Load messages for update state
        /// </summary>
        /// <param name="cancellationToken">cancelation tokken</param>
        /// <returns>Array of message IDs for updating state</returns>
        private async Task LoadMessageTasks(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            ISmsStateService smsState = scope.ServiceProvider.GetService<ISmsStateService>();
            long[] IDs = await smsState.SelectAllMessageIDsByState(EMessageState.Submited, cancellationToken);
            foreach (long id in IDs)
                _updateQueue.MessageIdsTasks.Enqueue(id);
        }

        /// <summary>
        /// Check message delivery state
        /// </summary>
        /// <param name="id">message id</param>
        /// <param name="cancellation">cancellation token</param>
        /// <returns></returns>
        private async Task CheckMessageState(long id, CancellationToken cancellation)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                ISmsStateService smsState = scope.ServiceProvider.GetService<ISmsStateService>();

                //Mock
                EMessageState state = (EMessageState)_random.Next((int)EMessageState.Error, (int)(EMessageState.Delivered + 1));
                //Mock server delay 0.3 to 10 seccond
                await Task.Delay(_random.Next(300, 10000), cancellation);

                await smsState.AddMessageState(new SmsStateDTO(id, state, DateTime.UtcNow), cancellation);
            }
            catch(Exception ex)
            {
                _logger.LogError("Error update state on message with id {id}!", id);
                _logger.LogDebug("Error update message {id}: {message}", id, ex.Message);
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await LoadMessageTasks(stoppingToken);
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_updateQueue.MessageIdsTasks.TryDequeue(out long id))
                    await CheckMessageState(id, stoppingToken);
                else
                    //if queue is empty - service sleep
                    await Task.Delay(DelayTimeout, stoppingToken);
            }
        }
    }
}
