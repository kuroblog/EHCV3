
namespace WzHealthCard.Refactor.Api.Repositories.Erhc
{
    using WzHealthCard.Refactor.Api.DataAccess;
    using WzHealthCard.Refactor.Api.DataAccess.Erhc;

    public class UseAnalyzeRepository : BaseRepository<UseAnalyzeEntity>
    {
        public UseAnalyzeRepository(ErhcContext context) : base(context) { }
    }
}
