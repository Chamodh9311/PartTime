using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartTimeV1.Requests
{
    public class SearchRequest
    {
        public string FullName { get; set; }
        public string NIC { get; set; }
        public string Age { get; set; }
        public string CurrentDistrict { get; set; }
        public string CurrentTown { get; set; }
        public string HomeDistrict { get; set; }
        public string HomeTown { get; set; }
        public string Gender { get; set; }
        public string SalesYears { get; set; }
        public string Iam { get; set; }
        public string English { get; set; }
        public string Tamil { get; set; }
        public string Calendar { get; set; }
        public string Look { get; set; }
    }
}