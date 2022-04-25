using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
using Monkeylab.Templates.Infrastructure.Persistences.Contexts;

namespace Monkeylab.Templates.Api.Commons.Extensions
{
    public static class HealthCheckExtension
    {
        public static void AddHealthCheckService(this IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddDbContextCheck<ApplicationDbContext>();
            
            services.AddHealthChecksUI()
                .AddInMemoryStorage();
        }
        
        public static void AddHealthCheckApp(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse //nuget: AspNetCore.HealthChecks.UI.Client
            });

            app.UseHealthChecksUI(options =>
            {
                options.UIPath = "/health";
                options.ApiPath = "/health-api";
            });
        }
    }
}