using Microsoft.EntityFrameworkCore;
using SMSService.SoftTech.Data.Database;
using SMSService.SoftTech.Infrastructure.Context;
using SMSService.SoftTech.Infrastructure.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSService.SoftTech.Infrastructure.Repositories
{
    internal class SmsStateReoisitory : ISmsStateReoisitory
    {
        DataContext _context;
        public SmsStateReoisitory(DataContext context)
        {
            _context = context;
        }

        public Task AddMessageState(SmsState smsState)
        {
            _context.SmsStates.Add(smsState);
            return _context.SaveChangesAsync();
        }

        public IAsyncEnumerable<SmsState> SelectAllStatesWithMessages()
        {
            return _context.SmsStates.Include(s => s.SmsMessage).GroupBy(s => s.SmsMessageId)
                .Select(gs => gs.OrderByDescending(gi => gi.SetDate).FirstOrDefault())
                .AsAsyncEnumerable();
        }
    }
}
