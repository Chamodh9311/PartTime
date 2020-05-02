using System.Data.Entity;

namespace PartTimeV1.Data
{
    public class EFDbContext : DbContext
    {
        public EFDbContext() :
          base("Name=DefaultConnection")
        {
            Database.SetInitializer<EFDbContext>(null);
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            _ = modelBuilder.Configurations.Add(new UserProfileEntityMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
