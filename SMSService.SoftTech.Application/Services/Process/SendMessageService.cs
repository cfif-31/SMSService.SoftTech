using SMSService.SoftTech.Application.DTOs;
using SMSService.SoftTech.Application.Services.Backgrounds;
using SMSService.SoftTech.Application.Services.DataServices.Interfaces;
using SMSService.SoftTech.Application.Services.ProcessServices.Interfaces;
using SMSService.SoftTech.Data.Enums;
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

        public async Task<SmsMessageDTO> SendMessage(SmsMessageDTO smsMessage)
        {
            //Add sended state to sms
            var state = new SmsStateDTO(0, EMessageState.Submitted, DateTime.UtcNow);
            //Add sms to database
            var addedMessage = await _smsMessageService.AddMessage(smsMessage, new SmsStateDTO[] { state });
            //Add message to queue
            _updateQueueService.MessageIdsTasks.Enqueue(addedMessage.Id);
            return addedMessage;
        }
    }
}
