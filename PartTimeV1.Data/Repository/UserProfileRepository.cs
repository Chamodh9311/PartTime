using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartTimeV1.Data.Repository
{
    public class UserProfileRepository : EFRepository<UserProfileEntity>
    {
        public UserProfileRepository(EFDbContext dbContext)
             : base(dbContext)
        {
        }

        public List<UserProfileEntity> GetAllActive()
        {
            var query = (from t in this.dbSet where t.Approved == false orderby t.CreateOn select t );
            return query.ToList();
        }
    }
}