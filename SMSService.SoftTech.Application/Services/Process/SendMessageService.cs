using SMSService.SoftTech.Application.DTOs;
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
        public SendMessageService(ISmsMessageService smsMessageService)
        {
            _smsMessageService = smsMessageService;
        }

        public async Task SendMessage(SmsMessageDTO smsMessage)
        {
            await _smsMessageService.AddMessage(smsMessage);
            
        }
    }
}
