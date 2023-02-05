using AutoMapper;
using SMSService.SoftTech.Application.DTOs;
using SMSService.SoftTech.Data.Database;

namespace SMSService.SoftTech.Application.Profiles
{
    /// <summary>
    /// AutoMapper profile
    /// </summary>
    internal class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //SmsMessage <=> SmsMessageDTO
            CreateMap<SmsMessage, SmsMessageDTO>();
            CreateMap<SmsMessageDTO, SmsMessage>()
                .ForMember(m=>m.StateHistory, opt=>opt.Ignore())
                .ForMember(m=>m.SendTime, opt=>opt.Ignore());

            //SmsState <=> SmsStateDTO
            CreateMap<SmsState, SmsStateDTO>().ReverseMap();
        }
    }
}
