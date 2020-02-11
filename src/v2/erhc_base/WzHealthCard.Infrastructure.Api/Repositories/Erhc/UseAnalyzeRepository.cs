
namespace WzHealthCard.Infrastructure.Api.Repositories.Erhc
{
    using WzHealthCard.Infrastructure.Api.DataAccess;
    using WzHealthCard.Infrastructure.Api.DataAccess.Erhc;

    public class UseAnalyzeRepository : BaseRepository<UseAnalyzeEntity>
    {
        public UseAnalyzeRepository(ErhcContext context) : base(context) { }
    }
}
