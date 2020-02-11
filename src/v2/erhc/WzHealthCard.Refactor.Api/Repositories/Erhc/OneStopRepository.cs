using WzHealthCard.Refactor.Api.DataAccess;
using WzHealthCard.Refactor.Api.DataAccess.Erhc;

namespace WzHealthCard.Refactor.Api.Repositories.Erhc
{
    public class OneStopRepository : BaseRepository<OneStopEntity>
    {
        public OneStopRepository(ErhcContext context) : base(context)
        {

        }
    }
}