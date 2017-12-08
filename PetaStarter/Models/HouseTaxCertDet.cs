using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PanchayatWebPortal
{
    public class HouseTaxCertDet
    {
        public int HouseTaxCertID { get; set; }
        public int WEBstatusID { get; set; }
        public string UserID { get; set; }
        public int RegisterTypeID { get; set; }
        public string PersonName { get; set; }
        public DateTime Tdate { get; set; }
        public DateTime MeetingDate { get; set; }
        public string WardNo { get; set; }
        public string PrevPersonName { get; set; }
        public int Fees { get; set; }
        public string PersonAddress { get; set; }
        public string DeveloperName { get; set; }
        public string DeveloperAddress { get; set; }
        public string Status { get; set; }
        public HttpPostedFileBase UploadedFile { get; set; }
    }
}