using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Formatting.Compact;
using System.Globalization;
using System.Threading;

namespace Mybarber
{
    public class Program
    {
        public static void Main(string[] args)
       {

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Configurelog();
            Log.Information("API Acionada");
            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).UseSerilog();
        public static void Configurelog()
        {
            Log.Logger = new LoggerConfiguration()
                 .MinimumLevel.Information()
                 //.MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
                 //.MinimumLevel.Override("Microsoft.Hosting.Lifetime", Serilog.Events.LogEventLevel.Information)
                 //.WriteTo.Console(outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                 //.WriteTo.File("Logs/errors.txt", rollingInterval: RollingInterval.Month, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error)
                 //.WriteTo.File("Logs/infos.txt", rollingInterval: RollingInterval.Month, restrictedToMinimumLevel:Serilog.Events.LogEventLevel.Information)
                 //.WriteTo.File(new CompactJsonFormatter(), "Logs/jsonLog.txt")
                 //.Enrich.WithEnvironmentName()
                 //.Enrich.WithThreadId()
                 //.Enrich.WithMachineName()
                 .CreateLogger();
        }
    }
}
