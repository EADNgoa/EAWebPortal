using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PanchayatWebPortal
{
    public class DeathCorrCert
    {
        public int DeathCorrCertificateID { get; set; }
        public int WEBstatusID { get; set; }
        public string UserID { get; set; }
        public string FromName { get; set; }
        public string FromAddress { get; set; }
        public DateTime TDate { get; set; }
        public string BirthOf { get; set; }
        public DateTime BornOn { get; set; }
        public string BirthPlace { get; set; }
        public string FromWrongName { get; set; }
        public string InsteadFWN { get; set; }
        public string NameOfFather { get; set; }
        public string InsteadNF { get; set; }
        public string NameOfMother { get; set; }
        public string InsteadNM { get; set; }
        public string NameOfGrandFather { get; set; }
        public string InsteadNGF { get; set; }
        public string NameOfGrandMother { get; set; }
        public string InsteadNGM { get; set; }
        public string BirthDeathName { get; set; }

        public int RegisterTypeID { get; set; }
        public string Status { get; set; }
        public HttpPostedFileBase UploadedFile { get; set; }


    }
}