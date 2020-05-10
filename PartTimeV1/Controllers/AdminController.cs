using PartTimeV1.Data;
using PartTimeV1.Requests;
using System;
using System.Web.Mvc;

namespace PartTimeV1.Controllers
{

    //[Authorize(Roles = "SuperAdmin , Admin , User")]
    [Authorize]
    public class AdminController : BaseController
    {

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Users()
        {
            return View();
        }

        public JsonResult GetUserProfileData()
        {
            var profiles = this.manager.UserProfileRepository.GetAllActive();
            return Json(new { data = profiles }, JsonRequestBehavior.AllowGet);
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
                    Mobile1 = profileRequest.Mobile1,
                    Mobile1Whatsapp = profileRequest.Mobile1Whatsapp,
                    Mobile1Viber = profileRequest.Mobile1Viber,
                    Mobile2 = profileRequest.Mobile2,
                    Mobile3Whatsapp = profileRequest.Mobile2Whatsapp,
                    Mobile3Viber = profileRequest.Mobile2Viber,
                    Mobile3 = profileRequest.Mobile3,

                    DOB = DateTime.ParseExact(profileRequest.DOB, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Age = profileRequest.Age,
                    GenderMale = profileRequest.GenderMale,
                    GenderFemale = profileRequest.GenderFemale,
                    CurrentDistrict = profileRequest.CurrentDistrict,
                    CurrentTown = profileRequest.CurrentTown,
                    HomeDistrict = profileRequest.HomeDistrict,
                    HomeTown = profileRequest.HomeTown,
                    ShirtSizeS = profileRequest.ShirtSizeS,
                    ShirtSizeM = profileRequest.ShirtSizeM,
                    ShirtSizeL = profileRequest.ShirtSizeL,
                    ShirtSizeXS = profileRequest.ShirtSizeXS,
                    Student = profileRequest.Student,
                    University = profileRequest.University,
                    Course = profileRequest.Course,
                    UniYear = profileRequest.UniYear,
                    Employeed = profileRequest.Employeed,
                    Company = profileRequest.Company,
                    Branch = profileRequest.Branch,
                    Designation = profileRequest.Designation,
                    FullTimePromoter = profileRequest.FullTimePromoter,
                    PartTimePromoter = profileRequest.PartTimePromoter,
                    EnglishA = profileRequest.EnglishA,
                    EnglishB = profileRequest.EnglishB,
                    EnglishC = profileRequest.EnglishC,
                    TamilA = profileRequest.TamilA,
                    TamilB = profileRequest.TamilB,
                    TamilC = profileRequest.TamilC,
                    SalesExperience = profileRequest.SalesExperience,
                    Brands = profileRequest.Brands == null ? null : string.Join(",", profileRequest.Brands),
                    OtherExperience = profileRequest.OtherExperience == null ? null : string.Join(",", profileRequest.OtherExperience),

                    Approved = false,
                    Deleted = false,
                    Banned = false,
                    CreateOn = DateTime.Now,
                    Version = 1

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