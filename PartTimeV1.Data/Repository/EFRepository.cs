using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace PartTimeV1.Data.Repository
{
    public abstract class EFRepository<T> : IEFRepository<T> where T : Entity
    {
        protected DbSet<T> dbSet = null;
        protected EFDbContext dbContext = null;

        public EFRepository(EFDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }

        public virtual T FindById(params object[] keyValues)
        {
            return this.dbSet.Find(keyValues);
        }

        public virtual T Create()
        {
            return this.dbSet.Create();
        }

        public virtual T Add(T entity)
        {
            DbEntityEntry dbEntityEntry = this.dbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                this.dbSet.Add(entity);
            }
            return entity;
        }

        public virtual T Update(T entity)
        {
            DbEntityEntry dbEntityEntry = this.dbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                this.dbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;

            return entity;
        }

        public virtual void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = this.dbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                this.dbSet.Attach(entity);
                this.dbSet.Remove(entity);
            }
        }
    }
}