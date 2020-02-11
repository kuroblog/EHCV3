
namespace WzHealthCard.Infrastructure.Api.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepoistory<TEntity> where TEntity : class, new()
    {
        // Lazy load
        IQueryable<TEntity> View { get; }
        // One time load
        // IEnumerable<TEntity> List { get; }

        IEnumerable<TEntity> Select(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params string[] includeProperties);

        TEntity Select(params object[] keys);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Update(TEntity entity, params object[] keys);

        void Delete(TEntity entity);

        void Delete(params object[] keys);
    }

    public abstract class BaseRepository<TEntity> : IRepoistory<TEntity> where TEntity : class, new()
    {
        internal DbContext context = null;
        internal DbSet<TEntity> dbSet = null;

        public BaseRepository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> View => dbSet;

        public virtual IEnumerable<TEntity> Select(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params string[] includeProperties)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            includeProperties?.ToList().ForEach(p => query = query.Include(p));

            return orderBy != null ? orderBy(query).AsEnumerable() : query.AsEnumerable();
        }

        public virtual TEntity Select(params object[] keys) => dbSet.Find(keys);

        public virtual void Insert(TEntity entity) => dbSet.Add(entity);

        public virtual void Update(TEntity entity) => context.Entry(entity);
        // Another Update
        // public virtual void Update(TEntity entity)
        // {
        //     dbSet.Attach(entity);
        //     db.Entry(entity).State = EntityState.Modified;
        // }

        public virtual void Update(TEntity entity, params object[] keys)
        {
            var original = Select(keys);
            if (original != null)
            {
                context.Entry(original).CurrentValues.SetValues(entity);
            }
        }

        public virtual void Delete(TEntity entity) => context.Remove(entity);
        // Another Delete
        // public virtual void Delete(TEntity entity)
        // {
        //     var state = db.Entry(entity).State;
        //     if (state == EntityState.Detached)
        //     {
        //         dbSet.Attach(entity);
        //     }
        //     dbSet.Remove(entity);
        // }

        public virtual void Delete(params object[] keys)
        {
            var original = Select(keys);
            if (original != null)
            {
                Delete(original);
            }
        }
    }
}
