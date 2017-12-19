using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PanchayatWebPortal
{
    public class CharCertDet
    {
        public int CharacterID { get; set; }
        public int WEBstatusID { get; set; }
        public string UserID { get; set; }
        public int RegisterTypeID { get; set; }
        public string PersonName { get; set; }
        public string FatherName { get; set; }
        public int KnownYears { get; set; }
        public string MotherName { get; set; }
        public string PurposeOf { get; set; }

        public string Address { get; set; }
        public string WardOf { get; set; }
        public string Village { get; set; }

        public int Age { get; set; }
        public DateTime Tdate { get; set; }
        public string Status { get; set; }
        public HttpPostedFileBase UploadedFile { get; set; }
    }
}