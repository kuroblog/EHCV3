
namespace WzHealthCard.Refactor.Api.Repositories.Erhc
{
    using WzHealthCard.Refactor.Api.DataAccess;
    using WzHealthCard.Refactor.Api.DataAccess.Erhc;

    public class ApplyAnalyzeRepository : BaseRepository<ApplyAnalyzeEntity>
    {
        public ApplyAnalyzeRepository(ErhcContext context) : base(context) { }
    }
}
