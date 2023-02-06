using SMSService.SoftTech.Data.Database;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SMSService.SoftTech.Infrastructure.Repositories.Interfaces
{
    public interface ISmsMessageRepository
    {

        /// <summary>
        /// Add new message to database
        /// </summary>
        /// <param name="message">New message</param>
        Task AddMessage(SmsMessage message, CancellationToken cancellation);
        /// <summary>
        /// Select messages with states sorted by SetDate
        /// </summary>
        IAsyncEnumerable<SmsMessage> SelectMessageWithStates(DateTime utcTime);
        /// <summary>
        /// Get message with state history by <paramref name="messageId"/>
        /// </summary>
        Task<SmsMessage> SelectOneMessage(long messageId);

    }
}
