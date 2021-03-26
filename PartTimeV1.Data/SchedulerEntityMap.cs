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
            Property(t => t.FromDate).IsRequired(); 
            Property(t => t.ToDate).IsRequired();
            Property(t => t.PromoterCount).IsRequired(); 
            Property(t => t.District).HasMaxLength(500); 
            Property(t => t.Town).HasMaxLength(500); 
            Property(t => t.Comments);
            Property(t => t.Time).HasMaxLength(100).IsRequired(); ;
            Property(t => t.Payment).HasMaxLength(500).IsRequired(); ;

            Property(t => t.Location).HasMaxLength(1000).IsRequired();
            Property(t => t.NumberOfDays).IsRequired();
            Property(t => t.Mobile).HasMaxLength(500).IsRequired();
            Property(t => t.Gender).HasMaxLength(100).IsRequired();

            Property(t => t.CreatedId);
            Property(t => t.ApprovedId);
            Property(t => t.Finished);
            Property(t => t.Approved).IsRequired();
            Property(t => t.Deleted).IsRequired();
            Property(t => t.CreateOn).IsRequired();
        }
    }
}
