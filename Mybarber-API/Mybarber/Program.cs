using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Mybarber.Helpers;
using Mybarber.Persistencia;
using Mybarber.Repositories;
using Mybarber.Services;
using Mybarber.WebSockets.Server;
using Serilog;
using System;
using System.Globalization;
using System.Threading;

namespace Mybarber
{
    public class Program
    {
        public static void Main(string[] args)
       {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

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
