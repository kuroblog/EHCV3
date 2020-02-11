
namespace WzHealthCard.Refactor.Api.Repositories.Erhc
{
    using WzHealthCard.Refactor.Api.DataAccess;
    using WzHealthCard.Refactor.Api.DataAccess.Erhc;

    public class TempCardRepository : BaseRepository<TempCardEntity>
    {
        public TempCardRepository(ErhcContext context) : base(context) { }
    }
}
