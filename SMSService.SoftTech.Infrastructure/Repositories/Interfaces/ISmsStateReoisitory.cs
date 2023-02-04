using SMSService.SoftTech.Data.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMSService.SoftTech.Infrastructure.Repositories.Interfaces
{
    public interface ISmsStateReoisitory
    {
        /// <summary>
        /// Get all state with messages
        /// </summary>
        IAsyncEnumerable<SmsState> SelectAllStatesWithMessages();
        /// <summary>
        /// Set new message state
        /// </summary>
        /// <param name="smsState"><new message state</param>
        Task AddMessageState(SmsState smsState);
    }
}
