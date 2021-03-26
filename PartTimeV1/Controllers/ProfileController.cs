using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartTimeV1.Controllers
{
    [Authorize]
    public class ProfileController : BaseController
    {
        public ActionResult Index()
        {
            var userProfile = this.manager.PromoterProfileRepository.SelectUserProfile(User.Identity.GetUserId());

            if (userProfile != null)
            {
                var coordinatorProfile = this.manager.CoordinatorProfileRepository.SelectCoordinatorProfile(User.Identity.GetUserId());

                if (coordinatorProfile != null)
                {
                    return RedirectToAction("Profile");
                }

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

        public ActionResult Profile()
        {
            return View();
        }
    }
}