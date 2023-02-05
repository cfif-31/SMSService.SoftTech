using Microsoft.EntityFrameworkCore;
using SMSService.SoftTech.Data.Database;
using SMSService.SoftTech.Infrastructure.Context;
using SMSService.SoftTech.Infrastructure.Repositories.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SMSService.SoftTech.Infrastructure.Repositories
{
    internal class SmsMessageRepository : ISmsMessageRepository
    {
        private readonly DataContext _context;
        public SmsMessageRepository(DataContext context)
        {
            _context = context;
        }
        public Task AddMessage(SmsMessage message, CancellationToken cancellation)
        {
            _context.SmsMessages.Add(message);
            return _context.SaveChangesAsync(cancellation);
        }
        public Task<SmsMessage> SelectMessage(long messageId, CancellationToken cancellation)
        {
            return _context.SmsMessages.Include(m => m.StateHistory)
                .FirstOrDefaultAsync(m => m.Id == messageId, cancellation);
        }
    }
}
