
namespace WzHealthCard.Infrastructure.Api.Repositories.Erhc
{
    using WzHealthCard.Infrastructure.Api.DataAccess;
    using WzHealthCard.Infrastructure.Api.DataAccess.Erhc;

    public class CardExtendRepository : BaseRepository<CardExtendEntity>
    {
        public CardExtendRepository(ErhcContext context) : base(context) { }
    }
}
