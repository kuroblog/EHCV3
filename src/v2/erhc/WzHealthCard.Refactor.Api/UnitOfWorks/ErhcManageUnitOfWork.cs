
namespace WzHealthCard.Refactor.Api.UnitOfWorks
{
    using WzHealthCard.Refactor.Api.DataAccess;

    public class ErhcManageUnitOfWork : BaseUnitOfWork<ErhcManageContext>
    {
        public ErhcManageUnitOfWork(ErhcManageContext context) : base(context) { }
    }
}
