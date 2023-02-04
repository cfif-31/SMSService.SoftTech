using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SMSService.SoftTech.Application.Profiles;
using SMSService.SoftTech.Application.Services.DataServices;
using SMSService.SoftTech.Application.Services.DataServices.Interfaces;
using SMSService.SoftTech.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSService.SoftTech.Application.Extentions
{
    public static class ApplicationServiceExtensions
    {
        /// <summary>
        /// Registration Application module in DI
        /// </summary>
        /// <param name="services">Service collections</param>
        public static void AddInfrastructure(this IServiceCollection services)
        {
            //Mapper
            services.AddAutoMapper(typeof(AutoMapperProfile));

            //Data services
            services.AddScoped<ISmsMessageService, SmsMessageService>();
            services.AddScoped<ISmsStateService, SmsStateService>();
        }
    }
}
