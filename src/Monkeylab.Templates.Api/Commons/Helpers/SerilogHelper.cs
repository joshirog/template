using System.IO;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace Monkeylab.Templates.Api.Commons.Helpers
{
    public static class SerilogHelper
    {
        private static LoggingLevelSwitch BaseLevelSwitch { get; } = new();
        private static LoggingLevelSwitch MicrosoftLevelSwitch { get; } = new();
        private static LoggingLevelSwitch MicrosoftEntityFrameworkCoreLevelSwitch { get; } = new();
        private static LoggingLevelSwitch MicrosoftHostingLifetimeLevelSwitch { get; } = new();

        public static void AddLogger()
        {
            BaseLevelSwitch.MinimumLevel = LogEventLevel.Information;
            MicrosoftLevelSwitch.MinimumLevel = LogEventLevel.Information;
            MicrosoftEntityFrameworkCoreLevelSwitch.MinimumLevel = LogEventLevel.Information;
            MicrosoftHostingLifetimeLevelSwitch.MinimumLevel = LogEventLevel.Information;

            const string template = "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff}] [{Level:u3}] [{SourceContext}] {Message:lj}{NewLine}{Exception}";
            
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
            
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.ControlledBy(BaseLevelSwitch)
                .MinimumLevel.Override("Microsoft", MicrosoftLevelSwitch)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore", MicrosoftEntityFrameworkCoreLevelSwitch)
                .MinimumLevel.Override("Microsoft.Hosting.Lifetime", MicrosoftHostingLifetimeLevelSwitch)
                .WriteTo.Async(x => x.Console(outputTemplate: template))
                .WriteTo.Async(x => x.File(
                    Path.Combine( Directory.GetCurrentDirectory(), config.GetSection("Serilog")["PathFile"]),
                    shared: false,
                    rollingInterval: RollingInterval.Day,
                    levelSwitch: BaseLevelSwitch,
                    outputTemplate: template))
                .CreateLogger();
        }
    }
}