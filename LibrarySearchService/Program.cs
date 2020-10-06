using LibrarySearchService.Core.Constants;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace LibrarySearchService
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
                    webBuilder.UseStartup<Startup>()
                        .UseSerilog((hostingContext, loggerConfiguration) =>
                        {
                            loggerConfiguration
                                .MinimumLevel.Information()
                                .Enrich.FromLogContext()
                                .Enrich.WithProperty(LogAttributeKeys.ApplicationInstanceName, "Library Search Service")
                                .WriteTo.Console();
                        });
                });
    }
}
