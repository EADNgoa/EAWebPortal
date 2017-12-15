using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PanchayatWebPortal
{
    public class OccupationCertDet
    {
        public int OccupationCertificateID { get; set; }
        public int WEBstatusID { get; set; }
        public string UserID { get; set; }
        public int RegisterTypeID { get; set; }
        public string PersonName { get; set; }
        public string FlatNo { get; set; }
        public string HouseNo { get; set; }
        public decimal HouseTax { get; set; }
        public decimal GarbageTax { get; set; }



        public string BuildingDetails { get; set; }

        public string PersonAddress { get; set; }
        public string ConstLicNo { get; set; }
        public string SurveyNo { get; set; }
        public string PlotNumber { get; set; }
        public string HSref { get; set; }
        public string RefNo { get; set; }

        public DateTime MeetingDated { get; set; }
        public DateTime Tdate { get; set; }
        public DateTime RefDate { get; set; }
        public DateTime HSrefdate { get; set; }
        public DateTime ConstLicDate { get; set; }


        public string Status { get; set; }
        public HttpPostedFileBase UploadedFile { get; set; }
    }
}