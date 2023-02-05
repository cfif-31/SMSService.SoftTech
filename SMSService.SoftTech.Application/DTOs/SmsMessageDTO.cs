using System;
using System.ComponentModel.DataAnnotations;

namespace SMSService.SoftTech.Application.DTOs
{
    public record SmsMessageDTO(
        [Required, MinLength(5), MaxLength(2048)]
        string MessageText,
        [Required, MinLength(8), MaxLength(20)]
        string Phone,
        [MinLength(3), MaxLength(32)]
        string SenderName,
        DateTime SendTime,
        SmsMessageDTO SmsMessage = null
    )
    {
        public long Id { get; set; }
    }
}
