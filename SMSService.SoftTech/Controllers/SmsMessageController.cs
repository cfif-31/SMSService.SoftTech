using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSService.SoftTech.Application.DTOs;
using SMSService.SoftTech.Application.Services.Process.Interfaces;
using SMSService.SoftTech.Application.Services.ProcessServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMSService.SoftTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsMessageController : ControllerBase
    {
        [HttpGet]
        public IAsyncEnumerable<SmsMessageDTO> GetSmsMessages(DateTime utcTime, [FromServices] IGetMessageService messageService)
        {
            return messageService.SelectLastStatesWithMessages(utcTime);
        }

        [HttpGet("{id}")]
        public Task<SmsMessageDTO> GetMessageHistory(long id, [FromServices] IGetMessageService messageService)
        {
            return messageService.GetOneMessage(id);
        }

        [HttpPost]
        public Task<SmsMessageDTO> SendSmsMessage(SmsMessageDTO smsMessage, [FromServices] ISendMessageService messageService)
        {
            return messageService.SendMessage(smsMessage);
        }
    }
}
