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
            var query = from t in this.dbSet
                        where t.Finished == false & t.Deleted == false orderby t.CreateOn descending
                        select new DtoSchedulerEntity
                        {
                            Id = t.Id,
                            GigName = t.GigName,
                            CoordinatorName = t.CreatedId,
                            //Brands = t.Brands,
                            FromDate = SqlFunctions.DateName("day", t.FromDate) + "/" + SqlFunctions.DateName("month", t.FromDate) + "/" + SqlFunctions.DateName("year", t.FromDate),
                            ToDate = SqlFunctions.DateName("day", t.ToDate) + "/" + SqlFunctions.DateName("month", t.ToDate) + "/" + SqlFunctions.DateName("year", t.ToDate),
                            Location = t.Location,
                            Time = t.Time,
                            NumberOfDays = t.NumberOfDays,
                            Payment = t.Payment,
                            PromoterCount = t.PromoterCount,
                            Comments = t.Comments,
                            Mobile = t.Mobile,
                            Gender = t.Gender,
                            //District = t.District,
                            //Town = t.Town,
                        };
            return query;
        }

        public SchedulerEntity SelecEvent(long Id)
        {
            var query = this.dbSet.FirstOrDefault(a => a.Id == Id);
            return query;
        }
    }

    public class DtoSchedulerEntity
    {
        public long Id { get; set; }
        public string GigName { get; set; }
        //public string Brands { get; set; }
        public string CoordinatorName { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Location { get; set; }
      
        //public string District { get; set; }
        //public string Town { get; set; }
        public string Time { get; set; }
        public int NumberOfDays { get; set; }
        public string Payment { get; set; }
        public int PromoterCount { get; set; }
        public string Comments { get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
    }
}