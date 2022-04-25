using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Monkeylab.Templates.Infrastructure.Persistences.Contexts;

namespace Monkeylab.Templates.Api.Commons.Extensions
{
    public static class ConnectionExtension
    {
        public static void AddConnectionService(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(ApplicationDbContext).Assembly.FullName;

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DbConnection"),
                    b => b.MigrationsAssembly(assembly)
                ).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
        }
    }
}