
namespace WzHealthCard.Refactor.Api.DataAccess
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using WzHealthCard.Refactor.Api.DataAccess.Erhc;

    public class ErhcContext : DbContext
    {
        static ErhcContext() { }

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
                .UseLoggerFactory(loggerFactory)
                .UseMySql(config.GetConnectionString(nameof(ErhcContext)));
        }

        public DbSet<CardEntity> Cards { get; set; }

        public DbSet<CardExtendEntity> CardExtends { get; set; }

        public DbSet<UseAnalyzeEntity> UseAnalysis { get; set; }

        public DbSet<ApplyAnalyzeEntity> ApplyAnalysis { get; set; }

        public DbSet<LogEntity> Logs { get; set; }

        public DbSet<CardFamilyEntity> Families { get; set; }

        public DbSet<TempeCardEntity> TempeCards { get; set; }

        public DbSet<TempHospitalEntity> Temphospital { get; set; }

        /// <summary>
        /// 人员标识信息
        /// </summary>
        public DbSet<PersonSymbolEntity> PersonSymbol { get; set; }

        /// <summary>
        /// 温州一站式登录
        /// </summary>
        public DbSet<OneStopEntity> OneStop { get; set; }
    }
}
