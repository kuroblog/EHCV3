
using System.Net.Http;
using WzHealthCard.Refactor.Api.Common;
using WzHealthCard.Refactor.Api.Extensions;
using WzHealthCard.Refactor.Api.Infrastructure;
using WzHealthCard.Refactor.Api.Infrastructure.MiddleWare;

namespace WzHealthCard.Refactor.Api
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Serilog;
    using WzHealthCard.Refactor.Api.Attributes;
    using WzHealthCard.Refactor.Api.DataAccess;
    using WzHealthCard.Refactor.Api.Repositories.Erhc;
    using WzHealthCard.Refactor.Api.Repositories.ErhcManage;
    using WzHealthCard.Refactor.Api.Services.Refactor;
    using WzHealthCard.Refactor.Api.UnitOfWorks;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            // Init Serilog configuration
            Log.Logger = new LoggerConfiguration().Enrich.With(new ThreadIdEnricher()).ReadFrom.Configuration(configuration).CreateLogger();

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                //.AddSingleton<DistrictSettings>()
                //.AddSingleton<MsStepSettings>()
                //.AddSingleton<AppModeSettings>()
                //.AddScoped<IArgModel, RequestArg>()
                .AddSingleton<ConfigManager>()
                .AddScoped<ResultCodeHandler>()
                .AddScoped<IHealthCardService, HealthCardServiceLogical>()
                .AddScoped<IErhcService, ErhcTranService>()
                .AddScoped<IErhcService, ErhcPrvService>()
                .AddScoped<IErhcService, ErhcPubService>()
                .AddScoped<Services.Refactor.ILogger, Logger>()
                .AddScoped<IErrorHandler, ErrorHandler>()
                .AddScoped<IErhcPrvServiceProxy, ErhcPrvServiceProxy>()
                .AddScoped<ISocialCardServiceProxyHandler, WZSocialCardServiceProxyHandler>()
                .AddScoped<ISmsHandler, SmsWseHandler>()
                .AddScoped<IErhcPubServiceProxy, ErhcPubServiceProxy>()
                .AddMyImpServices()
                // erhc
                .AddScoped<ErhcContext>()
                .AddScoped<ErhcUnitOfWork>()
                .AddScoped<CardRepository>()
                .AddScoped<CardExtendRepository>()
                .AddScoped<UseAnalyzeRepository>()
                .AddScoped<ApplyAnalyzeRepository>()
                .AddScoped<LogRepository>()
                .AddScoped<CardFamilyRepository>()
                .AddScoped<TempCardRepository>()
                .AddScoped<TempHospitalRepository>()
                .AddScoped<PersonSymbolRepository>()
                .AddScoped<OneStopRepository>()
                // erhc manage
                .AddScoped<ErhcManageContext>()
                .AddScoped<ErhcManageUnitOfWork>()
                .AddScoped<AppInfoRepository>()
                .AddCors(options =>
                {
                    options.AddPolicy("_myAllowOrigins",
                        builder =>
                        {
                            builder.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                        });
                });

                //HttpClient
                services.AddHttpClient(RemoteHttpNames.RemoteName)
                .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler()
                {
                    ClientCertificateOptions = ClientCertificateOption.Manual,
                    ServerCertificateCustomValidationCallback =
                        (httpRequestMessage, cert, cetChain, policyErrors) => true
                });

            services.AddMvc(config =>
                {
                    //接收text/plain，前提参数是string类型单参数
                    //config.InputFormatters.Insert(0, new RawRequestBodyFormatter());
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

            //跨域
            app.UseCors("_myAllowOrigins");

            #if !DEBUG
            app.UseHttpsRedirection();
            #endif
            app.UseRequestCulture();
            app.UseMvc();
        }
    }
}
