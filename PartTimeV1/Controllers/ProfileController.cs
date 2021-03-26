using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace PartTimeV1.Controllers
{
    [Authorize]
    public class ProfileController : BaseController
    {
        public ActionResult Index()
        {
            var coordinatorProfile  = this.manager.CoordinatorProfileRepository.SelectCoordinatorProfile(User.Identity.GetUserId());
            var promoterProfile = this.manager.PromoterProfileRepository.SelectUserProfile(User.Identity.GetUserId());

            if (coordinatorProfile != null)
            {
                return RedirectToAction("Profile");
            }
            else if (promoterProfile != null)
            {
                return RedirectToAction("Profile");
            }
            else
            {
                return RedirectToAction("Promoter");
            }
        }

        public ActionResult Promoter()
        {
            return View();
        }

        public ActionResult Coordinator()
        {
            return View();
        }

        public new ActionResult Profile()
        {
            return View();
        }
    }
}