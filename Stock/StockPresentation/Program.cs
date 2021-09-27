using Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace StockPresentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
             .UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
                    .WriteTo.Debug()
                    .WriteTo.Console(outputTemplate: StockConstants.SeriLogMessageTemplate)
                    .WriteTo.File(StockConstants.LoggingFilePath, Serilog.Events.LogEventLevel.Error));
    }
}
