using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace PartTimeV1.Data.Repository
{
    public class DropDownListsRepo : EFRepository<BrandsListsEntity>
    {
        public DropDownListsRepo(EFDbContext dbContext)
             : base(dbContext)
        {
        }

        public List<BrandsListsEntity> GetAllBrands()
        {
            var query = (from t in this.dbSet orderby t.Brand select t);
            return query.ToList();
        }

        public List<DistrictsEntityDTO> GetAllDistricts()
        {
            var query = this.dbContext.Database.SqlQuery<DistrictsEntityDTO>("SELECT * FROM Districts ORDER BY Name").ToList(); 
            return query;
        }

        public List<TownsEntityDTO> GetAllTowns(int districtId)
        {
            SqlParameter param;
            param = new SqlParameter("@value", districtId);
            var query = this.dbContext.Database.SqlQuery<TownsEntityDTO>("SELECT Id,DistrictId,Name FROM Cities WHERE DistrictId = @value ORDER BY Name", param).ToList();
            return query;
        }
    }

    public class DistrictsEntityDTO
    {
        public int DistrictId { get; set; }
        public int ProvinceId { get; set; }
        public string Name { get; set; }
    }

    public class TownsEntityDTO
    {
        public int Id { get; set; }
        public int DistrictId { get; set; }
        public string Name { get; set; }
    }
}

