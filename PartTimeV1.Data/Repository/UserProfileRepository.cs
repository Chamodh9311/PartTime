using System;
using System.Collections.Generic;
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
    }
}