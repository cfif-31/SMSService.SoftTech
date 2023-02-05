using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SMSService.SoftTech.Infrastructure.Context;
using SMSService.SoftTech.Infrastructure.Repositories;
using SMSService.SoftTech.Infrastructure.Repositories.Interfaces;
using System;

namespace SMSService.SoftTech.Infrastructure.Extentions
{
    public static class InfrastructureServiceExtensions
    {
        /// <summary>
        /// Registration Infrastructure module in DI
        /// </summary>
        /// <param name="services">Service collections</param>
        /// <param name="options">Db context options</param>
        public static void AddInfrastructure(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            //Registration DbContext
            services.AddDbContext<DataContext>(options);

            //Registration repositories
            services.AddScoped<ISmsMessageRepository, SmsMessageRepository>();
            services.AddScoped<ISmsStateReoisitory, SmsStateReoisitory>();
        }
    }
}
