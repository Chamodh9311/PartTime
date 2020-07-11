using System.Data.Entity.SqlServer;
using System.Linq;

namespace PartTimeV1.Data.Repository
{
    public class CoordinatorProfileRepository : EFRepository<CoordinatorEntity>
    {
        public CoordinatorProfileRepository(EFDbContext dbContext)
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

        public CoordinatorEntity SelectUser(string userId)
        {
            var query = this.dbSet.FirstOrDefault(a => a.UserId == userId);
            return query;
        }
    }
}
