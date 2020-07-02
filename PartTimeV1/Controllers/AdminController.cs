using Microsoft.AspNet.Identity;
using PartTimeV1.Data;
using PartTimeV1.Requests;
using System;
using System.Web.Mvc;

namespace PartTimeV1.Controllers
{
    [Authorize]
    public class AdminController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }

        //[Authorize(Roles = "Coordinator , User")]
        public ActionResult Coordinator()
        {
            return View();
        }

        public ActionResult Calendar()
        {
            return View();
        }

        public ActionResult Users()
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
        public JsonResult GetUser(string userId)
        {
            var userProfile = this.manager.UserProfileRepository.SelectUserProfile(userId);
            return Json(userProfile, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UserProfileSubmit(ProfileRequest profileRequest)
        {
            try
            {
                UserProfileEntity userProfileEntity = new UserProfileEntity()
                {
                    FullName = profileRequest.FullName,
                    ShortName = profileRequest.ShortName,
                    NIC = profileRequest.NIC.Replace("_", ""),
                    Photo1 = profileRequest.Photo1,
                    Photo2 = profileRequest.Photo2,
                    Photo3 = profileRequest.Photo3,
                    Photo4 = profileRequest.Photo4,
                    Photo5 = profileRequest.Photo5,
                    Mobile1 = profileRequest.Mobile1,
                    Mobile1Whatsapp = profileRequest.Mobile1Whatsapp,
                    Mobile1Viber = profileRequest.Mobile1Viber,
                    Mobile2 = profileRequest.Mobile2,
                    Mobile2Whatsapp = profileRequest.Mobile2Whatsapp,
                    Mobile2Viber = profileRequest.Mobile2Viber,
                    Mobile3 = profileRequest.Mobile3,
                    Mobile3Whatsapp = profileRequest.Mobile3Whatsapp,
                    Mobile3Viber = profileRequest.Mobile3Viber,
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
                    IsFreelancer = profileRequest.IsFreelancer,
                    Freelancer = profileRequest.Freelancer,
                    FreelancerOther = profileRequest.FreelancerOther,
                    IsSelfemployed = profileRequest.IsSelfemployed,
                    Selfemployed = profileRequest.Selfemployed,
                    SelfemployedOther = profileRequest.SelfemployedOther,
                    PartTimePromoter = profileRequest.PartTimePromoter,
                    EnglishA = profileRequest.EnglishA,
                    EnglishB = profileRequest.EnglishB,
                    EnglishC = profileRequest.EnglishC,
                    TamilA = profileRequest.TamilA,
                    TamilB = profileRequest.TamilB,
                    TamilC = profileRequest.TamilC,
                    SalesExperienceNo = profileRequest.SalesExperienceNo,
                    SalesExperienceYes = profileRequest.SalesExperienceYes,
                    SalesExperienceYears = profileRequest.SalesExperienceYears == null ? null : profileRequest.SalesExperienceYears.Replace("_", ""),
                    Brands = profileRequest.Brands == null ? null : string.Join(",", profileRequest.Brands),
                    BrandsOther = profileRequest.BrandsOther,
                    OtherExperience = profileRequest.OtherExperience == null ? null : string.Join(",", profileRequest.OtherExperience),
                    OtherExperienceOther = profileRequest.OtherExperienceOther,
                    Facebook = profileRequest.Facebook,
                    Instagram = profileRequest.Instagram,
                    PartTimelkStaff = profileRequest.PartTimelkStaff,
                    PartTimelkStafName = profileRequest.PartTimelkStafName,
                    Cordinator = profileRequest.Cordinator,
                    CordinatorName = profileRequest.CordinatorName,
                    Friend = profileRequest.Friend,
                    Google = profileRequest.Google,

                    AccountHolder = profileRequest.AccountHolder,
                    AccountNumber = profileRequest.AccountNumber,
                    Bank = profileRequest.Bank,
                    BankBranch = profileRequest.BankBranch,

                    UserId = User.Identity.GetUserId(),
                    Role = "User",
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

            catch (Exception exp)
            {
                manager.Rollback();
                logger.Error(exp);

                return Json("Error", JsonRequestBehavior.AllowGet);

            }

            return Json("Saved", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CoordinatorProfileSubmit(CoordinatorRequest coordinatorRequest)
        {
            try
            {
                CoordinatorEntity coordinatorEntity = new CoordinatorEntity()
                {
                    FullName = coordinatorRequest.FullName,
                    ShortName = coordinatorRequest.ShortName,
                    NIC = coordinatorRequest.NIC.Replace("_",""),
                    Photo1 = coordinatorRequest.Photo1,
                    Photo2 = coordinatorRequest.Photo2,
                    Photo3 = coordinatorRequest.Photo3,
                    Photo4 = coordinatorRequest.Photo4,
                    Photo5 = coordinatorRequest.Photo5,
                    Mobile1 = coordinatorRequest.Mobile1,
                    Mobile1Whatsapp = coordinatorRequest.Mobile1Whatsapp,
                    Mobile1Viber = coordinatorRequest.Mobile1Viber,
                    Mobile2 = coordinatorRequest.Mobile2,
                    Mobile2Whatsapp = coordinatorRequest.Mobile2Whatsapp,
                    Mobile2Viber = coordinatorRequest.Mobile2Viber,
                    Mobile3 = coordinatorRequest.Mobile3,
                    Mobile3Whatsapp = coordinatorRequest.Mobile3Whatsapp,
                    Mobile3Viber = coordinatorRequest.Mobile3Viber,
                    DOB = DateTime.ParseExact(coordinatorRequest.DOB, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Age = coordinatorRequest.Age,

                    GenderMale = coordinatorRequest.GenderMale,
                    GenderFemale = coordinatorRequest.GenderFemale,
                    CurrentDistrict = coordinatorRequest.CurrentDistrict,
                    CurrentTown = coordinatorRequest.CurrentTown,
                    HomeDistrict = coordinatorRequest.HomeDistrict,
                    HomeTown = coordinatorRequest.HomeTown,
                    ShirtSizeS = coordinatorRequest.ShirtSizeS,
                    ShirtSizeM = coordinatorRequest.ShirtSizeM,
                    ShirtSizeL = coordinatorRequest.ShirtSizeL,
                    ShirtSizeXS = coordinatorRequest.ShirtSizeXS,
                    Student = coordinatorRequest.Student,
                    University = coordinatorRequest.University,
                    Course = coordinatorRequest.Course,
                    UniYear = coordinatorRequest.UniYear,
                    Employeed = coordinatorRequest.Employeed,
                    Company = coordinatorRequest.Company,
                    Branch = coordinatorRequest.Branch,
                    Designation = coordinatorRequest.Designation,
                    FullTimePromoter = coordinatorRequest.FullTimePromoter,
                    IsFreelancer = coordinatorRequest.IsFreelancer,
                    Freelancer = coordinatorRequest.Freelancer,
                    FreelancerOther = coordinatorRequest.FreelancerOther,
                    IsSelfemployed = coordinatorRequest.IsSelfemployed,
                    Selfemployed = coordinatorRequest.Selfemployed,
                    SelfemployedOther = coordinatorRequest.SelfemployedOther,
                    PartTimePromoter = coordinatorRequest.PartTimePromoter,
                    EnglishA = coordinatorRequest.EnglishA,
                    EnglishB = coordinatorRequest.EnglishB,
                    EnglishC = coordinatorRequest.EnglishC,
                    TamilA = coordinatorRequest.TamilA,
                    TamilB = coordinatorRequest.TamilB,
                    TamilC = coordinatorRequest.TamilC,
                    SalesExperienceNo = coordinatorRequest.SalesExperienceNo,
                    SalesExperienceYes = coordinatorRequest.SalesExperienceYes,
                    SalesExperienceYears = coordinatorRequest.SalesExperienceYears == null ? null : coordinatorRequest.SalesExperienceYears.Replace("_", ""),
                    Brands = coordinatorRequest.Brands == null ? null : string.Join(",", coordinatorRequest.Brands),
                    BrandsOther = coordinatorRequest.BrandsOther,
                    OtherExperience = coordinatorRequest.OtherExperience == null ? null : string.Join(",", coordinatorRequest.OtherExperience),
                    OtherExperienceOther = coordinatorRequest.OtherExperienceOther,
                    PreviousAdvertisingCompany = coordinatorRequest.PreviousAdvertisingCompany,
                    PreviousAdvertisingSupervisors = coordinatorRequest.PreviousAdvertisingSupervisors,

                    AccountHolder = coordinatorRequest.AccountHolder,
                    AccountNumber = coordinatorRequest.AccountNumber,
                    Bank = coordinatorRequest.Bank,
                    BankBranch = coordinatorRequest.BankBranch,

                    UserId = User.Identity.GetUserId(),
                    Role = "Coordinator",
                    Approved = false,
                    Deleted = false,
                    Banned = false,
                    CreateOn = DateTime.Now,
                    Version = 1
                };

                manager.BeginTransaction();

                manager.CoordinatorProfileRepository.Add(coordinatorEntity);

                manager.Commit();
            }

            catch (Exception exp)
            {
                manager.Rollback();
                logger.Error(exp);

                return Json("Error", JsonRequestBehavior.AllowGet);

            }

            return Json("Saved", JsonRequestBehavior.AllowGet);
        }
    }
}