using Microsoft.EntityFrameworkCore;
using SMSService.SoftTech.Data.Database;
using SMSService.SoftTech.Infrastructure.Context;
using SMSService.SoftTech.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IAsyncEnumerable<SmsMessage> SelectMessageWithStates(DateTime utcTime)
        {
            return _context.SmsMessages.Include(m => m.StateHistory.OrderByDescending(s => s.SetDate))
                    .Where(m=>m.StateHistory.FirstOrDefault().SetDate >= utcTime)
                    .AsAsyncEnumerable();
        }

        public Task<SmsMessage> SelectOneMessage(long messageId)
        {
            return _context.SmsMessages.Include(m => m.StateHistory.OrderByDescending(s => s.SetDate))
                    .Where(m=>m.Id == messageId)
                    .FirstOrDefaultAsync();
        }
    }
}
