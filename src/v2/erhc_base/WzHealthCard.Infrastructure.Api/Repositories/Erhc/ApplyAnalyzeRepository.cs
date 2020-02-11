
namespace WzHealthCard.Infrastructure.Api.Repositories.Erhc
{
    using WzHealthCard.Infrastructure.Api.DataAccess;
    using WzHealthCard.Infrastructure.Api.DataAccess.Erhc;

    public class ApplyAnalyzeRepository : BaseRepository<ApplyAnalyzeEntity>
    {
        public ApplyAnalyzeRepository(ErhcContext context) : base(context) { }
    }
}
