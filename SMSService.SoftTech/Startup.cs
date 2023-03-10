using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Npgsql;
using SMSService.SoftTech.API.Middleware;
using SMSService.SoftTech.Application.Extentions;
using SMSService.SoftTech.Infrastructure.Extentions;
using System.Text.Json.Serialization;

namespace SMSService.SoftTech
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private const string corsPoliticsName = "corsAllPolitic";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers()
                .AddJsonOptions(j=>j.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SMSService.SoftTech", Version = "v1" });
            });

            services.AddCors();
            services.AddCors(p => p.AddPolicy(corsPoliticsName, builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("date");
            }));
            services.AddHttpContextAccessor();

            services.AddInfrastructure(db => db.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .UseNpgsql(Configuration.GetConnectionString("NPGSqlConnection")));
            services.AddApplication();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseSwagger(c =>
                c.RouteTemplate = "api/swagger/{documentname}/swagger.json"
            );

            app.UseSwaggerUI(
                c => {
                    c.SwaggerEndpoint("/api/swagger/v1/swagger.json", "SMSService.SoftTech v1");
                    c.RoutePrefix = "api/swagger";
                }
            );

            app.UseCors(corsPoliticsName);
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
