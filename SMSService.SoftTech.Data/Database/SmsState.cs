using SMSService.SoftTech.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSService.SoftTech.Data.Database
{
    public class SmsState
    {
        public long Id { get; set; }
        public long SmsMessageId { get; set; }
        public EMessageState State { get; set; }
        public DateTime SetDate { get; set; } = DateTime.UtcNow;
        public SmsMessage SmsMessage { get; set; }
    }
}
