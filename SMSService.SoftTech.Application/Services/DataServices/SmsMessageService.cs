using AutoMapper;
using SMSService.SoftTech.Application.DTOs;
using SMSService.SoftTech.Application.Services.DataServices.Interfaces;
using SMSService.SoftTech.Data.Database;
using SMSService.SoftTech.Infrastructure.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace SMSService.SoftTech.Application.Services.DataServices
{
    internal class SmsMessageService : ISmsMessageService
    {
        private readonly IMapper _mapper;
        private readonly ISmsMessageRepository _messageRepository;
        public SmsMessageService(IMapper mapper, ISmsMessageRepository messageRepository)
        {
            _mapper = mapper;
            _messageRepository = messageRepository;
        }

        public Task AddMessage(SmsMessageDTO messageDTO)
        {
            SmsMessage message = _mapper.Map<SmsMessage>(messageDTO);
            return _messageRepository.AddMessage(message);
        }

        public async Task<SmsMessageDTO> SelectMessage(long messageId)
        {
            SmsMessage message = await _messageRepository.SelectMessage(messageId);
            return _mapper.Map<SmsMessageDTO>(message);
        }
    }
}
