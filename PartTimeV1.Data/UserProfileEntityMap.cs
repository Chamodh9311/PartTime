using System.Data.Entity.ModelConfiguration;

namespace PartTimeV1.Data
{
    public class UserProfileEntityMap : EntityTypeConfiguration<UserProfileEntity>
    {
        public UserProfileEntityMap()
        {
            HasKey(t => t.Id);

            ToTable("UserProfile");

            Property(t => t.FullName);
            Property(t => t.ShortName);
            Property(t => t.NIC);
            Property(t => t.Photo1);
            Property(t => t.Photo2);
            Property(t => t.Photo3);
            Property(t => t.Photo4).IsOptional();
            Property(t => t.Photo5).IsOptional();
            Property(t => t.FullName);
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
            Property(t => t.CurrentDistrict);
            Property(t => t.CurrentTown);
            Property(t => t.HomeDistrict);
            Property(t => t.HomeTown);
            Property(t => t.ShirtSizeS);
            Property(t => t.ShirtSizeM);
            Property(t => t.ShirtSizeL);
            Property(t => t.ShirtSizeXS);
            Property(t => t.Student).IsOptional();
            Property(t => t.University).IsOptional();
            Property(t => t.Course).IsOptional();
            Property(t => t.UniYear).IsOptional();
            Property(t => t.Employeed).IsOptional();
            Property(t => t.Company).IsOptional();
            Property(t => t.Branch).IsOptional();
            Property(t => t.Designation).IsOptional();
            Property(t => t.FullTimePromoter).IsOptional();
            Property(t => t.PartTimePromoter).IsOptional();
            Property(t => t.EnglishSpeaking).IsOptional();
            Property(t => t.TamilSpeaking).IsOptional();
            Property(t => t.SalesExperience).IsOptional();
            Property(t => t.Brands).IsOptional();
            Property(t => t.OtherExperience).IsOptional();

            Property(t => t.Approved).IsOptional();
            Property(t => t.Deleted).IsOptional();
            Property(t => t.Banned).IsOptional();
            Property(t => t.Version).IsOptional();

        }
    }
}