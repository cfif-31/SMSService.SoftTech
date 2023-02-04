using AutoMapper;
using SMSService.SoftTech.Application.DTOs;
using SMSService.SoftTech.Application.Services.DataServices.Interfaces;
using SMSService.SoftTech.Data.Database;
using SMSService.SoftTech.Infrastructure.Repositories.Interfaces;
using System.Collections.Generic;
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

        public Task AddMessageState(SmsStateDTO smsState)
        {
            SmsState state = _mapper.Map<SmsState>(smsState);
            return _stateRepository.AddMessageState(state);
        }

        public async IAsyncEnumerable<SmsStateDTO> SelectAllStatesWithMessages()
        {
            await foreach (SmsState data in _stateRepository.SelectAllStatesWithMessages())
                yield return _mapper.Map<SmsStateDTO>(data);
        }
    }
}
