using SMSService.SoftTech.Application.DTOs;
using SMSService.SoftTech.Data.Database;
using SMSService.SoftTech.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SMSService.SoftTech.Application.Services.DataServices.Interfaces
{
    internal interface ISmsStateService
    {
        /// <summary>
        /// Get all states with messages where last state is message state
        /// </summary>
        /// <param name="messageState">last message state</param>
        /// <returns></returns>
        Task<long[]> SelectAllMessageIDsByState(EMessageState messageState, CancellationToken cancellation = default);
        /// <summary>
        /// Set new message state from DTO
        /// </summary>
        /// <param name="smsState"><new message state</param>
        Task<SmsStateDTO> AddMessageState(SmsStateDTO smsState, CancellationToken cancellation = default);
    }
}
