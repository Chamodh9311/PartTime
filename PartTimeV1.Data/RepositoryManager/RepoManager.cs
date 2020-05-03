using System;
using System.Data.Entity;

namespace PartTimeV1.Data.RepositoryManager
{
    public partial class RepoManager : IDisposable
    {
        private EFDbContext dbContext = null;
        private DbContextTransaction dbTransaction = null;

        public RepoManager()
        {
            this.dbContext = new EFDbContext();
        }

        ~RepoManager()
        {
            this.Dispose(false);
        }

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (this._disposed) { return; }

            if (disposing)
            {
                if (this.dbContext != null)
                {
                    this.dbContext.Dispose();
                }
            }

            this._disposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        //Explicit Transaction
        public void BeginTransaction()
        {
            this.dbTransaction = this.dbContext.Database.BeginTransaction();
        }
        public void Commit()
        {
            this.dbContext.SaveChanges();

            if (this.dbTransaction == null) { return; }

            this.dbTransaction.Commit();
            this.dbTransaction = null;
        }
        public void Rollback()
        {
            if (this.dbTransaction == null) { return; }

            this.dbTransaction.Rollback();
            this.dbTransaction = null;
        }

        public void PartialCommit()
        {
            if (this.dbTransaction == null) { return; }

            this.dbContext.SaveChanges();

        }
    }
}

