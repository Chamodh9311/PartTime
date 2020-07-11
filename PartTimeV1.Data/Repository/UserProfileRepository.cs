using System.Data.Entity.SqlServer;
using System.Data.SqlClient;
using System.Linq;

namespace PartTimeV1.Data.Repository
{
    public class UserProfileRepository : EFRepository<UserProfileEntity>
    {
        public UserProfileRepository(EFDbContext dbContext)
             : base(dbContext)
        {
        }

        public IQueryable<DtoUserProfileEntity> GetAllActive()
        {
            var query = from t in this.dbSet
                            //where t.Banned != true & t.Deleted != true
                        orderby t.CreateOn
                        select new DtoUserProfileEntity
                        {
                            FullName = t.FullName,
                            NIC = t.NIC,
                            DOB = SqlFunctions.DateName("day", t.DOB) + "/" + SqlFunctions.DateName("month", t.DOB) + "/" + SqlFunctions.DateName("year", t.DOB),
                            Mobile = t.Mobile1,
                            Age = t.Age,
                            CurrentCity = t.CurrentTown,
                            CurrentDisctrict = t.CurrentDistrict,
                            HomeDisctrict = t.HomeDistrict,
                            HomeTown = t.HomeTown,
                            GenderFemale = t.GenderFemale,
                            GenderMale = t.GenderMale,
                            YearsOfSales = t.SalesExperienceYears,
                            EnglishSpeakingA = t.EnglishA,
                            EnglishSpeakingB = t.EnglishB,
                            EnglishSpeakingC = t.EnglishC,
                            TamilSpeakinA = t.TamilA,
                            TamilSpeakinB = t.TamilB,
                            TamilSpeakinC = t.TamilC,
                            Student = t.IamStudent,
                            FullTimeEmployed = t.IamFullTimeEmployeed,
                            FullTimePromotor = t.IamFullTimePromoter,
                            Freelancer = t.IamFreelancer,
                            Professional = t.IamProfessionalSelfemployed,
                            SearchForParttime = t.IamLookingForPartTimePromotes,
                            Brands = t.MainBrands,
                            Role = t.Role == "User" ? "Promoter" : t.Role,
                            Approved = t.Approved.ToString(),
                            UserId = t.UserId
                        };
           
            return query;
        }

        public UserProfileEntity SelectUser(string userId)
        {
            var query = this.dbSet.FirstOrDefault(a => a.UserId == userId );
            return query;
        }

        public UserProfileEntity SelectUserProfile(string userId)
        {
            SqlParameter param;
            param = new SqlParameter("@value", userId);
            var query = this.dbContext.Database.SqlQuery<UserProfileEntity>("SELECT FORMAT(dob,'dd/MM/yyyy') as 'DOBNEW', * FROM UserProfile WHERE UserId = @value order by Id", param).FirstOrDefault();
            return query;
        }
    }

    public class DtoUserProfileEntity
    {
        public string FullName { get; set; }
        public string NIC { get; set; }
        public string DOB { get; set; }
        public string Mobile { get; set; }
        public string Age { get; set; }
        public string CurrentDisctrict { get; set; }
        public string CurrentCity { get; set; }
        public string HomeTown { get; set; }
        public string HomeDisctrict { get; set; }
        public string Role { get; set; }
        public string Approved  { get; set; }
        public string UserId { get; set; }

        public bool GenderMale { get; set; }
        public bool GenderFemale { get; set; }
        public string YearsOfSales { get; set; }
        public bool Student { get; set; }
        public bool FullTimeEmployed { get; set; }
        public bool FullTimePromotor { get; set; }
        public bool Freelancer { get; set; }
        public bool Professional { get; set; }
        public bool SearchForParttime { get; set; }

        public bool EnglishSpeakingA { get; set; }
        public bool EnglishSpeakingB { get; set; }
        public bool EnglishSpeakingC { get; set; }
        public bool TamilSpeakinA { get; set; }
        public bool TamilSpeakinB { get; set; }
        public bool TamilSpeakinC { get; set; }
        public string Calander { get; set; }
        public string Look { get; set; }

        public string Brands { get; set; }
    }
}