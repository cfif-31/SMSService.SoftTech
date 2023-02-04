using SMSService.SoftTech.Application.DTOs;
using SMSService.SoftTech.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSService.SoftTech.Application.Services.DataServices.Interfaces
{
    internal interface ISmsStateService
    {
        /// <summary>
        /// Get all state with messages and map to DTO
        /// </summary>
        IAsyncEnumerable<SmsStateDTO> SelectAllStatesWithMessages();
        /// <summary>
        /// Set new message state from DTO
        /// </summary>
        /// <param name="smsState"><new message state</param>
        Task AddMessageState(SmsStateDTO smsState);
    }
}
