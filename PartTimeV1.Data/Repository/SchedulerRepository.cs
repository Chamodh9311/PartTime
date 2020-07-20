using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;

namespace PartTimeV1.Data.Repository
{
    public class SchedulerRepository : EFRepository<SchedulerEntity>
    {
        public SchedulerRepository(EFDbContext dbContext)
             : base(dbContext)
        {
        }

        public IQueryable<DtoSchedulerEntity> GetAllActiveEvents()
        {
            var query = from t in this.dbSet where t.Finished == false orderby t.CreateOn descending
                        select new DtoSchedulerEntity
                        {
                            GigName = t.GigName,
                            Brands = t.Brands,
                            FromDate = SqlFunctions.DateName("day", t.FromDate) + "/" + SqlFunctions.DateName("month", t.FromDate) + "/" + SqlFunctions.DateName("year", t.FromDate),
                            ToDate = SqlFunctions.DateName("day", t.ToDate) + "/" + SqlFunctions.DateName("month", t.ToDate) + "/" + SqlFunctions.DateName("year", t.ToDate),
                            PromoterCount = t.PromoterCount,
                            District = t.District,
                            Town = t.Town,
                            Comments = t.Comments
                        };
            return query;
        }
    }

    public class DtoSchedulerEntity
    {
        public string GigName { get; set; }
        public string Brands { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int PromoterCount { get; set; }
        public string District { get; set; }
        public string Town { get; set; }
        public string Comments { get; set; }
    }
}