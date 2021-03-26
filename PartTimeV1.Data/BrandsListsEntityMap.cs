using System.Data.Entity.ModelConfiguration;

namespace PartTimeV1.Data
{
    public class BrandsListsEntityMap : EntityTypeConfiguration<BrandsListsEntity>
    {
        public BrandsListsEntityMap()
        {
            HasKey(t => t.Id);

            ToTable("BrandsList");

            Property(t => t.Company).HasMaxLength(200);
            Property(t => t.Brand).HasMaxLength(200);
        }
    }
}