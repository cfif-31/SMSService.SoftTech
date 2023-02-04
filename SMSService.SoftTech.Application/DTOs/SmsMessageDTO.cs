using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSService.SoftTech.Application.DTOs
{
    public record SmsMessageDTO(
        long Id,
        string MessageText,
        DateTime SendTime,
        string Phone,
        string SenderName
    );
}
