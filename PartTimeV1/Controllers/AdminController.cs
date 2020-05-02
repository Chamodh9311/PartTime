using System;
using System.Web.Mvc;

namespace PartTimeV1.Controllers
{
    public class AdminController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}