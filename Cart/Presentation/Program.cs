using Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Presentation
{
    public class Program
    {
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
             .UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
                    .WriteTo.Debug()
                    .WriteTo.Console(outputTemplate: CartConstants.SeriLogMessageTemplate)
                    .WriteTo.File(CartConstants.LoggingFilePath, Serilog.Events.LogEventLevel.Error));
    }
}