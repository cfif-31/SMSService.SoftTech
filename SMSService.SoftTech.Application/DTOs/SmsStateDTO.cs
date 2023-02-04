using SMSService.SoftTech.Data.Enums;
using System;
using System.Collections.Generic;

namespace SMSService.SoftTech.Application.DTOs
{
    public record SmsStateDTO(
        long Id,
        long SmsMessageId,
        EMessageState State,
        DateTime SetDate,
        List<SmsMessageDTO> SmsMessages = null
    );
}
