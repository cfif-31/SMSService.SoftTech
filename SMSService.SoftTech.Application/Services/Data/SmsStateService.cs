using AutoMapper;
using SMSService.SoftTech.Application.DTOs;
using SMSService.SoftTech.Application.Services.DataServices.Interfaces;
using SMSService.SoftTech.Data.Database;
using SMSService.SoftTech.Data.Enums;
using SMSService.SoftTech.Infrastructure.Repositories.Interfaces;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace SMSService.SoftTech.Application.Services.DataServices
{
    internal class SmsStateService : ISmsStateService
    {
        private readonly IMapper _mapper;
        private readonly ISmsStateReoisitory _stateRepository;
        public SmsStateService(IMapper mapper, ISmsStateReoisitory stateReoisitory)
        {
            _mapper = mapper;
            _stateRepository = stateReoisitory;
        }

        public async Task<SmsStateDTO> AddMessageState(SmsStateDTO smsState, CancellationToken cancellation)
        {
            SmsState state = _mapper.Map<SmsState>(smsState);
            await _stateRepository.AddMessageState(state, cancellation);
            return _mapper.Map<SmsStateDTO>(state);
        }

        public Task<long[]> SelectAllMessageIDsByState(EMessageState messageState, CancellationToken cancellation)
        {
            return _stateRepository.SelectAllMessageIDsWithState(messageState, cancellation);
        }
    }
}
