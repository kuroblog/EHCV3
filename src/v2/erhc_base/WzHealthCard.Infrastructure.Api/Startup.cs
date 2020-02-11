
namespace WzHealthCard.Infrastructure.Api
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Serilog;
    using Serilog.Core;
    using Serilog.Events;
    using System.Threading;
    using WzHealthCard.Infrastructure.Api.Attributes;
    using WzHealthCard.Infrastructure.Api.DataAccess;
    using WzHealthCard.Infrastructure.Api.Models;
    using WzHealthCard.Infrastructure.Api.Repositories.Erhc;
    using WzHealthCard.Infrastructure.Api.Repositories.ErhcManage;
    using WzHealthCard.Infrastructure.Api.UnitOfWorks;

    public class ThreadIdEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("ThreadId", Thread.CurrentThread.ManagedThreadId));
        }
    }

    //public class RequestIdEnricher : ILogEventEnricher
    //{
    //    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    //    {
    //        var serviceProvider = HttpContext.Current;
    //    }
    //}

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            // Init Serilog configuration
            //Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{DateTime.Now.ToString("yyyyMMdd")}.logs")).CreateLogger();
            Log.Logger = new LoggerConfiguration().Enrich.With(new ThreadIdEnricher()).ReadFrom.Configuration(configuration).CreateLogger();
            //Log.Logger = new LoggerConfiguration().Enrich.FromLogContext().ReadFrom.Configuration(configuration).CreateLogger();

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton<DistrictSettings>()
                .AddSingleton<MsStepSettings>()
                .AddSingleton<AppModeSettings>()
                //.AddScoped<IArgModel, RequestArg>()
                // erhc
                .AddScoped<ErhcContext>()
                .AddScoped<ErhcUnitOfWork>()
                .AddScoped<CardRepository>()
                .AddScoped<CardExtendRepository>()
                .AddScoped<UseAnalyzeRepository>()
                .AddScoped<ApplyAnalyzeRepository>()
                .AddScoped<City3303ViewRepository>()
                .AddScoped<AppModeViewRepository>()
                // erhc manage
                .AddScoped<ErhcManageContext>()
                .AddScoped<ErhcManageUnitOfWork>()
                .AddScoped<AppInfoRepository>()
                .AddMvc(config =>
                {
                    config.Filters.Add(new LogFilterAttribute());
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // logging
            loggerFactory.AddSerilog();

#if !DEBUG
            app.UseHttpsRedirection();
#endif
            app.UseMvc();
        }
    }
}
