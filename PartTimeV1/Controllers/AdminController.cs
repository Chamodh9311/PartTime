using System;
using System.Web.Mvc;

namespace PartTimeV1.Controllers
{
    public class AdminController : BaseController
    {
        public ActionResult Index()
        {
            try
            {
                throw new NullReferenceException();
                return View();
            }
            catch (Exception exp)
            {
                Logger.Error(exp, "Goodbye cruel world");
                throw exp;
            }
        
        }
    }
}