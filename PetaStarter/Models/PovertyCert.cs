using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PanchayatWebPortal
{
    public class PovertyCert
    {
        public int PovertyCertificateID { get; set; }
        public int WEBstatusID { get; set; }
        public string UserID { get; set; }



        public string PersonName { get; set; }
        public string OtherName { get; set; }
        public string AddOfPerReq { get; set; }



        public string PersonAddress { get; set; }

        public string RequestedBy { get; set; }

        public int RegisterTypeID { get; set; }
        public string Status { get; set; }


       public HttpPostedFileBase UploadedFile { get; set; }


    }
}