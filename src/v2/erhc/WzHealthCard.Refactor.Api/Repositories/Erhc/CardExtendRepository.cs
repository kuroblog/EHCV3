
namespace WzHealthCard.Refactor.Api.Repositories.Erhc
{
    using WzHealthCard.Refactor.Api.DataAccess;
    using WzHealthCard.Refactor.Api.DataAccess.Erhc;

    public class CardExtendRepository : BaseRepository<CardExtendEntity>
    {
        public CardExtendRepository(ErhcContext context) : base(context) { }
    }
}
