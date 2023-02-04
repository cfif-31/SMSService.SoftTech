using SMSService.SoftTech.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSService.SoftTech.Application.Services.ProcessServices.Interfaces
{
    internal interface ISendMessageService
    {
        Task SendMessage(SmsMessageDTO smsMessage);
    }
}
