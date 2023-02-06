using SMSService.SoftTech.Application.DTOs;
using SMSService.SoftTech.Data.Database;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SMSService.SoftTech.Application.Services.DataServices.Interfaces
{
    internal interface ISmsMessageService
    {
        /// <summary>
        /// Get all state with messages and map to DTO
        /// </summary>
        IAsyncEnumerable<SmsMessageDTO> SelectLastStatesWithMessages(DateTime utcTime, CancellationToken cancellation = default);
        /// <summary>
        /// Add DTO message to database
        /// </summary>
        /// <param name="message">New message</param>
        Task<SmsMessageDTO> AddMessage(SmsMessageDTO messageDTO, CancellationToken cancellation = default);
        /// <summary>
        /// Get message with state history by <paramref name="messageId"/>
        /// </summary>
        Task<SmsMessageDTO> SelectOneMessage(long messageId, CancellationToken cancellation = default);
    }
}
