
using HealthyBackground.Core.Entity;

namespace WzHealthCard.Refactor.Api.DataAccess
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using WzHealthCard.Refactor.Api.DataAccess.ErhcManage;

    public class ErhcManageContext : DbContext
    {
        static ErhcManageContext() { }

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
                .UseLoggerFactory(loggerFactory)
                .UseMySql(config.GetConnectionString(nameof(ErhcManageContext)));
        }

        public DbSet<AppInfoEntity> AppInfos { get; set; }

        public DbSet<OrganziationEntity> Organziation { get; set; }

        /// <summary>
        /// 白名单
        /// </summary>
        public DbSet<WhiteAppKeys> WhiteAppKeys { get; set; }
    }
}
