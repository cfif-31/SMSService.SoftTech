using SMSService.SoftTech.Application.DTOs;
using SMSService.SoftTech.Application.Services.DataServices.Interfaces;
using SMSService.SoftTech.Application.Services.Process.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMSService.SoftTech.Application.Services.Process
{
    internal class GetMessageService : IGetMessageService
    {
        private readonly ISmsMessageService _messageService;
        private readonly ISmsStateService _stateService;
        public GetMessageService(ISmsMessageService messageService, ISmsStateService stateService)
        {
            _messageService = messageService;
            _stateService = stateService;
        }
        public IAsyncEnumerable<SmsStateDTO> GetAllMessages()
        {
            return _stateService.SelectLastStatesWithMessages();
        }

        public Task<SmsMessageDTO> GetMessage(long id)
        {
            return _messageService.SelectMessage(id);
        }
    }
}
