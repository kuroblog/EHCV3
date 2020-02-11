
namespace WzHealthCard.Infrastructure.Api.DataAccess
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using WzHealthCard.Infrastructure.Api.DataAccess.ErhcManage;

    public class ErhcManageContext : DbContext
    {
        //internal string ConnectionString => "server=192.168.1.192;database=erhc;user=root;password=123456;CharSet=utf8;port=3306;Persist Security Info=true;";

        //private static readonly LoggerFactory loggerFactory = new LoggerFactory();

        static ErhcManageContext()
        {
            //loggerFactory.AddProvider(new MyLoggerProvider());
        }

        private readonly ILoggerFactory loggerFactory;
        private readonly IConfiguration config;

        public ErhcManageContext(ILoggerFactory loggerFactory, IConfiguration config)
        {
            this.loggerFactory = loggerFactory;
            this.config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder ob)
        {
            ob
                //.UseLoggerFactory(loggerFactory)
                .UseLoggerFactory(loggerFactory)
                .UseMySql(config.GetConnectionString(nameof(ErhcManageContext)));
        }

        public DbSet<AppInfoEntity> AppInfos { get; set; }
    }
}
