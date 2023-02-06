using SMSService.SoftTech.Data.Enums;
using System;
using System.Collections.Generic;

namespace SMSService.SoftTech.Application.DTOs
{
    public record SmsStateDTO(
        long SmsMessageId,
        EMessageState State,
        DateTime SetDate,
        long Id = 0
    );
}
