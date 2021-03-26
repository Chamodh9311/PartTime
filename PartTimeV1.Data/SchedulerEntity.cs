using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PartTimeV1.Data
{
    public class SchedulerEntity : Entity
    {
        public string GigName { get; set; }
        public string Brands { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int PromoterCount { get; set; }
        public string District { get; set; }
        public string Town { get; set; }
        public string Comments { get; set; }
        public string Time { get; set; }
        public string Payment { get; set; }
        public string Mobile { get; set; }
        public string Location { get; set; }
        public string Gender { get; set; }
        public int NumberOfDays { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string CreatedId { get; set; }
        public string ApprovedId { get; set; }
        public bool Approved { get; set; }
        public bool Deleted { get; set; }
        public bool Finished { get; set; }
        public DateTime CreateOn { get; set; }

    }
}
