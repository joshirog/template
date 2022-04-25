using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Monkeylab.Templates.Api.Commons.Extensions;
using Monkeylab.Templates.Application;
using Monkeylab.Templates.Infrastructure;

namespace Monkeylab.Templates.Api
{
    public class Startup
    {
        private IConfiguration _configuration { get; }

        private const string allowSpecificOrigins = "_allowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddConnectionService(_configuration);

            services.AddSwaggerService();

            services.AddHealthCheckService();

            services.AddVersionService();
            
            services.AddInfrastructure();
            
            services.AddApplication();
            
            services.AddControllerService();
            
            services.AddCorsService(allowSpecificOrigins);
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (_configuration["AppSettings:Environment"] == "Development" || _configuration["AppSettings:Environment"] == "Quality")
            {
                app.UseDeveloperExceptionPage();

                app.AddSwaggerApp(provider);
            }

            app.AddHealthCheckApp();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(allowSpecificOrigins);

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
