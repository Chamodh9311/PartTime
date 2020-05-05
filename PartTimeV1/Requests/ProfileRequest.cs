using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartTimeV1.Requests
{
    public class ProfileRequest
    {
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string NIC { get; set; }
        public string Photo1 { get; set; }
        public string Photo2 { get; set; }
        public string Photo3 { get; set; }
        public string Photo4 { get; set; }
        public string Photo5 { get; set; }
        public string Mobile1 { get; set; }
        public bool Mobile1Whatsapp { get; set; }
        public bool Mobile1Viber { get; set; }
        public string Mobile2 { get; set; }
        public bool Mobile2Whatsapp { get; set; }
        public bool Mobile2Viber { get; set; }
        public string Mobile3 { get; set; }
        public bool Mobile3Whatsapp { get; set; }
        public bool Mobile3Viber { get; set; }
        public string DOB { get; set; }
        public string Age { get; set; }
        public bool GenderMale { get; set; }
        public bool GenderFemale { get; set; }
        public string CurrentDistrict { get; set; }
        public string CurrentTown { get; set; }
        public string HomeDistrict { get; set; }
        public string HomeTown { get; set; }
        public bool ShirtSizeS { get; set; }
        public bool ShirtSizeM { get; set; }
        public bool ShirtSizeL { get; set; }
        public bool ShirtSizeXS { get; set; }
        public bool Student { get; set; }
        public string University { get; set; }
        public string Course { get; set; }
        public string UniYear { get; set; }
        public bool Employeed { get; set; }
        public string Company { get; set; }
        public string Branch { get; set; }
        public string Designation { get; set; }
        public bool FullTimePromoter { get; set; }
        public bool PartTimePromoter { get; set; }
        public string EnglishSpeaking { get; set; }
        public string TamilSpeaking { get; set; }
        public string SalesExperience { get; set; }
        public List<string> Brands { get; set; }
        public List<string> OtherExperience { get; set; }
    }
}