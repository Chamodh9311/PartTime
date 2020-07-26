using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PartTimeV1.Data;
using PartTimeV1.Requests;
using System;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PartTimeV1.Controllers
{
    [Authorize]
    public class AdminController : BaseController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AdminController()
        {
        }

        public AdminController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult LogOut()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            //FormsAuthentication.SignOut();
            //Session.Abandon(); 
            //HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Schedule()
        {
            return View();
        }

        //[Authorize(Roles = "Admin , Coordinator")]
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
            if (userId == null)
            {
                userId = User.Identity.GetUserId();
            }
            var userProfile = this.manager.PromoterProfileRepository.SelectUserProfile(userId);

            return Json(userProfile, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetUserProfile(string userId)
        {
            if (userId == null)
            {
                userId = User.Identity.GetUserId();
            }

            var userProfile = this.manager.PromoterProfileRepository.SelectUserProfile(userId);

            if (userProfile == null)
            {
                var coordinatorProfile = this.manager.PromoterProfileRepository.SelectUserProfile(userId);
            }

            return Json(userProfile, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult UserProfileSubmit(ProfileRequest profileRequest)
        {
            try
            {
                //updatePromotorProfile(ProfileRequest profileRequest);

                PromoterProfileEntity promoterProfileEntity = new PromoterProfileEntity()
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
                    IamStudent = profileRequest.Student,
                    University = profileRequest.University,
                    Course = profileRequest.Course,
                    UniYear = profileRequest.UniYear,
                    IamFullTimeEmployeed = profileRequest.Employeed,
                    Company = profileRequest.Company,
                    Branch = profileRequest.Branch,
                    Designation = profileRequest.Designation,
                    IamFullTimePromoter = profileRequest.FullTimePromoter,
                    IamFreelancer = profileRequest.IsFreelancer,
                    FreelancerJobs = profileRequest.Freelancer,
                    FreelancerOtherJobs = profileRequest.FreelancerOther,
                    IamProfessionalSelfemployed = profileRequest.IsSelfemployed,
                    SelfemployedJobs = profileRequest.Selfemployed,
                    SelfemployedOtherJobs = profileRequest.SelfemployedOther,
                    IamLookingForPartTimePromotes = profileRequest.PartTimePromoter,
                    EnglishA = profileRequest.EnglishA,
                    EnglishB = profileRequest.EnglishB,
                    EnglishC = profileRequest.EnglishC,
                    TamilA = profileRequest.TamilA,
                    TamilB = profileRequest.TamilB,
                    TamilC = profileRequest.TamilC,
                    SalesExperienceNo = profileRequest.SalesExperienceNo,
                    SalesExperienceYes = profileRequest.SalesExperienceYes,
                    SalesExperienceYears = profileRequest.SalesExperienceYears == null ? null : profileRequest.SalesExperienceYears.Replace("_", ""),
                    MainBrands = profileRequest.Brands == null ? null : string.Join(",", profileRequest.Brands),
                    MainBrandsOthers = profileRequest.BrandsOther,
                    OtherBrandExperience = profileRequest.OtherExperience == null ? null : string.Join(",", profileRequest.OtherExperience),
                    OtherBarndExperienceOther = profileRequest.OtherExperienceOther,
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
                    BankName = profileRequest.Bank,
                    BankBranch = profileRequest.BankBranch,

                    ProfilePictureComments = profileRequest.ProfilePictureComments,

                    UserId = User.Identity.GetUserId(),
                    Role = "User",
                    Approved = false,
                    Deleted = false,
                    Banned = false,
                    CreateOn = DateTime.Now,
                    Version = 1
                };

                manager.BeginTransaction();

                manager.PromoterProfileRepository.Add(promoterProfileEntity);

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
                var userId = User.Identity.GetUserId();
                var user = UserManager.FindById(userId);

                if (UserManager.IsInRole(user.Id, "User"))
                {
                    UserManager.RemoveFromRole(userId, "User");
                    UserManager.AddToRole(userId, "Coordinator");
                }

                CoordinatorEntity coordinatorEntity = new CoordinatorEntity()
                {
                    FullName = coordinatorRequest.FullName,
                    ShortName = coordinatorRequest.ShortName,
                    NIC = coordinatorRequest.NIC.Replace("_", ""),
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
                    IamStudent = coordinatorRequest.Student,
                    University = coordinatorRequest.University,
                    Course = coordinatorRequest.Course,
                    UniYear = coordinatorRequest.UniYear,
                    IamFullTimeEmployeed = coordinatorRequest.Employeed,
                    Company = coordinatorRequest.Company,
                    Branch = coordinatorRequest.Branch,
                    Designation = coordinatorRequest.Designation,
                    IamFullTimePromoter = coordinatorRequest.FullTimePromoter,
                    IamFreelancer = coordinatorRequest.IsFreelancer,
                    FreelancerJobs = coordinatorRequest.Freelancer,
                    FreelancerOtherJobs = coordinatorRequest.FreelancerOther,
                    IamProfessionalSelfemployed = coordinatorRequest.IsSelfemployed,
                    SelfemployedJobs = coordinatorRequest.Selfemployed,
                    SelfemployedOtherJobs = coordinatorRequest.SelfemployedOther,
                    IamLookingForPartTimePromotes = coordinatorRequest.PartTimePromoter,
                    EnglishA = coordinatorRequest.EnglishA,
                    EnglishB = coordinatorRequest.EnglishB,
                    EnglishC = coordinatorRequest.EnglishC,
                    TamilA = coordinatorRequest.TamilA,
                    TamilB = coordinatorRequest.TamilB,
                    TamilC = coordinatorRequest.TamilC,
                    SalesExperienceNo = coordinatorRequest.SalesExperienceNo,
                    SalesExperienceYes = coordinatorRequest.SalesExperienceYes,
                    SalesExperienceYears = coordinatorRequest.SalesExperienceYears == null ? null : coordinatorRequest.SalesExperienceYears.Replace("_", ""),
                    MainBrands = coordinatorRequest.Brands == null ? null : string.Join(",", coordinatorRequest.Brands),
                    MainBrandsOthers = coordinatorRequest.BrandsOther,
                    OtherBrandExperience = coordinatorRequest.OtherExperience == null ? null : string.Join(",", coordinatorRequest.OtherExperience),
                    OtherBarndExperienceOther = coordinatorRequest.OtherExperienceOther,
                    PreviousAdvertisingCompany = coordinatorRequest.PreviousAdvertisingCompany,
                    PreviousAdvertisingSupervisors = coordinatorRequest.PreviousAdvertisingSupervisors,

                    AccountHolder = coordinatorRequest.AccountHolder,
                    AccountNumber = coordinatorRequest.AccountNumber,
                    BankName = coordinatorRequest.Bank,
                    BankBranch = coordinatorRequest.BankBranch,

                    ProfilePictureComments = coordinatorRequest.ProfilePictureComments,

                    UserId = userId,
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