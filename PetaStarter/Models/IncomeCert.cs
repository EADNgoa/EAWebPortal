using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PanchayatWebPortal
{
    public class IncomeCert
    {
        public int IncomeCertificateID { get; set; }
        public int WEBstatusID { get; set; }
        public string UserID { get; set; }
        public string PersonName { get; set; }
        public string RelationName { get; set; }
        public string Address { get; set; }
        public decimal IncomeAmt { get; set; }
        public string YearOf { get; set; }
        public string OfficeName { get; set; }
        public string PurposeOf { get; set; }
        public string Inquiry { get; set; }
        public string ReportNo { get; set; }
        public DateTime InquiryDate { get; set; }
        public DateTime PrintDate { get; set; }
        public string Place { get; set; }


        public int RegisterTypeID { get; set; }
        public string Status { get; set; }


       public HttpPostedFileBase UploadedFile { get; set; }


    }
}