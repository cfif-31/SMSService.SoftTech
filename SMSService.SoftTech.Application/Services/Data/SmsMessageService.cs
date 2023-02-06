using AutoMapper;
using SMSService.SoftTech.Application.DTOs;
using SMSService.SoftTech.Application.Services.DataServices.Interfaces;
using SMSService.SoftTech.Data.Database;
using SMSService.SoftTech.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public async Task<SmsMessageDTO> AddMessage(SmsMessageDTO messageDTO, SmsStateDTO[] stateDTOs, CancellationToken cancellation)
        {
            SmsMessage message = _mapper.Map<SmsMessage>(messageDTO);
            foreach (SmsStateDTO state in stateDTOs ?? Enumerable.Empty<SmsStateDTO>())
                message.StateHistory.Add(_mapper.Map<SmsState>(state));

            await _messageRepository.AddMessage(message, cancellation);
            return _mapper.Map<SmsMessageDTO>(message);
        }

        public async IAsyncEnumerable<SmsMessageDTO> SelectLastStatesWithMessages(DateTime utcTime,
            [EnumeratorCancellation] CancellationToken cancellation = default)
        {
            await foreach (SmsMessage data in _messageRepository.SelectMessageWithStates(utcTime).WithCancellation(cancellation))
                yield return _mapper.Map<SmsMessageDTO>(data);
        }

        public async Task<SmsMessageDTO> SelectOneMessage(long messageId, CancellationToken cancellation)
        {
            SmsMessage data = await _messageRepository.SelectOneMessage(messageId);
            return _mapper.Map<SmsMessageDTO>(data);
        }
    }
}
