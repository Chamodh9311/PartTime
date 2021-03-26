namespace PartTimeV1.Requests
{
    public class SchedulerRequest
    {
        public string GigName { get; set; }
        public string Brands { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int PromoterCount { get; set; }
        public string District { get; set; }
        public string Town { get; set; }
        public string Comments { get; set; }
        public string Time { get; set; }
        public string Payment { get; set; }
        public string Location { get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
        //public string ApprovedId { get; set; }
        //public bool Approved { get; set; }
        //public bool Deleted { get; set; }
        //public bool Finished { get; set; }
        //public DateTime CreateOn { get; set; }
    }
}