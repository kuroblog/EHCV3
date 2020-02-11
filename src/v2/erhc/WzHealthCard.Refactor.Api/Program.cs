
using Microsoft.Extensions.Configuration;
using NLog.Web;
using System;
using System.IO;
using System.Text;
using Microsoft.Extensions.Logging;

namespace WzHealthCard.Refactor.Api
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;

    public class Program
    {
        public static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var logger = NLogBuilder.ConfigureNLog(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "NLog.config")).GetCurrentClassLogger();

            try
            {
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Stopped program because of exception");
            }
            finally
            {
                NLog.LogManager.Shutdown(); 
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json", true,false)
                .Build();
            return WebHost
                .CreateDefaultBuilder(args)
                .UseConfiguration(configuration)
                //.UseKestrel((whbc, kso) => kso.Configure(whbc.Configuration.GetSection("Kestrel")))
                .UseKestrel()
                
                //.UseUrls("http://*:6000")
                .UseStartup<Startup>()
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    logging.AddDebug();
                    logging.AddEventSourceLogger();
                    logging.SetMinimumLevel(LogLevel.Trace);
                })
                .UseNLog();
        }
    }
}
