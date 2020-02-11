
namespace WzHealthCard.Infrastructure.Api.Repositories.ErhcManage
{
    using WzHealthCard.Infrastructure.Api.DataAccess;
    using WzHealthCard.Infrastructure.Api.DataAccess.ErhcManage;

    public class AppInfoRepository : BaseRepository<AppInfoEntity>
    {
        public AppInfoRepository(ErhcManageContext context) : base(context) { }
    }
}
