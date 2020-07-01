using System.Collections.Generic;
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

        public List<DtoUserProfileEntity> GetAllActive()
        {
            var query = from t in this.dbSet
                        where t.Banned != true & t.Deleted != true
                        orderby t.CreateOn
                        select new DtoUserProfileEntity
                        {
                            FullName = t.FullName,
                            NIC = t.NIC,
                            DOB = SqlFunctions.DateName("day", t.DOB) + "/" + SqlFunctions.DateName("month", t.DOB) + "/" + SqlFunctions.DateName("year", t.DOB),
                            Mobile = t.Mobile1,
                            Age = t.Age,
                            CurrentCity = t.CurrentDistrict,
                            HomeTown = t.HomeTown,
                            Role = t.Role == "User" ? "Promoter" : t.Role,
                            Approved = t.Approved.ToString(),
                            UserId = t.UserId
                        };
            return query.ToList();
        }

        public CoordinatorEntity SelectUser(string userId)
        {
            var query = this.dbSet.FirstOrDefault(a => a.UserId == userId);
            return query;
        }
    }
}
