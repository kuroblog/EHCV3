
namespace WzHealthCard.Infrastructure.Api.DataAccess
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using WzHealthCard.Infrastructure.Api.DataAccess.Erhc;

    public class ErhcContext : DbContext
    {
        //internal string ConnectionString => "server=192.168.1.192;database=erhc;user=root;password=123456;CharSet=utf8;port=3306;Persist Security Info=true;";

        //private static readonly LoggerFactory loggerFactory = new LoggerFactory();

        static ErhcContext()
        {
            //loggerFactory.AddProvider(new MyLoggerProvider());
        }

        private readonly ILoggerFactory loggerFactory;
        private readonly IConfiguration config;

        public ErhcContext(ILoggerFactory loggerFactory, IConfiguration config)
        {
            this.loggerFactory = loggerFactory;
            this.config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder ob)
        {
            ob
                //.UseLoggerFactory(loggerFactory)
                .UseLoggerFactory(loggerFactory)
                .UseMySql(config.GetConnectionString(nameof(ErhcContext)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Query<City3303View>().ToView("v_city_3303");
            modelBuilder.Query<AppModeView>().ToView("v_app_mode");
        }

        public DbSet<CardEntity> Cards { get; set; }

        public DbSet<CardExtendEntity> CardExtends { get; set; }

        public DbSet<UseAnalyzeEntity> UseAnalysis { get; set; }

        public DbSet<ApplyAnalyzeEntity> ApplyAnalysis { get; set; }

        public DbQuery<City3303View> City3303View { get; set; }

        public DbQuery<AppModeView> AppModeView { get; set; }
    }
}
