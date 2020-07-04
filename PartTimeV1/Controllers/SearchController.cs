using PartTimeV1.Data;
using PartTimeV1.Data.Repository;
using PartTimeV1.Requests;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PartTimeV1.Controllers
{
    [Authorize]
    public class SearchController : BaseController
    {
        public JsonResult GetUserProfileData()
        {
            var profiles = this.manager.UserProfileRepository.GetAllActive().ToList();
            var coordinatorProfiles = this.manager.CoordinatorProfileRepository.GetAllActive().ToList();

            profiles.AddRange(coordinatorProfiles);

            return Json(new { data = profiles }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ApproveUser(string userId)
        {
            UserProfileEntity currentUserProfile = this.manager.UserProfileRepository.SelectUser(userId);

            if (currentUserProfile != null)
            {
                currentUserProfile.Approved = true;
                this.manager.UserProfileRepository.Update(currentUserProfile);
            }
            else
            {
                CoordinatorEntity currentCoordinatorProfile = this.manager.CoordinatorProfileRepository.SelectUser(userId);
                currentCoordinatorProfile.Approved = true;
                this.manager.CoordinatorProfileRepository.Update(currentCoordinatorProfile);
            }

            this.manager.Commit();

            return Json("Success");
        }

        public JsonResult BanUser(string userId)
        {
            UserProfileEntity currentUserProfile = this.manager.UserProfileRepository.SelectUser(userId);

            if (currentUserProfile != null)
            {
                currentUserProfile.Banned = true;
                this.manager.UserProfileRepository.Update(currentUserProfile);
            }
            else
            {
                CoordinatorEntity currentCoordinatorProfile = this.manager.CoordinatorProfileRepository.SelectUser(userId);
                currentCoordinatorProfile.Banned = true;
                this.manager.CoordinatorProfileRepository.Update(currentCoordinatorProfile);
            }

            this.manager.Commit();

            return Json("Success");
        }

        public JsonResult searchUsers(SearchRequest searchRequest , List<string> brands)
        {
            IQueryable<DtoUserProfileEntity> profiles = this.manager.UserProfileRepository.GetAllActive();

            if (searchRequest.FullName != null)
            {
                profiles = profiles.Where(p => searchRequest.FullName.Contains(p.FullName));
            }

            if (searchRequest.NIC != null)
            {
                profiles = profiles.Where(p => searchRequest.NIC.Contains(p.NIC));
            }

            if (searchRequest.Age != null)
            {
                profiles = profiles.Where(p => searchRequest.Age.Contains(p.Age));
            }

            //if (searchRequest.CurrentDistrict != null)
            //{
            //    profiles = profiles.Where(p => searchRequest.CurrentDistrict.Contains(p.CurrentDistrict));
            //}

            //if (searchRequest.CurrentTown != null)
            //{
            //    profiles = profiles.Where(p => searchRequest.CurrentTown.Contains(p.CurrentTown));
            //}

            //if (searchRequest.HomeDistrict != null)
            //{
            //    profiles = profiles.Where(p => searchRequest.HomeDistrict.Contains(p.HomeDistrict));
            //}

            if (searchRequest.HomeTown != null)
            {
                profiles = profiles.Where(p => searchRequest.HomeTown.Contains(p.HomeTown));
            }

            //if (searchRequest.Gender != null)
            //{
            //    profiles = profiles.Where(p => searchRequest.Gender.Contains(p.CurrentDistrict));
            //}

            //if (searchRequest.Age != null)
            //{
            //    profiles = profiles.Where(p => searchRequest.Age.Contains(p.Age));
            //}

            //if (searchRequest.CurrentDistrict != null)
            //{
            //    profiles = profiles.Where(p => searchRequest.CurrentDistrict.Contains(p.CurrentDistrict));
            //}

            //if (searchRequest.CurrentDistrict != null)
            //{
            //    profiles = profiles.Where(p => searchRequest.CurrentDistrict.Contains(p.CurrentDistrict));
            //}

            var profiles1 = profiles.ToList();





            IQueryable<DtoUserProfileEntity> coordinatorProfiles = this.manager.CoordinatorProfileRepository.GetAllActive();

            if (searchRequest.FullName != null)
            {
                coordinatorProfiles = coordinatorProfiles.Where(p => searchRequest.FullName.Contains(p.FullName));
            }

            if (searchRequest.NIC != null)
            {
                coordinatorProfiles = coordinatorProfiles.Where(p => searchRequest.NIC.Contains(p.NIC));
            }

            var coordinatorProfiles1 = coordinatorProfiles.ToList();

            profiles1.AddRange(coordinatorProfiles1);



            return Json(new { data = profiles1 }, JsonRequestBehavior.AllowGet);
        }
    }
}