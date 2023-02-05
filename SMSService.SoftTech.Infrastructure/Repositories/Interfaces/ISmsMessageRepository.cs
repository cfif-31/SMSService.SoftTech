using SMSService.SoftTech.Data.Database;
using System.Threading;
using System.Threading.Tasks;

namespace SMSService.SoftTech.Infrastructure.Repositories.Interfaces
{
    public interface ISmsMessageRepository
    {
        /// <summary>
        /// Get message with all history
        /// </summary>
        Task<SmsMessage> SelectMessage(long messageId, CancellationToken cancellation);
        /// <summary>
        /// Add new message to database
        /// </summary>
        /// <param name="message">New message</param>
        Task AddMessage(SmsMessage message, CancellationToken cancellation);
    }
}
