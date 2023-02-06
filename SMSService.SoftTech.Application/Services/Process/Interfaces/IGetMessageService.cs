using SMSService.SoftTech.Application.DTOs;
using SMSService.SoftTech.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SMSService.SoftTech.Application.Services.Process.Interfaces
{
    public interface IGetMessageService
    {
        /// <summary>
        /// Get all messages with last state
        /// </summary>
        IAsyncEnumerable<SmsMessageDTO> SelectLastStatesWithMessages(DateTime utcTime = default);
        /// <summary>
        /// Get message with history by <paramref name="messageId"/>
        /// </summary>
        Task<SmsMessageDTO> GetOneMessage(long messageId);

    }
}
