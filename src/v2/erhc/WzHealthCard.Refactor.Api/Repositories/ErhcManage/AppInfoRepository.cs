
namespace WzHealthCard.Refactor.Api.Repositories.ErhcManage
{
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using WzHealthCard.Refactor.Api.DataAccess;
    using WzHealthCard.Refactor.Api.DataAccess.ErhcManage;

    public class AppInfoRepository : BaseRepository<AppInfoEntity>
    {
        public AppInfoRepository(ErhcManageContext context) : base(context) { }

        public virtual IQueryable<AppInfoEntity> FromSql(string sqlString)
        {
            return dbSet.FromSql(sqlString);
        }
    }
}
