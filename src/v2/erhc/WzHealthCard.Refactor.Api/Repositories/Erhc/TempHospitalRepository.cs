
namespace WzHealthCard.Refactor.Api.Repositories.Erhc
{
    using WzHealthCard.Refactor.Api.DataAccess;
    using WzHealthCard.Refactor.Api.DataAccess.Erhc;

    public class TempHospitalRepository : BaseRepository<TempHospitalEntity>
    {
        public TempHospitalRepository(ErhcContext context) : base(context) { }
    }
}
