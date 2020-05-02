using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartTimeV1.Controllers
{
    public class AdminController : Controller
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // GET: Admin
        public ActionResult Index()
        {
            Logger.Error("Goodbye cruel world");
            return View();
        }
    }
}