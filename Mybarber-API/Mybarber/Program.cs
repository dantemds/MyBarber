using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Mybarber.Helpers;
using Serilog;
using System;

namespace Mybarber
{
    public class Program
    {
        public static void Main(string[] args)
       {
          

            
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("text.txt")
                .CreateLogger();


            CreateHostBuilder(args).Build().Run();
            Log.Information("Api Acionada");

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
