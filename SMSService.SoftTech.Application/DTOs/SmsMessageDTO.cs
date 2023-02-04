using System;
using System.ComponentModel.DataAnnotations;

namespace SMSService.SoftTech.Application.DTOs
{
    public record SmsMessageDTO(
        long Id,
        [Required, MinLength(5), MaxLength(2048)]
        string MessageText,
        DateTime SendTime,
        [Required, MinLength(8), MaxLength(20)]
        string Phone,
        [Required, MinLength(3), MaxLength(32)]
        string SenderName,
        SmsMessageDTO SmsMessage = null
    );
}
