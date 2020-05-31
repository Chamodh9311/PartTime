using System.Web.Mvc;

namespace PartTimeV1.Controllers
{

    //[Authorize(Roles = "SuperAdmin , Admin , User")]
    //[Authorize]
    public class SearchController : BaseController
    {
        public JsonResult GetUserProfileData()
        {
            var profiles = this.manager.UserProfileRepository.GetAllActive();
            return Json(new { data = profiles }, JsonRequestBehavior.AllowGet);
        }
    }
}