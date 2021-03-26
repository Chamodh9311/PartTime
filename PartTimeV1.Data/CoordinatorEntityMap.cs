﻿using System.Data.Entity.ModelConfiguration;

namespace PartTimeV1.Data
{
    public class CoordinatorEntityMap : EntityTypeConfiguration<CoordinatorEntity>
    {
        public CoordinatorEntityMap()
        {
            HasKey(t => t.Id);

            ToTable("CoordinatoProfile");

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
            Property(t => t.IsFreelancer);
            Property(t => t.Freelancer).HasMaxLength(200).IsOptional();
            Property(t => t.FreelancerOther).HasMaxLength(500).IsOptional();
            Property(t => t.IsSelfemployed);
            Property(t => t.Selfemployed).HasMaxLength(200).IsOptional();
            Property(t => t.SelfemployedOther).HasMaxLength(200).IsOptional();
            Property(t => t.PartTimePromoter);
            Property(t => t.EnglishA);
            Property(t => t.EnglishB);
            Property(t => t.EnglishC);
            Property(t => t.TamilA);
            Property(t => t.TamilB);
            Property(t => t.TamilC);
            Property(t => t.SalesExperienceNo);
            Property(t => t.SalesExperienceYes);
            Property(t => t.SalesExperienceYears).HasMaxLength(10).IsOptional();
            Property(t => t.Brands).HasMaxLength(200).IsOptional();
            Property(t => t.BrandsOther).HasMaxLength(500).IsOptional();
            Property(t => t.OtherExperience).HasMaxLength(200).IsOptional();
            Property(t => t.OtherExperienceOther).HasMaxLength(500).IsOptional();
            Property(t => t.PreviousAdvertisingCompany).HasMaxLength(500).IsOptional();
            Property(t => t.PreviousAdvertisingSupervisors).HasMaxLength(500).IsOptional();


            Property(t => t.AccountHolder).HasMaxLength(500).IsRequired(); 
            Property(t => t.AccountNumber).HasMaxLength(20).IsRequired();
            Property(t => t.Bank).HasMaxLength(200).IsRequired();
            Property(t => t.BankBranch).HasMaxLength(200).IsRequired();


            Property(t => t.UserId).HasMaxLength(200).IsRequired();
            Property(t => t.Role).HasMaxLength(20).IsRequired();
            Property(t => t.Approved).IsRequired();
            Property(t => t.Deleted).IsRequired();
            Property(t => t.Banned).IsRequired();
            Property(t => t.CreateOn).IsRequired();
            Property(t => t.Version).IsRequired();
        }
    }
}
