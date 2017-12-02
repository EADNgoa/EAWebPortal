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
   
    public class ComplaintController : EAController
    {
        // GET: Clients
        public ActionResult Index(int? page,int? rt) 
        {            
            var id = User.Identity.GetUserId();
            ViewBag.RegisterTypeID = rt;

            int pageSize = db.Fetch<int>("Select top 1 RowsPerPage from Config").FirstOrDefault();
            int pageNumber = (page ?? 1);

            var IC= db.Fetch<ComplainDet>("Select IllegalConID,DateOfComp,NameOfPr,NatOfCon,AddressOfPr,OccasOfCons,ActionTaken,Remarks,RegisterTypeID,Status from IllegalConstruction ic inner join AspNetUsers asu on asu.Id = ic.UserID Inner Join WEbstatus ws on ws.WEBstatusID = ic.WEBstatusID Where RegisterTypeID = @0 and ic.UserID = @1 Order By IllegalConID Desc", rt,id);
           
            return View(IC.ToPagedList(pageNumber, pageSize))
            ;

        }

        // GET: Clients/Create
        public ActionResult Manage(int? id,int? rt)
        {
            ViewBag.WEBstatusID = new SelectList(db.Fetch<WEBstatus>("Select WEBstatusID,Status from WEBstatus"), "WEBstatusID", "Status");
            var rec = base.BaseCreateEdit<IllegalConstruction>(id, "IllegalConID");
            if(id==null)
            { 
            rec = new IllegalConstruction { UserID = User.Identity.GetUserId(), RegisterTypeID = (int)rt};
           }
            return View(rec);
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage([Bind(Include = "IllegalConID,DateOfComp,NameOfPr,AddressOfPr,NatOfCon,OccasOfCons,ActionTaken,Remarks,WEBstatusID,Id,RegisterTypeID,UserID")]  IllegalConstruction illegalConstruction)
        {
            illegalConstruction.WEBstatusID = 1;
            illegalConstruction.DateOfComp = DateTime.Now;
            base.BaseSave<IllegalConstruction>(illegalConstruction, illegalConstruction.IllegalConID > 0);
            return RedirectToAction("Index",new {rt=illegalConstruction.RegisterTypeID });


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
