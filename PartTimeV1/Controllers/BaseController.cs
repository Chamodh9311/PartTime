using PartTimeV1.Data.RepositoryManager;
using System.Web.Mvc;

namespace PartTimeV1.Controllers
{
    public class BaseController : Controller
    {
        protected static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        protected RepoManager manager = null;

        public BaseController()
        {
            this.manager = new RepoManager();
        }


        protected override void OnException(ExceptionContext filterContext)  
        {
            ViewResult view = new ViewResult();  
            view.ViewName = "Error";  
            filterContext.Result = view;  
            filterContext.ExceptionHandled = true;

            if (filterContext != null && filterContext.Exception != null)
            {
                logger.Error(filterContext.Exception);
            }
        }
    }
}