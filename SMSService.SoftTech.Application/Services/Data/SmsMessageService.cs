using AutoMapper;
using SMSService.SoftTech.Application.DTOs;
using SMSService.SoftTech.Application.Services.DataServices.Interfaces;
using SMSService.SoftTech.Data.Database;
using SMSService.SoftTech.Infrastructure.Repositories.Interfaces;
using System;
using System.Threading;
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

        public async Task AddMessage(SmsMessageDTO messageDTO, CancellationToken cancellation)
        {
            SmsMessage message = _mapper.Map<SmsMessage>(messageDTO);
            await _messageRepository.AddMessage(message, cancellation);
            messageDTO.Id = message.Id;
        }

        public async Task<SmsMessageDTO> SelectMessage(long messageId, CancellationToken cancellation)
        {
            SmsMessage message = await _messageRepository.SelectMessage(messageId, cancellation);
            return _mapper.Map<SmsMessageDTO>(message);
        }
    }
}
