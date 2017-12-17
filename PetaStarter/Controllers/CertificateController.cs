using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;


namespace PanchayatWebPortal.Controllers
{
   
    public class CertificateController : EAController
    {
        // GET: Clients
        public ActionResult Index(int? page,int? rt) 
        {            
            var id = User.Identity.GetUserId();
            ViewBag.RegisterTypeID = rt;

            int pageSize = db.Fetch<int>("Select top 1 RowsPerPage from Config").FirstOrDefault();
            int pageNumber = (page ?? 1);

            var PC= db.Fetch<PovertyCert>("Select * from PovertyCertificate pc inner join AspNetUsers asu on asu.Id = pc.UserID Inner Join WEbstatus ws on ws.WEBstatusID = pc.WEBstatusID Where RegisterTypeID = @0 and pc.UserID = @1 Order By PovertyCertificateID Desc", rt,id);

            return View(PC.ToPagedList(pageNumber, pageSize));
            

        }

   
        // GET: Clients/Create
        public ActionResult Manage(int? id,int? rt)
        {
            ViewBag.CertReq = db.Fetch<CertificateRequirement>("select * From CertificateRequirements Where RegisterTypeID = @0",rt);
            var rec = base.BaseCreateEdit<PovertyCertificate>(id, "PovertyCertificateID");
        
            if (id != null)
            {
                PovertyCert res = new PovertyCert()
                {
                    RegisterTypeID =(int) rec.RegisterTypeID,
                    PersonAddress = rec.PersonAddress,
                    PovertyCertificateID=(int)rec.PovertyCertificateID,
                    RequestedBy = rec.RequestedBy,
                    PersonName =rec.PersonName,
                    WEBstatusID = (int)rec.WEBstatusID,
                    UserID =rec.UserID,
                    AddOfPerReq =rec.AddOfPerReqBy,
                  
                    
                   

                };

                return View(res);
            }
            else
            {
                PovertyCert sp = new PovertyCert() { UserID = User.Identity.GetUserId(),RegisterTypeID=(int) rt ,WEBstatusID=1};
                return View(sp);
            }
         
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage([Bind(Include = "PovertyCertificateID,PersonName,PersonAddress,RequestedBy,AddOfPerReq,UserID,WEBstatusID,RegisterTypeID,UploadedFile")]  PovertyCert povertyCertificate)
        {
            using (var transaction = db.GetTransaction())
            {
                try
                {
                    if (povertyCertificate.UploadedFile != null || povertyCertificate.PovertyCertificateID > 0)
                    {

                        PovertyCertificate res = new PovertyCertificate()
                        {
                            PersonName = povertyCertificate.PersonName,
                            PersonAddress = povertyCertificate.PersonAddress,
                            RegisterTypeID = povertyCertificate.RegisterTypeID,
                            RequestedBy = povertyCertificate.RequestedBy,
                            UserID = povertyCertificate.UserID,
                            WEBstatusID = povertyCertificate.WEBstatusID,
                            PovertyCertificateID =povertyCertificate.PovertyCertificateID,
                            AddOfPerReqBy =povertyCertificate.AddOfPerReq,
                                                       
                        };
                        if (povertyCertificate.PovertyCertificateID == 0)
                        {

                            string fn = povertyCertificate.UploadedFile.FileName.Substring(povertyCertificate.UploadedFile.FileName.LastIndexOf('\\') + 1);
                            fn = povertyCertificate.PovertyCertificateID + "_" + fn;
                            string SavePath = System.IO.Path.Combine(Server.MapPath("~/Images"), fn);
                            povertyCertificate.UploadedFile.SaveAs(SavePath);
                            base.BaseSave<PovertyCertificate>(res, povertyCertificate.PovertyCertificateID > 0);

                            var item = new CertSupportDoc { RegisterTypeID = povertyCertificate.RegisterTypeID, CertificateID = res.PovertyCertificateID, DocumentName = fn };
                            db.Save(item);
                        }
                        else
                        {
                            //System.Drawing.Bitmap upimg = new System.Drawing.Bitmap(siteTransaction.UploadedFile.InputStream);
                            //System.Drawing.Bitmap svimg = MyExtensions.CropUnwantedBackground(upimg);
                            //svimg.Save(System.IO.Path.Combine(Server.MapPath("~/Images"), fn));
                            base.BaseSave<PovertyCertificate>(res, povertyCertificate.PovertyCertificateID > 0);
                        }



                            transaction.Complete();
                    }
                    return RedirectToAction("Index",new {rt= povertyCertificate.RegisterTypeID });                
                }
                catch (Exception ex)
            {
                db.AbortTransaction();
                throw ex;
            }


        }

    }
        public ActionResult ResIndex(int? page, int? rt)
        {
            var id = User.Identity.GetUserId();
            ViewBag.RegisterTypeID = rt;

            int pageSize = db.Fetch<int>("Select top 1 RowsPerPage from Config").FirstOrDefault();
            int pageNumber = (page ?? 1);

            var RC = db.Fetch<ResidenceCert>("Select * from ResidenceCertificate pc inner join AspNetUsers asu on asu.Id = pc.UserID Inner Join WEbstatus ws on ws.WEBstatusID = pc.WEBstatusID Where RegisterTypeID = @0 and pc.UserID = @1 Order By ResidenceCertificateID Desc", rt, id);

            return View(RC.ToPagedList(pageNumber, pageSize));


        }
        public ActionResult ResManage(int? id, int? rt)
        {
            ViewBag.CertReq = db.Fetch<CertificateRequirement>("select * From CertificateRequirements Where RegisterTypeID = @0", rt);
            var rec = base.BaseCreateEdit<ResidenceCertificate>(id, "ResidenceCertificateID");

            if (id != null)
            {
                ResidenceCert res = new ResidenceCert()
                {
                    Address=rec.Address,
                    BirthDate= (DateTime)rec.BirthDate,
                    BirthPlace=rec.BirthPlace,
                    Since= (int)rec.Since,
                    NameOfFather=rec.NameOfFather,
                    NameOfMother=rec.NameOfMother,
                    PersonName=rec.PersonName,
                    IsDead=(bool)rec.IsDead,
                    RegisterTypeID=(int)rec.RegisterTypeID,
                    ResidenceCertificateID=rec.ResidenceCertificateID,
                    UserID=rec.UserID,
                    WEBstatusID=(int)rec.WebStatusID

                };

                return View(res);
            }
            else
            {
                ResidenceCert sp = new ResidenceCert() { UserID = User.Identity.GetUserId(), RegisterTypeID = (int)rt, WEBstatusID = 1 };
                return View(sp);
            }

        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResManage([Bind(Include = "ResidenceCertificateID,PersonName,BirthDate,BirthPlace,NameOfMother,NameOfFather,Address,Since,IsDead,UserID,WEBstatusID,RegisterTypeID,UploadedFile")]  ResidenceCert residence)
        {
            using (var transaction = db.GetTransaction())
            {
                try
                {
                    if (residence.UploadedFile != null || residence.ResidenceCertificateID > 0)
                    {

                        ResidenceCertificate res = new ResidenceCertificate()
                        {
                            Address= residence.Address,
                            BirthDate= residence.BirthDate,
                            BirthPlace= residence.BirthPlace,
                            Since= residence.Since,
                            IsDead=residence.IsDead,
                            NameOfFather=residence.NameOfFather,
                            NameOfMother=residence.NameOfMother,
                            PersonName= residence.PersonName,
                            RegisterTypeID=residence.RegisterTypeID,
                            ResidenceCertificateID=residence.ResidenceCertificateID,
                            UserID=residence.UserID,
                            WebStatusID=residence.WEBstatusID
                        };
                        if (residence.ResidenceCertificateID == 0)
                        {

                            string fn = residence.UploadedFile.FileName.Substring(residence.UploadedFile.FileName.LastIndexOf('\\') + 1);
                            fn = residence.PersonName + "_" + fn;
                            string SavePath = System.IO.Path.Combine(Server.MapPath("~/Images"), fn);
                            residence.UploadedFile.SaveAs(SavePath);
                            base.BaseSave<ResidenceCertificate>(res, residence.ResidenceCertificateID > 0);

                            var item = new CertSupportDoc { RegisterTypeID = residence.RegisterTypeID, CertificateID = res.ResidenceCertificateID, DocumentName = fn };
                            db.Save(item);
                        }
                        else
                        {
                            //System.Drawing.Bitmap upimg = new System.Drawing.Bitmap(siteTransaction.UploadedFile.InputStream);
                            //System.Drawing.Bitmap svimg = MyExtensions.CropUnwantedBackground(upimg);
                            //svimg.Save(System.IO.Path.Combine(Server.MapPath("~/Images"), fn));
                            base.BaseSave<ResidenceCertificate>(res, residence.ResidenceCertificateID > 0);

                        }



                        transaction.Complete();
                    }
                    return RedirectToAction("ResIndex", new { rt = residence.RegisterTypeID });
                }
                catch (Exception ex)
                {
                    db.AbortTransaction();
                    throw ex;
                }


            }

        }
        public ActionResult HTIndex(int? page, int? rt)
        {
            var id = User.Identity.GetUserId();
            ViewBag.RegisterTypeID = rt;
            int pageSize = db.Fetch<int>("Select top 1 RowsPerPage from Config").FirstOrDefault();
            int pageNumber = (page ?? 1);
            var RC = db.Fetch<HouseTaxCertDet>("Select * from HouseTaxCert pc inner join AspNetUsers asu on asu.Id = pc.UserID Inner Join WEbstatus ws on ws.WEBstatusID = pc.WEBstatusID Where RegisterTypeID = @0 and pc.UserID = @1 Order By HouseTaxCertID Desc", rt, id);
            return View(RC.ToPagedList(pageNumber, pageSize));
       }
        public ActionResult HTManage(int? id, int? rt)
        {
            ViewBag.CertReq = db.Fetch<CertificateRequirement>("select * From CertificateRequirements Where RegisterTypeID = @0", rt);
            var rec = base.BaseCreateEdit<HouseTaxCert>(id, "HouseTaxCertID");
            ViewBag.RegisterTypeID = rt;
            if (id != null)
            {
                if (rt == 27)
                {
                    HouseTaxCertDet res = new HouseTaxCertDet()
                    {
                        DeveloperAddress = rec.DeveloperAddress,
                        DeveloperName = rec.DeveloperName,
                        PersonAddress = rec.PersonAddress,
                        Fees = (int)rec.Fees,
                        HouseTaxCertID = rec.HouseTaxCertID,
                        MeetingDate = (DateTime)rec.MeetingDate,
                        PersonName = rec.PersonName,
                        PrevPersonName = rec.PrevPersonName,
                        RegisterTypeID = (int)rec.RegisterTypeID,
                        Tdate = (DateTime)rec.Tdate,
                        UserID = rec.UserID,
                        WardNo = rec.WardNo,
                        WEBstatusID = (int)rec.WEBstatusID
                    };

                    return View(res);
                }
           
                if (rt == 29)
                {
                    HouseTaxCertDet res = new HouseTaxCertDet()
                    {
                        DeveloperAddress = "N/A",
                        DeveloperName = "N/A",
                        PersonAddress = rec.PersonAddress,
                        Fees = (int)rec.Fees,
                        HouseTaxCertID = rec.HouseTaxCertID,
                        MeetingDate = (DateTime)rec.MeetingDate,
                        PersonName = rec.PersonName,
                        PrevPersonName = "N/A",
                        RegisterTypeID = (int)rec.RegisterTypeID,
                        Tdate = DateTime.Now,
                        UserID = rec.UserID,
                        WardNo = rec.WardNo,
                        WEBstatusID = (int)rec.WEBstatusID
                    };

                    return View(res);

                }
                if ( rt == 30 || rt == 28)
                {
                    HouseTaxCertDet res = new HouseTaxCertDet()
                    {
                        DeveloperAddress = rec.DeveloperAddress,
                        DeveloperName = "N/A",
                        PersonAddress = rec.PersonAddress,
                        Fees = (int)rec.Fees,
                        HouseTaxCertID = rec.HouseTaxCertID,
                        MeetingDate = (DateTime)rec.MeetingDate,
                        PersonName = rec.PersonName,
                        PrevPersonName = "N/A",
                        RegisterTypeID = (int)rec.RegisterTypeID,
                        Tdate = DateTime.Now,
                        UserID = rec.UserID,
                        WardNo = rec.WardNo,
                        WEBstatusID = (int)rec.WEBstatusID
                    };

                    return View(res);

                }
                if (rt == 31)
                {
                    HouseTaxCertDet res = new HouseTaxCertDet()
                    {
                        DeveloperAddress = rec.DeveloperAddress,
                        DeveloperName = rec.DeveloperName,
                        PersonAddress = rec.PersonAddress,
                        Fees = (int)rec.Fees,
                        HouseTaxCertID = rec.HouseTaxCertID,
                        MeetingDate = (DateTime)rec.MeetingDate,
                        PersonName = rec.PersonName,
                        PrevPersonName = "N/A",
                        RegisterTypeID = (int)rec.RegisterTypeID,
                        Tdate = DateTime.Now,
                        UserID = rec.UserID,
                        WardNo = rec.WardNo,
                        WEBstatusID = (int)rec.WEBstatusID
                    };

                    return View(res);

                }


                return View();
            }
            else
            {
                HouseTaxCertDet sp = new HouseTaxCertDet() { UserID = User.Identity.GetUserId(), RegisterTypeID = (int)rt, WEBstatusID = 1 };
                return View(sp);
            }
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HTManage([Bind(Include = "HouseTaxCertID,PersonName,WardNo,PersonAddress,PrevPersonName,Fees,Tdate,,MeetingDate,DeveloperName,DeveloperAddress,UserID,WEBstatusID,RegisterTypeID,UploadedFile")]  HouseTaxCertDet house)
        {
            using (var transaction = db.GetTransaction())
            {
                try
                {
                    if (house.UploadedFile != null || house.HouseTaxCertID > 0)
                    {

                        HouseTaxCert res = new HouseTaxCert()
                        {
                            DeveloperAddress = house.DeveloperAddress,
                            DeveloperName = house.DeveloperName,
                            PersonAddress = house.PersonAddress,
                            Fees = (int)house.Fees,
                            HouseTaxCertID = house.HouseTaxCertID,
                            MeetingDate = (DateTime)house.MeetingDate,
                            PersonName = house.PersonName,
                            PrevPersonName = house.PrevPersonName,
                            RegisterTypeID = (int)house.RegisterTypeID,
                            Tdate = DateTime.Now,
                            UserID = house.UserID,
                            WardNo = house.WardNo,
                            WEBstatusID = (int)house.WEBstatusID
                        };
                        if (house.HouseTaxCertID == 0)
                        {

                            string fn = house.UploadedFile.FileName.Substring(house.UploadedFile.FileName.LastIndexOf('\\') + 1);
                            fn = house.PersonName + "_" + fn;
                            string SavePath = System.IO.Path.Combine(Server.MapPath("~/Images"), fn);
                            house.UploadedFile.SaveAs(SavePath);
                            base.BaseSave<HouseTaxCert>(res, house.HouseTaxCertID > 0);

                            var item = new CertSupportDoc { RegisterTypeID = house.RegisterTypeID, CertificateID = res.HouseTaxCertID, DocumentName = fn };
                            db.Save(item);
                        }
                        else
                        {
                            //System.Drawing.Bitmap upimg = new System.Drawing.Bitmap(siteTransaction.UploadedFile.InputStream);
                            //System.Drawing.Bitmap svimg = MyExtensions.CropUnwantedBackground(upimg);
                            //svimg.Save(System.IO.Path.Combine(Server.MapPath("~/Images"), fn));
                            base.BaseSave<HouseTaxCert>(res, house.HouseTaxCertID > 0);
                        }
                        transaction.Complete();
                    }
                    return RedirectToAction("HTIndex", new { rt = house.RegisterTypeID });
                }
                catch (Exception ex)
                {
                    db.AbortTransaction();
                    throw ex;
                }


            }

        }
        public ActionResult ConstIndex(int? page, int? rt)
        {
            var id = User.Identity.GetUserId();
            ViewBag.RegisterTypeID = rt;
            int pageSize = db.Fetch<int>("Select top 1 RowsPerPage from Config").FirstOrDefault();
            int pageNumber = (page ?? 1);
            var RC = db.Fetch<ConstructionCert>("Select * from ConstLicenseCert pc inner join AspNetUsers asu on asu.Id = pc.UserID Inner Join WEbstatus ws on ws.WEBstatusID = pc.WEBstatusID Where RegisterTypeID = @0 and pc.UserID = @1 Order By ConstLicenseID Desc", rt, id);
            return View(RC.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ConstManage(int? id, int? rt)
        {
            ViewBag.CertReq = db.Fetch<CertificateRequirement>("select * From CertificateRequirements Where RegisterTypeID = @0", rt);
            var rec = base.BaseCreateEdit<ConstLicenseCert>(id, "ConstLicenseID");

            if (id != null)
            {
                ConstructionCert res = new ConstructionCert()
                {
                   ConstFees=(decimal)rec.ConstFees,
                   BuildingType= rec.BuildingType_,
                   ConstLicenseID=rec.ConstLicenseID,
                   DeveloperAddress=rec.DeveloperAddress,
                   DeveloperName=rec.DeveloperName,
                  SubDivision=rec.SubDivision,
                  OwnwersAddress=rec.OwnwersAddress,
        
                   OrderNo= rec.OrderNo,
                   OwnersOfHouse= rec.OwnersOfHouse,
                   PropertyZone= rec.PropertyZone,
                   RecieptDate=(DateTime)rec.RecieptDate,
                   RecieptNo=rec.RecieptNo,
                   RefDate= (DateTime)rec.RefDate,
                   RefNo=rec.RefNo,
                   RegisterTypeID=(int)rec.RegisterTypeID,
                   SanitationFees=(decimal)rec.SanitationFees,
                   SurveyNo=rec.SurveyNo,
                   Tdate=(DateTime)rec.Tdate,
                   UserID=rec.UserID,
        
                   WEBstatusID=(int)rec.WEBstatusID
                };

                return View(res);
            }
            else
            {
                ConstructionCert sp = new ConstructionCert() { UserID = User.Identity.GetUserId(), RegisterTypeID = (int)rt, WEBstatusID = 1 };
                return View(sp);
            }

        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConstManage([Bind(Include = "ConstLicenseID,OwnersOfHouse,MeetingDated,DeveloperName,DeveloperAddress,OwnersAddress,SubDivision,Owner,BuildingType,PropertyZone,SurveyNo,OrderNo,Tdate,RefNo,RefDate,ValidUpTo,RecieptNo,RecieptDate,ConstFees,SanitationFees,UserID,WEBstatusID,RegisterTypeID,UploadedFile")]  ConstructionCert construction)
        {
            using (var transaction = db.GetTransaction())
            {
                try
                {
                    if (construction.UploadedFile != null || construction.ConstLicenseID > 0)
                    {

                        ConstLicenseCert res = new ConstLicenseCert()
                        {
                            ConstFees = construction.ConstFees,
                            BuildingType_ = construction.BuildingType,
                            ConstLicenseID = construction.ConstLicenseID,
                            OrderNo = construction.OrderNo,
                            OwnersOfHouse = construction.OwnersOfHouse,
                            PropertyZone = construction.PropertyZone,
                            RecieptDate = construction.RecieptDate,
                            RecieptNo = construction.RecieptNo,
                            RefDate = construction.RefDate,
                            RefNo = construction.RefNo,
                            RegisterTypeID = construction.RegisterTypeID,
                            SanitationFees =construction.SanitationFees,
                            SurveyNo = construction.SurveyNo,
                            Tdate = DateTime.Now.Date,
                            UserID = construction.UserID,
                            WEBstatusID = construction.WEBstatusID,
                            DeveloperAddress = construction.DeveloperAddress,
                            DeveloperName = construction.DeveloperName,
                            SubDivision = construction.SubDivision,
                            OwnwersAddress = construction.OwnwersAddress,

                        };
                        if (construction.ConstLicenseID == 0)
                        {
                            string fn = construction.UploadedFile.FileName.Substring(construction.UploadedFile.FileName.LastIndexOf('\\') + 1);
                            fn = construction.OwnersOfHouse + "_" + fn;
                            string SavePath = System.IO.Path.Combine(Server.MapPath("~/Images"), fn);
                            construction.UploadedFile.SaveAs(SavePath);
                            base.BaseSave<ConstLicenseCert>(res, construction.ConstLicenseID > 0);
                            var item = new CertSupportDoc { RegisterTypeID = construction.RegisterTypeID, CertificateID = construction.ConstLicenseID, DocumentName = fn };
                            db.Save(item);
                        }
                        else
                        {
                            //System.Drawing.Bitmap upimg = new System.Drawing.Bitmap(siteTransaction.UploadedFile.InputStream);
                            //System.Drawing.Bitmap svimg = MyExtensions.CropUnwantedBackground(upimg);
                            //svimg.Save(System.IO.Path.Combine(Server.MapPath("~/Images"), fn));
                            base.BaseSave<ConstLicenseCert>(res, construction.ConstLicenseID > 0);

                        }



                        transaction.Complete();
                    }
                    return RedirectToAction("ConstIndex", new { rt = construction.RegisterTypeID });
                }
                catch (Exception ex)
                {
                    db.AbortTransaction();
                    throw ex;
                }


            }

        }
        public ActionResult OccupIndex(int? page, int? rt)
        {
            var id = User.Identity.GetUserId();
            ViewBag.RegisterTypeID = rt;

            int pageSize = db.Fetch<int>("Select top 1 RowsPerPage from Config").FirstOrDefault();
            int pageNumber = (page ?? 1);

            var RC = db.Fetch<OccupationCertificate>("Select * from OccupationCertificate pc inner join AspNetUsers asu on asu.Id = pc.UserID Inner Join WEbstatus ws on ws.WEBstatusID = pc.WEBstatusID Where RegisterTypeID = @0 and pc.UserID = @1 Order By OccupationCertificateID Desc", rt, id);

            return View(RC.ToPagedList(pageNumber, pageSize));


        }
        public ActionResult OccupManage(int? id, int? rt)
        {
            ViewBag.CertReq = db.Fetch<CertificateRequirement>("select * From CertificateRequirements Where RegisterTypeID = @0", rt);
            var rec = base.BaseCreateEdit<OccupationCertificate>(id, "OccupationCertificateID");

            if (id != null)
            {
                OccupationCertDet res = new OccupationCertDet()
                {
                  PersonAddress=rec.PersonAddress,
                  BuildingDetails=rec.BuildingDetails,
                  ConstLicNo=rec.ConstLicNo,
                  HSref=rec.HSref,
                  HSrefdate=(DateTime)rec.HSrefdate,
                  OccupationCertificateID=rec.OccupationCertificateID,
                  PersonName=rec.PersonName,
                  PlotNumber=rec.PlotNumber,
                  WEBstatusID=(int)rec.WEBstatusID,
                  RefDate=(DateTime)rec.RefDate,
                  RefNo=rec.RefNo,
                  RegisterTypeID=(int)rec.RegisterTypeID,
                  SurveyNo=rec.SurveyNo,
                  Tdate=(DateTime)rec.Tdate,
            
                };
                return View(res);
            }
            else
            {
                OccupationCertDet sp = new OccupationCertDet() { UserID = User.Identity.GetUserId(), RegisterTypeID = (int)rt, WEBstatusID = 1 };
                return View(sp);
            }

        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OccupManage([Bind(Include = "OccupationCertificateID,PersonName,PersonAddress,MeetingDated,ConstLicNo,ConstLicDate,BuildingDetails,Tdate,SurveyNo,PlotNumber,RefNo,HSref,RefDate,HSrefdate,UserID,WEBstatusID,RegisterTypeID,UploadedFile")]  OccupationCertDet occupation)
        {
            using (var transaction = db.GetTransaction())
            {
                try
                {
                    if (occupation.UploadedFile != null || occupation.OccupationCertificateID > 0)
                    {

                        OccupationCertificate res = new OccupationCertificate()
                        {
                            PersonAddress = occupation.PersonAddress,
                            BuildingDetails = occupation.BuildingDetails,
                            ConstLicNo = occupation.ConstLicNo,
                            ConstLicDate =occupation.ConstLicDate,

                            HSref = occupation.HSref,
                            HSrefdate = (DateTime)occupation.HSrefdate,
                            OccupationCertificateID = occupation.OccupationCertificateID,
                            PersonName = occupation.PersonName,
                            PlotNumber = occupation.PlotNumber,
                            WEBstatusID = (int)occupation.WEBstatusID,
                            RefDate = (DateTime)occupation.RefDate,
                            RefNo = occupation.RefNo,
                            RegisterTypeID = (int)occupation.RegisterTypeID,
                            SurveyNo = occupation.SurveyNo,
                            Tdate = DateTime.Now,
                            UserID=User.Identity.GetUserId()
                        };
                        if (occupation.OccupationCertificateID == 0)
                        {

                            string fn = occupation.UploadedFile.FileName.Substring(occupation.UploadedFile.FileName.LastIndexOf('\\') + 1);
                            fn = occupation.PersonName + "_" + fn;
                            string SavePath = System.IO.Path.Combine(Server.MapPath("~/Images"), fn);
                            occupation.UploadedFile.SaveAs(SavePath);
                            base.BaseSave<OccupationCertificate>(res, occupation.OccupationCertificateID > 0);

                            var item = new CertSupportDoc { RegisterTypeID = occupation.RegisterTypeID, CertificateID = res.OccupationCertificateID, DocumentName = fn };
                            db.Save(item);
                        }
                        else
                        {
                            //System.Drawing.Bitmap upimg = new System.Drawing.Bitmap(siteTransaction.UploadedFile.InputStream);
                            //System.Drawing.Bitmap svimg = MyExtensions.CropUnwantedBackground(upimg);
                            //svimg.Save(System.IO.Path.Combine(Server.MapPath("~/Images"), fn));
                            base.BaseSave<OccupationCertificate>(res, occupation.OccupationCertificateID > 0);

                        }



                        transaction.Complete();
                    }
                    return RedirectToAction("OccupIndex", new { rt = occupation.RegisterTypeID });
                }
                catch (Exception ex)
                {
                    db.AbortTransaction();
                    throw ex;
                }


            }

        }

        public ActionResult OccupDetails(int? id)
        {
            //ViewBag.OccupDets = base.BaseCreateEdit<OccupationCertDetail>(id, "OccupationCertDetailsID");

            ViewBag.Dets = db.Fetch<OccupationCertDetail>("Select * from OccupationCertDetails Where OccupationCertificateID=@0",id);
            ViewBag.OccupID = id;
            return View();
        }

        [HttpPost]
        public ActionResult OccupDetails([Bind(Include = "OccupationCertDetailsID,OccupationCertificateID,NameOfTheOwner,FlatNo,HouseNo,HouseTax,GarbageTax")] OccupationCertDetail occupationCert)
        {
          
                    base.BaseSave<OccupationCertDetail>(occupationCert, occupationCert.OccupationCertDetailsID > 0);                   
                    return RedirectToAction("OccupDetails", new { id = occupationCert.OccupationCertificateID });
      
        }
        public ActionResult ManageDetails(int? id)
        {
            ViewBag.OccupDets = base.BaseCreateEdit<OccupationCertDetail>(id, "OccupationCertDetailsID");

            ViewBag.OccupID = id;
            return View("OccupDetails");
        }

        [HttpPost]
        public ActionResult ManageDetails([Bind(Include = "OccupationCertDetailsID,OccupationCertificateID,NameOfTheOwner,FlatNo,HouseNo,HouseTax,GarbageTax")] OccupationCertDetail occupationCert)
        {

            base.BaseSave<OccupationCertDetail>(occupationCert, occupationCert.OccupationCertDetailsID > 0);
            return RedirectToAction("OccupDetails", new { id = occupationCert.OccupationCertificateID });

        }
        public ActionResult NocIndex(int? page, int? rt)
        {
            var id = User.Identity.GetUserId();
            ViewBag.RegisterTypeID = rt;

            int pageSize = db.Fetch<int>("Select top 1 RowsPerPage from Config").FirstOrDefault();
            int pageNumber = (page ?? 1);

            var RC = db.Fetch<NocCertDets>("Select * from NocCertifictes pc inner join AspNetUsers asu on asu.Id = pc.UserID Inner Join WEbstatus ws on ws.WEBstatusID = pc.WEBstatusID Where RegisterTypeID = @0 and pc.UserID = @1 Order By NocID Desc", rt, id);

            return View(RC.ToPagedList(pageNumber, pageSize));


        }
        public ActionResult NocManage(int? id, int? rt)
        {
            ViewBag.CertReq = db.Fetch<CertificateRequirement>("select * From CertificateRequirements Where RegisterTypeID = @0", rt);
            var rec = base.BaseCreateEdit<NocCertificte>(id, "NocID");
            ViewBag.RegisterTypeID = rt;

            if (id != null)
            {
                NocCertDets res = new NocCertDets()
                {
                    Address=rec.Address,
                    ElectDeptAdd=rec.ElectDeptAdd,
                    WEBstatusID=(int)rec.WEBstatusID,
                    RegisterTypeID=(int)rec.RegisterTypeID,
                    Hno=rec.Hno,
                    No=rec.No,
                    NocID=rec.NocID,
                    PersonName=rec.PersonName,
                    UserID=rec.UserID
                };

                return View(res);
            }
            else
            {
                NocCertDets sp = new NocCertDets() { UserID = User.Identity.GetUserId(), RegisterTypeID = (int)rt, WEBstatusID = 1 };
                return View(sp);
            }

        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NocManage([Bind(Include = "NocID,Hno,No,ApprovedDate,PrintDate,PersonName,Address,ElectDeptAdd,UserID,WEBstatusID,RegisterTypeID,UploadedFile")]  NocCertDets noc)
        {
            using (var transaction = db.GetTransaction())
            {
                try
                {
                    if (noc.UploadedFile != null || noc.NocID > 0)
                    {

                        NocCertificte res = new NocCertificte()
                        {
                            Address = noc.Address,
                            ElectDeptAdd = noc.ElectDeptAdd,
                            WEBstatusID = noc.WEBstatusID,
                            RegisterTypeID = noc.RegisterTypeID,
                            Hno = noc.Hno,
                            No = noc.No,
                            AprovedDate=null,
                            PrintDate=null,
                            NocID = noc.NocID,
                            PersonName = noc.PersonName,
                            UserID = noc.UserID,
                            
                        };
                        if (noc.NocID == 0)
                        {

                            string fn = noc.UploadedFile.FileName.Substring(noc.UploadedFile.FileName.LastIndexOf('\\') + 1);
                            fn = noc.PersonName + "_" + fn;
                            string SavePath = System.IO.Path.Combine(Server.MapPath("~/Images"), fn);
                            noc.UploadedFile.SaveAs(SavePath);
                            base.BaseSave<NocCertificte>(res, noc.NocID > 0);

                            var item = new CertSupportDoc { RegisterTypeID = noc.RegisterTypeID, CertificateID = res.NocID, DocumentName = fn };
                            db.Save(item);
                        }
                        else
                        {
                            //System.Drawing.Bitmap upimg = new System.Drawing.Bitmap(siteTransaction.UploadedFile.InputStream);
                            //System.Drawing.Bitmap svimg = MyExtensions.CropUnwantedBackground(upimg);
                            //svimg.Save(System.IO.Path.Combine(Server.MapPath("~/Images"), fn));
                            base.BaseSave<NocCertificte>(res, noc.NocID > 0);

                        }



                        transaction.Complete();
                    }
                    return RedirectToAction("NocIndex", new { rt = noc.RegisterTypeID });
                }
                catch (Exception ex)
                {
                    db.AbortTransaction();
                    throw ex;
                }


            }

        }

        public ActionResult CharIndex(int? page, int? rt)
        {
            var id = User.Identity.GetUserId();
            ViewBag.RegisterTypeID = rt;

            int pageSize = db.Fetch<int>("Select top 1 RowsPerPage from Config").FirstOrDefault();
            int pageNumber = (page ?? 1);

            var RC = db.Fetch<CharCertDet>("Select * from CharacterCertificate pc inner join AspNetUsers asu on asu.Id = pc.UserID Inner Join WEbstatus ws on ws.WEBstatusID = pc.WEBstatusID Where RegisterTypeID = @0 and pc.UserID = @1 Order By CharacterID Desc", rt, id);

            return View(RC.ToPagedList(pageNumber, pageSize));


        }
        public ActionResult CharManage(int? id, int? rt)
        {
            ViewBag.CertReq = db.Fetch<CertificateRequirement>("select * From CertificateRequirements Where RegisterTypeID = @0", rt);
            var rec = base.BaseCreateEdit<CharacterCertificate>(id, "CharacterID");
            ViewBag.RegisterTypeID = rt;

            if (id != null)
            {
                CharCertDet res = new CharCertDet()
                {
                    Address= rec.Address,
                    Age=(int)rec.Age,
                    CharacterID=rec.CharacterID,
                    FatherName=rec.FatherName,
                    RegisterTypeID= (int)rec.RegisterTypeID,
                    KnownYears= (int)rec.KnownYears,
                    PurposeOf=rec.PurposeOf,
                    MotherName=rec.MotherName,
                    PersonName=rec.PersonName,
                    UserID=rec.UserID,
                    WardOf=rec.WardOf,
                    WEBstatusID= (int)rec.WEBstatusID
                    
                };

                return View(res);
            }
            else
            {
                CharCertDet sp = new CharCertDet() { UserID = User.Identity.GetUserId(), RegisterTypeID = (int)rt, WEBstatusID = 1 };
                return View(sp);
            }

        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CharManage([Bind(Include = "CharacterID,PersonName,Age,FatherName,PurposeOf,MotherName,Address,WardOf,KnownYears,UserID,WEBstatusID,RegisterTypeID,UploadedFile")]  CharCertDet charCert)
        {
            using (var transaction = db.GetTransaction())
            {
                try
                {
                    if (charCert.UploadedFile != null || charCert.CharacterID > 0)
                    {

                        CharacterCertificate res = new CharacterCertificate()
                        {
                            Address = charCert.Address,
                            Age = (int)charCert.Age,
                            CharacterID = charCert.CharacterID,
                            FatherName = charCert.FatherName,
                            RegisterTypeID = (int)charCert.RegisterTypeID,
                            KnownYears = (int)charCert.KnownYears,
                            MotherName = charCert.MotherName,
                            PersonName = charCert.PersonName,
                            PurposeOf=charCert.PurposeOf,
                            UserID = charCert.UserID,
                            WardOf = charCert.WardOf,
                            WEBstatusID = (int)charCert.WEBstatusID
                        };
                        if (charCert.CharacterID == 0)
                        {

                            string fn = charCert.UploadedFile.FileName.Substring(charCert.UploadedFile.FileName.LastIndexOf('\\') + 1);
                            fn = charCert.PersonName + "_" + fn;
                            string SavePath = System.IO.Path.Combine(Server.MapPath("~/Images"), fn);
                            charCert.UploadedFile.SaveAs(SavePath);
                            base.BaseSave<CharacterCertificate>(res, charCert.CharacterID > 0);

                            var item = new CertSupportDoc { RegisterTypeID = res.RegisterTypeID, CertificateID = res.CharacterID, DocumentName = fn };
                            db.Save(item);
                        }
                        else
                        {
                            //System.Drawing.Bitmap upimg = new System.Drawing.Bitmap(siteTransaction.UploadedFile.InputStream);
                            //System.Drawing.Bitmap svimg = MyExtensions.CropUnwantedBackground(upimg);
                            //svimg.Save(System.IO.Path.Combine(Server.MapPath("~/Images"), fn));
                            base.BaseSave<CharacterCertificate>(res, charCert.CharacterID > 0);

                        }



                        transaction.Complete();
                    }
                    return RedirectToAction("CharIndex", new { rt = charCert.RegisterTypeID });
                }
                catch (Exception ex)
                {
                    db.AbortTransaction();
                    throw ex;
                }


            }

        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
