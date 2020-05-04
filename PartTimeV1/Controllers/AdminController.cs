using PartTimeV1.Data;
using PartTimeV1.Requests;
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

        [HttpPost]
        public JsonResult ProfileSubmit(ProfileRequest profileRequest)
        {
            try
            {
                UserProfileEntity userProfileEntity = new UserProfileEntity()
                {
                    FullName = profileRequest.FullName,
                    ShortName = profileRequest.ShortName,
                    NIC = profileRequest.NIC,
                    Photo1 = profileRequest.Photo1,
                    Photo2 = profileRequest.Photo2,
                    Photo3 = profileRequest.Photo3,
                    Photo4 = profileRequest.Photo4,
                    Photo5 = profileRequest.Photo5,

                    //Mobile1 = 
                };

                manager.BeginTransaction();

                manager.UserProfileRepository.Add(userProfileEntity);

                manager.Commit();
            }
            catch (System.Exception exp)
            {
                manager.Rollback();
                logger.Error(exp);

                return Json("Error", JsonRequestBehavior.AllowGet);

            }

            return Json("Saved", JsonRequestBehavior.AllowGet);
        }
    }
}