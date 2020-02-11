
namespace WzHealthCard.Infrastructure.Api.UnitOfWorks
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;

    public interface IUnitOfWork
    {
        int Commit();

        Task<int> CommitAsync();
    }

    public abstract class BaseUnitOfWork<TContext> : IDisposable, IUnitOfWork where TContext : DbContext
    {
        protected TContext context = null;

        public BaseUnitOfWork(TContext context)
        {
            this.context = context;
        }

        public virtual int Commit() => context.SaveChanges();

        public async virtual Task<int> CommitAsync() => await context.SaveChangesAsync();

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }

                disposed = true;
            }
        }

        ~BaseUnitOfWork()
        {
            Dispose(false);
        }
    }
}
