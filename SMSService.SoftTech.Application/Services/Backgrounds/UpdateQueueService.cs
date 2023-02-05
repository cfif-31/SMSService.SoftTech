using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSService.SoftTech.Application.Services.Backgrounds
{
    internal class UpdateQueueService
    {
        public ConcurrentQueue<long> MessageIdsTasks { get; set; }
        public UpdateQueueService()
        {
            MessageIdsTasks = new ConcurrentQueue<long>();
        }
    }
}
