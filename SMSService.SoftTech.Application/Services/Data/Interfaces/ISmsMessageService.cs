using SMSService.SoftTech.Application.DTOs;
using SMSService.SoftTech.Data.Database;
using System.Threading.Tasks;

namespace SMSService.SoftTech.Application.Services.DataServices.Interfaces
{
    internal interface ISmsMessageService
    {
        /// <summary>
        /// Get message with all history mapped to DTO
        /// </summary>
        Task<SmsMessageDTO> SelectMessage(long messageId);
        /// <summary>
        /// Add DTO message to database
        /// </summary>
        /// <param name="message">New message</param>
        Task AddMessage(SmsMessageDTO messageDTO);
    }
}
