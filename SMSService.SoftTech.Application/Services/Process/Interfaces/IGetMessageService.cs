using SMSService.SoftTech.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSService.SoftTech.Application.Services.Process.Interfaces
{
    internal interface IGetMessageService
    {
        /// <summary>
        /// Get all messages with last state
        /// </summary>
        IAsyncEnumerable<SmsStateDTO> GetAllMessages();
        /// <summary>
        /// Get message by id with all states
        /// </summary>
        /// <param name="id">Message id</param>
        /// <returns></returns>
        Task<SmsMessageDTO> GetMessage(long id);
    }
}
