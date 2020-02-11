
namespace WzHealthCard.Infrastructure.Api
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseUrls("http://*:9081;http://*:80")
            //.UseKestrel((whbc, kso) => kso.Configure(whbc.Configuration.GetSection("Kestrel")))
            .UseKestrel()
            //.UseUrls("http://*:6000")
            .UseStartup<Startup>();
    }
}
