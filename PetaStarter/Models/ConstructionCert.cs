using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PanchayatWebPortal
{
    public class ConstructionCert
    {
        public int ConstLicenseID { get; set; }
        public int WEBstatusID { get; set; }
        public string UserID { get; set; }
        public int RegisterTypeID { get; set; }
        public string OwnersOfHouse { get; set; }
        public string OwnwersAddress { get; set; }
        public string DeveloperName { get; set; }
        public string DeveloperAddress { get; set; }
        public string SubDivision { get; set; }



        public string BuildingType { get; set; }
        public string PropertyZone { get; set; }
        public string SurveyNo { get; set; }
        public string OrderNo { get; set; }
        public string RefNo { get; set; }
        public string RecieptNo { get; set; }
        public decimal ConstFees { get; set; }
        public decimal SanitationFees { get; set; }
        public DateTime MeetingDated { get; set; }
        public DateTime Tdate { get; set; }
        public DateTime RefDate { get; set; }
        public DateTime ValidUpTo { get; set; }
        public DateTime RecieptDate { get; set; }
        public string Status { get; set; }
        public HttpPostedFileBase UploadedFile { get; set; }
    }
}