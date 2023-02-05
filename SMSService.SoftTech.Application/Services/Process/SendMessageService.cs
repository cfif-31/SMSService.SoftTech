using SMSService.SoftTech.Application.DTOs;
using SMSService.SoftTech.Application.Services.Backgrounds;
using SMSService.SoftTech.Application.Services.DataServices.Interfaces;
using SMSService.SoftTech.Application.Services.ProcessServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSService.SoftTech.Application.Services.ProcessServices
{
    internal class SendMessageService : ISendMessageService
    {
        private readonly ISmsMessageService _smsMessageService;
        private readonly ISmsStateService _smsStateService;
        private readonly UpdateQueueService _updateQueueService;
        public SendMessageService(ISmsMessageService smsMessageService, 
            ISmsStateService smsStateService, UpdateQueueService updateQueue)
        {
            _smsMessageService = smsMessageService;
            _smsStateService = smsStateService;
            _updateQueueService = updateQueue;
        }

        public async Task SendMessage(SmsMessageDTO smsMessage)
        {
            //Add sms to database
            await _smsMessageService.AddMessage(smsMessage);
            //Add sended state to database
            SmsStateDTO smsState = new(smsMessage.Id, Data.Enums.EMessageState.Submited, DateTime.UtcNow);
            await _smsStateService.AddMessageState(smsState);
            //Add message to queue
            _updateQueueService.MessageIdsTasks.Enqueue(smsMessage.Id);
        }
    }
}
