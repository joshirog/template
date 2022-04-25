using Microsoft.Extensions.DependencyInjection;

namespace Monkeylab.Templates.Api.Commons.Extensions
{
    public static class CorsExtension
    {
        public static void AddCorsService(this IServiceCollection services, string allowSpecificOrigins)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(allowSpecificOrigins,
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
        }
    }
}