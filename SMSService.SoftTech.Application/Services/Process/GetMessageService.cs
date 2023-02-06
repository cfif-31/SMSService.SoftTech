using SMSService.SoftTech.Application.DTOs;
using SMSService.SoftTech.Application.Services.DataServices;
using SMSService.SoftTech.Application.Services.DataServices.Interfaces;
using SMSService.SoftTech.Application.Services.Process.Interfaces;
using SMSService.SoftTech.Data.Database;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace SMSService.SoftTech.Application.Services.Process
{
    internal class GetMessageService : IGetMessageService
    {
        private readonly ISmsMessageService _messageService;
        public GetMessageService(ISmsMessageService messageService)
        {
            _messageService = messageService;
        }

        public Task<SmsMessageDTO> GetOneMessage(long messageId)
        {
            return _messageService.SelectOneMessage(messageId);
        }

        public IAsyncEnumerable<SmsMessageDTO> SelectLastStatesWithMessages(DateTime utcTime)
        {
            return _messageService.SelectLastStatesWithMessages(utcTime);
        }
    }
}
