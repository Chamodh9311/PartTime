using Microsoft.AspNet.Identity;
using PartTimeV1.Data;
using PartTimeV1.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PartTimeV1.Controllers
{
    public class SchedulerController : BaseController
    {

        public JsonResult GetActiveEvents()
        {
            var events = this.manager.SchedulerRepository.GetAllActiveEvents().ToList();
            return Json(new { data = events }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EventSchedulerSave(SchedulerRequest schedulerRequest, List<string> brands)
        {
            try
            {
                SchedulerEntity schedulerEntity = new SchedulerEntity()
                {
                    GigName = schedulerRequest.GigName,
                    Brands = schedulerRequest.Brands,
                    FromDate = DateTime.ParseExact(schedulerRequest.FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    ToDate = DateTime.ParseExact(schedulerRequest.ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    PromoterCount = schedulerRequest.PromoterCount,
                    District = schedulerRequest.District,
                    Town = schedulerRequest.Town,
                    Comments = schedulerRequest.Comments,
                    CreatedId = User.Identity.GetUserId(),
                    ApprovedId = User.Identity.GetUserId(),
                    Approved = true,
                    Deleted = false,
                    Finished = false,
                    CreateOn = DateTime.Now
                };

                manager.BeginTransaction();
                manager.SchedulerRepository.Add(schedulerEntity);
                manager.Commit();

                var events = this.manager.SchedulerRepository.GetAllActiveEvents().ToList();

                return Json(new { data = events }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }

            return Json("Error", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EventSchedulerSearch(SchedulerRequest schedulerRequest, List<string> brands)
        {

            return Json("Saved", JsonRequestBehavior.AllowGet);
        }
    }
}