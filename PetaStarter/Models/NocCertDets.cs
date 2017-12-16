using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PanchayatWebPortal
{
    public class NocCertDets
    {
        public int NocID { get; set; }
        public int WEBstatusID { get; set; }
        public string UserID { get; set; }
        public int RegisterTypeID { get; set; }
        public string PersonName { get; set; }
        public string ElectDeptAdd { get; set; }     
        public string Address { get; set; }
        public string Hno { get; set; }
        public string No { get; set; }
        public DateTime AprovedDate { get; set; }
        public DateTime PrintDate { get; set; }       
        public string Status { get; set; }
        public HttpPostedFileBase UploadedFile { get; set; }
    }
}