using Microsoft.Extensions.DependencyInjection;
using Monkeylab.Templates.Application.Commons.Interfaces;
using Monkeylab.Templates.Infrastructure.Persistences.Repositories;
using Monkeylab.Templates.Infrastructure.Services;

namespace Monkeylab.Templates.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            
            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<IConfigurationService, ConfigurationService>();
            
            return services;
        }
    }
}