
namespace WzHealthCard.Infrastructure.Api.UnitOfWorks
{
    using WzHealthCard.Infrastructure.Api.DataAccess;

    public class ErhcUnitOfWork : BaseUnitOfWork<ErhcContext>
    {
        public ErhcUnitOfWork(ErhcContext context) : base(context) { }
    }
}
