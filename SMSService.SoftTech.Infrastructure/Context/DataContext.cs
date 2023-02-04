using Microsoft.EntityFrameworkCore;
using SMSService.SoftTech.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSService.SoftTech.Infrastructure.Context
{
    internal class DataContext:DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<SmsMessage> SmsMessages { get; set; } = default!;
        public virtual DbSet<SmsState> SmsStates { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SmsMessage>(smsMessage =>
            {
                smsMessage.HasKey(m => m.Id);
                smsMessage.Property(m=>m.MessageText).IsRequired().HasMaxLength(2048);
                
            });

            modelBuilder.Entity<SmsState>(smsState =>
            {
                smsState.HasKey(m => m.Id);
                smsState.HasOne(h => h.SmsMessage).WithMany(m => m.StateHistory)
                    .HasForeignKey(h => h.SmsMessageId);
            });
        }
    }
}
