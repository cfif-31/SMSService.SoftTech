using Microsoft.EntityFrameworkCore;
using SMSService.SoftTech.Data.Database;
using SMSService.SoftTech.Data.Enums;
using SMSService.SoftTech.Infrastructure.Context;
using SMSService.SoftTech.Infrastructure.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SMSService.SoftTech.Infrastructure.Repositories
{
    internal class SmsStateReoisitory : ISmsStateReoisitory
    {
        private readonly DataContext _context;
        public SmsStateReoisitory(DataContext context)
        {
            _context = context;
        }

        public Task AddMessageState(SmsState smsState, CancellationToken cancellation)
        {
            _context.SmsStates.Add(smsState);
            return _context.SaveChangesAsync(cancellation);
        }

        public IAsyncEnumerable<SmsState> SelectLastStatesWithMessages()
        {
            return _context.SmsStates.Include(s => s.SmsMessage).GroupBy(s => s.SmsMessageId)
                .Select(gs => gs.OrderByDescending(gi => gi.SetDate).FirstOrDefault())
                .AsAsyncEnumerable();
        }

        public Task<long[]> SelectAllMessageIDsWithState(EMessageState messageState, CancellationToken cancellation)
        {
            return _context.SmsStates.Include(s => s.SmsMessage).GroupBy(s => s.SmsMessageId)
                .Select(gs => gs.OrderByDescending(gi => gi.SetDate).FirstOrDefault())
                .Where(s => s.State == messageState)
                .Select(s => s.SmsMessageId)
                .ToArrayAsync(cancellation);
        }
    }
}
