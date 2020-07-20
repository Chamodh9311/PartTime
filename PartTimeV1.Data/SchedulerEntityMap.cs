using System.Data.Entity.ModelConfiguration;

namespace PartTimeV1.Data
{
    public class SchedulerEntityMap : EntityTypeConfiguration<SchedulerEntity>
    {
        public SchedulerEntityMap()
        {
            HasKey(t => t.Id);

            ToTable("SchedulerDetails");

            Property(t => t.GigName).HasMaxLength(500).IsRequired();
            Property(t => t.Brands);
            Property(t => t.FromDate);
            Property(t => t.ToDate);
            Property(t => t.PromoterCount);
            Property(t => t.District);
            Property(t => t.Town);
            Property(t => t.Comments);

            Property(t => t.CreatedId);
            Property(t => t.ApprovedId);
            Property(t => t.Finished);
            Property(t => t.Approved).IsRequired();
            Property(t => t.Deleted).IsRequired();
            Property(t => t.CreateOn).IsRequired();
        }
    }
}
