using System.Web.Mvc;

namespace PartTimeV1.Controllers
{
    public class AdminController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetDistricts()
        {
            var districts = this.manager.DropDownListsRepo.GetAllDistricts();
            return Json(districts, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTowns(int districtId)
        {
            var towns = this.manager.DropDownListsRepo.GetAllTowns(districtId);
            return Json(towns, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBrands()
        {
            var brands = this.manager.DropDownListsRepo.GetAllBrands();
            return Json(brands, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public ActionResult ProfileSubmit(Student std)
        //{
        //    return View();
        //}
    }
}