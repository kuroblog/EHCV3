
namespace WzHealthCard.Infrastructure.Api.Repositories.Erhc
{
    using System.Linq;
    using WzHealthCard.Infrastructure.Api.DataAccess;
    using WzHealthCard.Infrastructure.Api.DataAccess.Erhc;

    public class City3303ViewRepository : BaseRepository<City3303View>
    {
        public City3303ViewRepository(ErhcContext context) : base(context) { }

        public override IQueryable<City3303View> View => context.Query<City3303View>();
    }

    public class AppModeViewRepository : BaseRepository<AppModeView>
    {
        public AppModeViewRepository(ErhcContext context) : base(context) { }

        public override IQueryable<AppModeView> View => context.Query<AppModeView>();
    }
}
