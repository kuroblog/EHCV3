
namespace WzHealthCard.Refactor.Api.Repositories.Erhc
{
    using WzHealthCard.Refactor.Api.DataAccess;
    using WzHealthCard.Refactor.Api.DataAccess.Erhc;

    public class LogRepository : BaseRepository<LogEntity>
    {
        public LogRepository(ErhcContext context) : base(context) { }
    }
}
