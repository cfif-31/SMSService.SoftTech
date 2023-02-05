using SMSService.SoftTech.Data.Database;
using SMSService.SoftTech.Data.Enums;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SMSService.SoftTech.Infrastructure.Repositories.Interfaces
{
    public interface ISmsStateReoisitory
    {
        /// <summary>
        /// Get all state with messages
        /// </summary>
        IAsyncEnumerable<SmsState> SelectLastStatesWithMessages();
        /// <summary>
        /// Get ids list of messages where messages where last message state equal messageState
        /// </summary>
        /// <param name="messageState">last message state</param>
        /// <returns></returns>
        Task<long[]> SelectAllMessageIDsWithState(EMessageState messageState, CancellationToken cancellation);
        /// <summary>
        /// Set new message state
        /// </summary>
        /// <param name="smsState"><new message state</param>
        Task AddMessageState(SmsState smsState, CancellationToken cancellation);
    }
}
