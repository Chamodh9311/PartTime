using System.Data.Entity;

namespace PartTimeV1.Data
{
    public class EFDbContext : DbContext
    {
        public EFDbContext() :
          base("Name=DbConnection")
        {
            Database.SetInitializer<EFDbContext>(null);
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PromoterProfileEntityMap());
            modelBuilder.Configurations.Add(new CoordinatorEntityMap());
            modelBuilder.Configurations.Add(new BrandsListsEntityMap());
            modelBuilder.Configurations.Add(new SchedulerEntityMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
