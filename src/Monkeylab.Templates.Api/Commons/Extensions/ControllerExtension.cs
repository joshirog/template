using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Monkeylab.Templates.Api.Commons.Filters;

namespace Monkeylab.Templates.Api.Commons.Extensions
{
    public static class ControllerExtension
    {
        public static void AddControllerService(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<ExceptionFilter>();
            });
            
            services.AddRouting(options => options.LowercaseUrls = true);
            
            /*
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            */
        }
    }
}