using SMSService.SoftTech.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSService.SoftTech.Application.Services.ProcessServices.Interfaces
{
    public interface ISendMessageService
    {
        /// <summary>
        /// Send message ressived from user
        /// </summary>
        /// <param name="smsMessage">message</param>
        /// <returns></returns>
        Task SendMessage(SmsMessageDTO smsMessage);
    }
}
