using System;
using HtmlAgilityPack;
using LifeInUK.Extractor.Options;
using LifeInUK.Extractor.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace LifeInUK.Extractor
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = AppStartup();
            var service = ActivatorUtilities.CreateInstance<Application>(host.Services);
            service.Start();
        }

        static IHost AppStartup()
        {
            var configBuilder = GetConfigurationBuilder();
            var configuration = configBuilder.Build();

            Log.Logger = ConfigureLogger(configuration);

            Log.Logger.Information("Application Starting");

            var host = Host.CreateDefaultBuilder()
                        .ConfigureServices((context, services) =>
                        {
                            services.Configure<ExtractorOptions>(configuration.GetSection(ExtractorOptions.Selector));
                            services.AddTransient<Application>();
                            services.AddTransient<IRawDataService, RawDataFromFilesService>();
                            services.AddTransient(typeof(IExtractorService<HtmlDocument, HtmlNode>), typeof(HtmlExtractorService));
                        })
                        .UseSerilog()
                        .Build();

            return host;
        }

        private static IConfigurationBuilder GetConfigurationBuilder()
        {
            return new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
        }

        private static ILogger ConfigureLogger(IConfiguration configuration)
        {
            return new LoggerConfiguration()
                        .ReadFrom.Configuration(configuration)
                        .Enrich.FromLogContext()
                        .WriteTo.Console()
                        .CreateLogger();
        }
    }
}
