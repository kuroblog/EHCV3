
namespace WzHealthCard.Infrastructure.Api.UnitOfWorks
{
    using WzHealthCard.Infrastructure.Api.DataAccess;

    public class ErhcManageUnitOfWork : BaseUnitOfWork<ErhcManageContext>
    {
        public ErhcManageUnitOfWork(ErhcManageContext context) : base(context) { }
    }
}
