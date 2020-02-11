
namespace WzHealthCard.Refactor.Api.UnitOfWorks
{
    using WzHealthCard.Refactor.Api.DataAccess;

    public class ErhcUnitOfWork : BaseUnitOfWork<ErhcContext>
    {
        public ErhcUnitOfWork(ErhcContext context) : base(context) { }
    }
}
