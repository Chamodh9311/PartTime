﻿using System.Collections.Generic;
using System.Linq;

namespace PartTimeV1.Data.Repository
{
    public class UserProfileRepository : EFRepository<UserProfileEntity>
    {
        public UserProfileRepository(EFDbContext dbContext)
             : base(dbContext)
        {
        }

        public List<DtoUserProfileEntity> GetAllActive()
        {
            var query = from t in this.dbSet where t.Approved == false orderby t.CreateOn 
                        select new DtoUserProfileEntity
                        { FullName = t.FullName, NIC = t.NIC , DOB = t.DOB.ToString() , Mobile = t.Mobile1 , Age = t.Age , CurrentCity = t.CurrentDistrict, HomeTown = t.HomeTown , Role = t.Role } ;
            return query.ToList();
        }
    }

    public class DtoUserProfileEntity
    {
        public string FullName { get; set; }
        public string NIC { get; set; }
        public string DOB { get; set; }
        public string Mobile { get; set; }
        public string Age { get; set; }
        public string CurrentCity { get; set; }
        public string HomeTown { get; set; }
        public string Role { get; set; }
    }
}