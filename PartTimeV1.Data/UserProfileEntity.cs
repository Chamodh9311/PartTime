using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PartTimeV1.Data
{
    public class UserProfileEntity : Entity
    {
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string NIC { get; set; }
        public string Photo1 { get; set; }
        public string Photo2 { get; set; }
        public string Photo3 { get; set; }
        public string Photo4 { get; set; }
        public string Photo5 { get; set; }
        public string Mobile1 { get; set; }
        public bool Mobile1Whatsapp { get; set; }
        public bool Mobile1Viber { get; set; }
        public string Mobile2 { get; set; }
        public bool Mobile2Whatsapp { get; set; }
        public bool Mobile2Viber { get; set; }
        public string Mobile3 { get; set; }
        public bool Mobile3Whatsapp { get; set; }
        public bool Mobile3Viber { get; set; }
        public DateTime DOB { get; set; }
        public string Age { get; set; }

        public bool GenderMale { get; set; }
        public bool GenderFemale { get; set; }
        public string CurrentDistrict { get; set; }
        public string CurrentTown { get; set; }
        public string HomeDistrict { get; set; }
        public string HomeTown { get; set; }
        public bool ShirtSizeS { get; set; }
        public bool ShirtSizeM { get; set; }
        public bool ShirtSizeL { get; set; }
        public bool ShirtSizeXS { get; set; }
        public bool IamStudent { get; set; }
        public string University { get; set; }
        public string Course { get; set; }
        public string UniYear { get; set; }
        public bool IamFullTimeEmployeed { get; set; }
        public string Company { get; set; }
        public string Branch { get; set; }
        public string Designation { get; set; }
        public bool IamFullTimePromoter { get; set; }
        public bool IamFreelancer { get; set; }
        public string FreelancerJobs { get; set; }
        public string FreelancerOtherJobs { get; set; }
        public bool IamProfessionalSelfemployed { get; set; }
        public string SelfemployedJobs { get; set; }
        public string SelfemployedOtherJobs { get; set; }
        public bool IamLookingForPartTimePromotes { get; set; }
        public bool EnglishA { get; set; }
        public bool EnglishB { get; set; }
        public bool EnglishC { get; set; }
        public bool TamilA { get; set; }
        public bool TamilB { get; set; }
        public bool TamilC { get; set; }
        public bool SalesExperienceNo  { get; set; }
        public bool SalesExperienceYes { get; set; }
        public string SalesExperienceYears { get; set; }
        public string MainBrands { get; set; }
        public string MainBrandsOthers { get; set; }
        public string OtherBrandExperience { get; set; }
        public string OtherBarndExperienceOther { get; set; }
        public bool Facebook { get; set; }
        public bool Instagram { get; set; }
        public bool PartTimelkStaff { get; set; }
        public string PartTimelkStafName { get; set; }
        public bool Cordinator { get; set; }
        public string CordinatorName { get; set; }
        public bool Friend { get; set; }
        public bool Google { get; set; }

        //Bank Details
        public string AccountHolder { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string UserId { get; set; }
        public string Role { get; set; }
        public bool Approved { get; set; }
        public bool Deleted { get; set; }
        public bool Banned { get; set; }
        public DateTime CreateOn { get; set; }
        public int Version { get; set; }

        public string ProfilePictureComments { get; set; }
    }
}
