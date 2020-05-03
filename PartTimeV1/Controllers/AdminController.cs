using System.Web.Mvc;

namespace PartTimeV1.Controllers
{
    public class AdminController : BaseController
    {
        public AdminController() : base()
        {
        }

        public ActionResult Index()
        {
            //ViewBag.MyList = this.manager.DropDownListsRepo.GetAllBrands();
            ViewBag.MyList1 = this.manager.DropDownListsRepo.GetAllTowns(2);
            return View();
        }

        [HttpPost]
        public ActionResult ProfileSubmit(Student std)
        {
            return View();
        }
    }

    public class Student
    {
        public string studentName { get; set; }
        public string studentAddress { get; set; }
    }
}