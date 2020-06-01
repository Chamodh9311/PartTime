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
    }
}