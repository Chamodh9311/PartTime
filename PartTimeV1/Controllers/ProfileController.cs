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
            var userProfile = this.manager.UserProfileRepository.SelectUserProfile(User.Identity.GetUserId());

            if (userProfile != null)
            {
                return RedirectToAction("Promoter");
            }

            var coordinatorProfile = this.manager.CoordinatorProfileRepository.SelectCoordinatorProfile(User.Identity.GetUserId());

            return RedirectToAction("Coordinator");
        }

        public ActionResult Promoter()
        {

            return View();
        }

        public ActionResult Coordinator()
        {

            return View();
        }
    }
}