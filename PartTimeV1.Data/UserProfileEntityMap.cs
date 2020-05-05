using System.Data.Entity.ModelConfiguration;

namespace PartTimeV1.Data
{
    public class UserProfileEntityMap : EntityTypeConfiguration<UserProfileEntity>
    {
        public UserProfileEntityMap()
        {
            HasKey(t => t.Id);

            ToTable("UserProfile");

            Property(t => t.FullName).HasMaxLength(500).IsRequired();
            Property(t => t.ShortName).HasMaxLength(500).IsRequired();
            Property(t => t.NIC).HasMaxLength(20).IsRequired();
            Property(t => t.Photo1).IsRequired();
            Property(t => t.Photo2).IsRequired();
            Property(t => t.Photo3).IsRequired();
            Property(t => t.Photo4).IsOptional();
            Property(t => t.Photo5).IsOptional();
            Property(t => t.Mobile1).HasMaxLength(20).IsRequired();
            Property(t => t.Mobile1Whatsapp);
            Property(t => t.Mobile1Viber);
            Property(t => t.Mobile2).HasMaxLength(20).IsOptional();
            Property(t => t.Mobile2Whatsapp);
            Property(t => t.Mobile2Viber);
            Property(t => t.Mobile3).HasMaxLength(20).IsOptional();
            Property(t => t.Mobile3Whatsapp);
            Property(t => t.Mobile3Viber);

            Property(t => t.DOB);
            Property(t => t.Age).HasMaxLength(10).IsRequired();
            Property(t => t.GenderMale);
            Property(t => t.GenderFemale);
            Property(t => t.CurrentDistrict).HasMaxLength(200);
            Property(t => t.CurrentTown).HasMaxLength(200);
            Property(t => t.HomeDistrict).HasMaxLength(200);
            Property(t => t.HomeTown).HasMaxLength(200);
            Property(t => t.ShirtSizeS);
            Property(t => t.ShirtSizeM);
            Property(t => t.ShirtSizeL);
            Property(t => t.ShirtSizeXS);
            Property(t => t.Student);
            Property(t => t.University).HasMaxLength(200).IsOptional();
            Property(t => t.Course).HasMaxLength(200).IsOptional();
            Property(t => t.UniYear).HasMaxLength(20).IsOptional();
            Property(t => t.Employeed);
            Property(t => t.Company).HasMaxLength(200).IsOptional();
            Property(t => t.Branch).HasMaxLength(200).IsOptional();
            Property(t => t.Designation).HasMaxLength(200).IsOptional();
            Property(t => t.FullTimePromoter);
            Property(t => t.PartTimePromoter);
            Property(t => t.EnglishSpeaking).HasMaxLength(100).IsOptional();
            Property(t => t.TamilSpeaking).HasMaxLength(100).IsOptional();
            Property(t => t.SalesExperience).HasMaxLength(10).IsOptional();
            Property(t => t.Brands).IsOptional();
            Property(t => t.OtherExperience).IsOptional();

            Property(t => t.Approved);
            Property(t => t.Deleted);
            Property(t => t.Banned);
            Property(t => t.CreateOn);
            Property(t => t.Version);
        }
    }
}