using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSService.SoftTech.Data.Enums
{
    public enum EMessageState:byte
    {
        Submited = 0,
        Error = 1,
        Delivered = 2
    }
}
