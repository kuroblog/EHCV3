
namespace WzHealthCard.Infrastructure.Api.Repositories.Erhc
{
    using WzHealthCard.Infrastructure.Api.DataAccess;
    using WzHealthCard.Infrastructure.Api.DataAccess.Erhc;

    public class CardRepository : BaseRepository<CardEntity>
    {
        public CardRepository(ErhcContext context) : base(context) { }
    }
}
