using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PanchayatWebPortal
{
    public class BNDcert
    {
        public int BNDID { get; set; }
        public int WEBstatusID { get; set; }
        public string UserID { get; set; }
        public int RegisterTypeID { get; set; }
        public string ChildName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime TDate { get; set; }
        public string PlaceOfBirth { get; set; }
        public string PlaceOfBirthHouse { get; set; }
        public string NameOfMother { get; set; }
        public int UIDmother { get; set; }
        public string NameOfFather { get; set; }
        public int UIDfather { get; set; }
        public string GrandFather { get; set; }
        public string GrandMother { get; set; }
        public string AddressParentsBirth { get; set; }
        public string PermAddress { get; set; }
        public string InformantsName { get; set; }
        public string InformantAddress { get; set; }
        public string NameOfTown { get; set; }
        public bool TownOrVillage { get; set; }
        public string NameOfDistrict { get; set; }
        public string NameOfState { get; set; }
        public string ReligionOfFamily { get; set; }
        public string AnyOtherReligion { get; set; }
        public string MEduc { get; set; }
        public string FEduc { get; set; }
        public string FOccup { get; set; }
        public string MOccup { get; set; }
        public int AgeOfMotherMarraige { get; set; }
        public int AgeOfMotherBirth { get; set; }
        public int NoOfChild { get; set; }
        public string AttentionType { get; set; }
        public string DeliveryMethod { get; set; }
        public int BirthWeight { get; set; }
        public string DurationOfPregnancy { get; set; }
        public string Status { get; set; }
        public HttpPostedFileBase UploadedFile { get; set; }
    }
}