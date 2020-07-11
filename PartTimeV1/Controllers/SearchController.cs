using PartTimeV1.Data;
using PartTimeV1.Data.Repository;
using PartTimeV1.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PartTimeV1.Controllers
{
    [Authorize]
    public class SearchController : BaseController
    {
        public JsonResult GetUserProfileData()
        {
            var profiles = this.manager.UserProfileRepository.GetAllActive().ToList();
            var coordinatorProfiles = this.manager.CoordinatorProfileRepository.GetAllActive().ToList();

            profiles.AddRange(coordinatorProfiles);

            return Json(new { data = profiles }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ApproveUser(string userId)
        {
            UserProfileEntity currentUserProfile = this.manager.UserProfileRepository.SelectUser(userId);

            if (currentUserProfile != null)
            {
                currentUserProfile.Approved = true;
                this.manager.UserProfileRepository.Update(currentUserProfile);
            }
            else
            {
                CoordinatorEntity currentCoordinatorProfile = this.manager.CoordinatorProfileRepository.SelectUser(userId);
                currentCoordinatorProfile.Approved = true;
                this.manager.CoordinatorProfileRepository.Update(currentCoordinatorProfile);
            }

            this.manager.Commit();

            return Json("Success");
        }

        public JsonResult BanUser(string userId)
        {
            UserProfileEntity currentUserProfile = this.manager.UserProfileRepository.SelectUser(userId);

            if (currentUserProfile != null)
            {
                currentUserProfile.Banned = true;
                this.manager.UserProfileRepository.Update(currentUserProfile);
            }
            else
            {
                CoordinatorEntity currentCoordinatorProfile = this.manager.CoordinatorProfileRepository.SelectUser(userId);
                currentCoordinatorProfile.Banned = true;
                this.manager.CoordinatorProfileRepository.Update(currentCoordinatorProfile);
            }

            this.manager.Commit();

            return Json("Success");
        }

        public JsonResult searchUsers(SearchRequest searchRequest , List<string> brands)
        {
            IQueryable<DtoUserProfileEntity> profiles = this.manager.UserProfileRepository.GetAllActive();

            if (searchRequest.FullName != null)
            {
                profiles = profiles.Where(p => searchRequest.FullName.Contains(p.FullName));
            }

            if (searchRequest.NIC != null)
            {
                profiles = profiles.Where(p => searchRequest.NIC.Contains(p.NIC));
            }

            if (searchRequest.Age != null)
            {
                profiles = profiles.Where(p => searchRequest.Age.Contains(p.Age));
            }

            if (searchRequest.CurrentDistrict != null)
            {
                profiles = profiles.Where(p => searchRequest.CurrentDistrict.Contains(p.CurrentDisctrict));
            }

            if (searchRequest.CurrentTown != null)
            {
                profiles = profiles.Where(p => searchRequest.CurrentTown.Contains(p.CurrentCity));
            }

            if (searchRequest.HomeDistrict != null)
            {
                profiles = profiles.Where(p => searchRequest.HomeDistrict.Contains(p.HomeDisctrict));
            }

            if (searchRequest.HomeTown != null)
            {
                profiles = profiles.Where(p => searchRequest.HomeTown.Contains(p.HomeTown));
            }

            if (searchRequest.Gender != null)
            {
                if (searchRequest.Gender == "1")
                {
                    profiles = profiles.Where(p => p.GenderMale == true);
                }
                if (searchRequest.Gender == "2")
                {
                    profiles = profiles.Where(p => p.GenderFemale == true);
                }
            }

            if (searchRequest.SalesYears != null)
            {
                profiles = profiles.Where(p => searchRequest.SalesYears.Contains(p.YearsOfSales));
            }

            if (searchRequest.English != null)
            {
                if (searchRequest.English == "1")
                {
                    profiles = profiles.Where(p => p.EnglishSpeakingA == true);
                }
                if (searchRequest.English == "2")
                {
                    profiles = profiles.Where(p => p.EnglishSpeakingB == true);
                }
                if (searchRequest.English == "3")
                {
                    profiles = profiles.Where(p => p.EnglishSpeakingC == true);
                }
            }

            if (searchRequest.Tamil != null)
            {
                if (searchRequest.English == "1")
                {
                    profiles = profiles.Where(p => p.TamilSpeakinA == true);
                }
                if (searchRequest.English == "2")
                {
                    profiles = profiles.Where(p => p.TamilSpeakinB == true);
                }
                if (searchRequest.English == "3")
                {
                    profiles = profiles.Where(p => p.TamilSpeakinC == true);
                }
            }

            if (searchRequest.Iam != null)
            {
                if (searchRequest.Iam == "1")
                {
                    profiles = profiles.Where(p => p.Student == true);
                }
                if(searchRequest.Iam == "2")
                {
                    profiles = profiles.Where(p => p.FullTimeEmployed == true);
                }
                if(searchRequest.Iam == "3")
                {
                    profiles = profiles.Where(p => p.FullTimePromotor == true);
                }
                if(searchRequest.Iam == "4")
                {
                    profiles = profiles.Where(p => p.Freelancer == true);
                }
                if(searchRequest.Iam == "5")
                {
                    profiles = profiles.Where(p => p.Professional == true);
                }
                if (searchRequest.Iam == "6")
                {
                    profiles = profiles.Where(p => p.SearchForParttime == true);
                }
            }

            //if (searchRequest.Calendar != null)
            //{
            //    profiles = profiles.Where(p => searchRequest.CurrentDistrict.Contains(p.CurrentDistrict));
            //}

            //if (searchRequest.Look != null)
            //{
            //    profiles = profiles.Where(p => searchRequest.CurrentDistrict.Contains(p.CurrentDistrict));
            //}

            if (brands != null)
            {
                //var brandsNames = brands.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                profiles = profiles.Where(p => brands.Contains(p.Brands));;
            }

            var profilesFilterd = profiles.ToList();



            IQueryable<DtoUserProfileEntity> coordinatorProfiles = this.manager.CoordinatorProfileRepository.GetAllActive();

            if (searchRequest.FullName != null)
            {
                coordinatorProfiles = coordinatorProfiles.Where(p => searchRequest.FullName.Contains(p.FullName));
            }

            if (searchRequest.NIC != null)
            {
                coordinatorProfiles = coordinatorProfiles.Where(p => searchRequest.NIC.Contains(p.NIC));
            }

            if (searchRequest.Age != null)
            {
                coordinatorProfiles = coordinatorProfiles.Where(p => searchRequest.Age.Contains(p.Age));
            }

            if (searchRequest.CurrentDistrict != null)
            {
                coordinatorProfiles = coordinatorProfiles.Where(p => searchRequest.CurrentDistrict.Contains(p.CurrentDisctrict));
            }

            if (searchRequest.CurrentTown != null)
            {
                coordinatorProfiles = coordinatorProfiles.Where(p => searchRequest.CurrentTown.Contains(p.CurrentCity));
            }

            if (searchRequest.HomeDistrict != null)
            {
                coordinatorProfiles = coordinatorProfiles.Where(p => searchRequest.HomeDistrict.Contains(p.HomeDisctrict));
            }

            if (searchRequest.HomeTown != null)
            {
                coordinatorProfiles = coordinatorProfiles.Where(p => searchRequest.HomeTown.Contains(p.HomeTown));
            }

            if (searchRequest.Gender != null)
            {
                if (searchRequest.Gender == "1")
                {
                    coordinatorProfiles = coordinatorProfiles.Where(p => p.GenderMale == true);
                }
                if (searchRequest.Gender == "2")
                {
                    coordinatorProfiles = coordinatorProfiles.Where(p => p.GenderFemale == true);
                }
            }

            if (searchRequest.SalesYears != null)
            {
                coordinatorProfiles = coordinatorProfiles.Where(p => searchRequest.SalesYears.Contains(p.YearsOfSales));
            }

            if (searchRequest.English != null)
            {
                if (searchRequest.English == "1")
                {
                    coordinatorProfiles = coordinatorProfiles.Where(p => p.EnglishSpeakingA == true);
                }
                if (searchRequest.English == "2")
                {
                    coordinatorProfiles = coordinatorProfiles.Where(p => p.EnglishSpeakingB == true);
                }
                if (searchRequest.English == "3")
                {
                    coordinatorProfiles = coordinatorProfiles.Where(p => p.EnglishSpeakingC == true);
                }
            }

            if (searchRequest.Tamil != null)
            {
                if (searchRequest.English == "1")
                {
                    coordinatorProfiles = coordinatorProfiles.Where(p => p.TamilSpeakinA == true);
                }
                if (searchRequest.English == "2")
                {
                    coordinatorProfiles = coordinatorProfiles.Where(p => p.TamilSpeakinB == true);
                }
                if (searchRequest.English == "3")
                {
                    coordinatorProfiles = coordinatorProfiles.Where(p => p.TamilSpeakinC == true);
                }
            }

            if (searchRequest.Iam != null)
            {
                if (searchRequest.Iam == "1")
                {
                    coordinatorProfiles = coordinatorProfiles.Where(p => p.Student == true);
                }
                if (searchRequest.Iam == "2")
                {
                    coordinatorProfiles = coordinatorProfiles.Where(p => p.FullTimeEmployed == true);
                }
                if (searchRequest.Iam == "3")
                {
                    coordinatorProfiles = coordinatorProfiles.Where(p => p.FullTimePromotor == true);
                }
                if (searchRequest.Iam == "4")
                {
                    coordinatorProfiles = coordinatorProfiles.Where(p => p.Freelancer == true);
                }
                if (searchRequest.Iam == "5")
                {
                    coordinatorProfiles = coordinatorProfiles.Where(p => p.Professional == true);
                }
                if (searchRequest.Iam == "6")
                {
                    coordinatorProfiles = coordinatorProfiles.Where(p => p.SearchForParttime == true);
                }
            }

            //if (searchRequest.Calendar != null)
            //{
            //    coordinatorProfiles = coordinatorProfiles.Where(p => searchRequest.CurrentDistrict.Contains(p.CurrentDistrict));
            //}

            //if (searchRequest.Look != null)
            //{
            //    coordinatorProfiles = coordinatorProfiles.Where(p => searchRequest.CurrentDistrict.Contains(p.CurrentDistrict));
            //}

            if (brands != null)
            {
                //var brandsNames = brands.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                coordinatorProfiles = coordinatorProfiles.Where(p => brands.Contains(p.Brands)); ;
            }

            var coordinatorProfilesFiltred = coordinatorProfiles.ToList();

            profilesFilterd.AddRange(coordinatorProfilesFiltred);


            return Json(new { data = profilesFilterd }, JsonRequestBehavior.AllowGet);
        }
    }
}