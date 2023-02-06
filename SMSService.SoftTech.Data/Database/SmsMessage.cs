using SMSService.SoftTech.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSService.SoftTech.Data.Database
{
    public class SmsMessage
    {
        public long Id { get; set; }
        public string MessageText { get; set; }
        public string Phone { get; set; }
        public string SenderName { get; set; }
        public ICollection<SmsState> StateHistory { get; set; }
        public SmsMessage() 
        {
            StateHistory = new HashSet<SmsState>();
        }
    }
}
