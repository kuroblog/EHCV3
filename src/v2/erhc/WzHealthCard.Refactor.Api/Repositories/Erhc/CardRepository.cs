
namespace WzHealthCard.Refactor.Api.Repositories.Erhc
{
    using WzHealthCard.Refactor.Api.DataAccess;
    using WzHealthCard.Refactor.Api.DataAccess.Erhc;

    public class CardRepository : BaseRepository<CardEntity>
    {
        public CardRepository(ErhcContext context) : base(context) { }
    }
}
