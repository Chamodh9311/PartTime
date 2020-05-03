using System.Data.Entity.ModelConfiguration;

namespace PartTimeV1.Data
{
    public class UserProfileEntityMap : EntityTypeConfiguration<UserProfileEntity>
    {
        public UserProfileEntityMap()
        {
            HasKey(t => t.Id);

            ToTable("UserProfile");

            Property(t => t.FullName).HasMaxLength(500);
            Property(t => t.ShortName).HasMaxLength(500);
            Property(t => t.NIC).HasMaxLength(20);
            Property(t => t.Photo1);
            Property(t => t.Photo2);
            Property(t => t.Photo3);
            Property(t => t.Photo4).IsOptional();
            Property(t => t.Photo5).IsOptional();
            Property(t => t.Mobile1);
            Property(t => t.Mobile1Whatsapp);
            Property(t => t.Mobile1Viber);
            Property(t => t.Mobile2).IsOptional();
            Property(t => t.Mobile2Whatsapp).IsOptional();
            Property(t => t.Mobile2Viber).IsOptional();
            Property(t => t.Mobile3).IsOptional();
            Property(t => t.Mobile3Whatsapp).IsOptional();
            Property(t => t.Mobile3Viber).IsOptional();

            Property(t => t.DOB);
            Property(t => t.Age);
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
            Property(t => t.Student).IsOptional();
            Property(t => t.University).HasMaxLength(200).IsOptional();
            Property(t => t.Course).HasMaxLength(200).IsOptional();
            Property(t => t.UniYear).IsOptional();
            Property(t => t.Employeed).IsOptional();
            Property(t => t.Company).HasMaxLength(200).IsOptional();
            Property(t => t.Branch).HasMaxLength(200).IsOptional();
            Property(t => t.Designation).HasMaxLength(200).IsOptional();
            Property(t => t.FullTimePromoter).IsOptional();
            Property(t => t.PartTimePromoter).IsOptional();
            Property(t => t.EnglishSpeaking).HasMaxLength(100).IsOptional();
            Property(t => t.TamilSpeaking).HasMaxLength(100).IsOptional();
            Property(t => t.SalesExperience).IsOptional();
            Property(t => t.Brands).IsOptional();
            Property(t => t.OtherExperience).IsOptional();

            Property(t => t.Approved);
            Property(t => t.Deleted);
            Property(t => t.Banned);
            Property(t => t.Version);
        }
    }
}