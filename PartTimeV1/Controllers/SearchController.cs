using PartTimeV1.Data;
using System.Web.Mvc;

namespace PartTimeV1.Controllers
{
    [Authorize]
    public class SearchController : BaseController
    {
        public JsonResult GetUserProfileData()
        {
            var profiles = this.manager.UserProfileRepository.GetAllActive();
            var coordinatorProfiles = this.manager.CoordinatorProfileRepository.GetAllActive();

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
    }
}