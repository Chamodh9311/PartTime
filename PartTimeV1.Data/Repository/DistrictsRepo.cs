using System.Collections.Generic;
using System.Linq;

namespace PartTimeV1.Data.Repository
{
    public class DistrictsRepo : EFRepository<DistrictsEntity>
    {
        public DistrictsRepo(EFDbContext dbContext)
             : base(dbContext)
        {
        }

        public List<DistrictsEntity> GetAll()
        {
            var query = (from t in this.dbSet orderby t.DistrictId select t);
            return query.ToList();
        }
    }
}
