
namespace WzHealthCard.Refactor.Api.Repositories.Erhc
{
    using WzHealthCard.Refactor.Api.DataAccess;
    using WzHealthCard.Refactor.Api.DataAccess.Erhc;

    public class CardFamilyRepository : BaseRepository<CardFamilyEntity>
    {
        public CardFamilyRepository(ErhcContext context) : base(context) { }
    }
}
