using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PanchayatWebPortal
{
    public class ResidenceCert
    {
        public int ResidenceCertificateID { get; set; }
        public int WEBstatusID { get; set; }
        public string UserID { get; set; }
        public int RegisterTypeID { get; set; }
        public string PersonName { get; set; }
        public string NameOfMother { get; set; }
        public string NameOfFather { get; set; }
        public string Address { get; set; }
        public string BirthPlace { get; set; }
        public bool IsDead { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime TillDate { get; set; }
        public string Status { get; set; }
        public HttpPostedFileBase UploadedFile { get; set; }
    }
}