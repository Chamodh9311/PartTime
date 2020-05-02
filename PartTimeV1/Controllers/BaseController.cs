using System.Web.Mvc;

namespace PartTimeV1.Controllers
{
    public class BaseController : Controller
    {
        protected static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        protected override void OnException(ExceptionContext filterContext)  
        {
            ViewResult view = new ViewResult();  
            view.ViewName = "Error";  
            filterContext.Result = view;  
            filterContext.ExceptionHandled = true;

            if (filterContext != null && filterContext.Exception != null)
            {
                Logger.Error(filterContext.Exception);
            }
        }
    }
}