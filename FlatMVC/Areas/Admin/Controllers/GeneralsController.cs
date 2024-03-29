﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using Entity;

namespace FlatMVC.Areas.Admin.Controllers
{
    public class GeneralsController : AdminController
    {
        private FlatContext db = new FlatContext();

        // GET: Admin/Generals
        public ActionResult Index()
        {
            ViewBag.ShowCreateNew = db.General.Count() == 0;
            return View(db.General.FirstOrDefault());
        }

        // GET: Admin/Generals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            General general = db.General.Find(id);
            if (general == null)
            {
                return HttpNotFound();
            }
            return View(general);
        }

        // GET: Admin/Generals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Generals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LogoURL,SiteTitle,SiteDesc,HeaderTitle,HeaderDescription,CTA1_Title,CTA1_Description,CTA2_Title,CTA2_Button,Address,Email,Phone")] General general,HttpPostedFileBase LogoImage)
        {
            if(LogoImage!=null && LogoImage.ContentLength != 0)
            {
                var path = Server.MapPath("/Content/");
                var filename = LogoImage.FileName;
                LogoImage.SaveAs(path + filename);
                general.LogoURL = filename;
               
            }
            if (ModelState.IsValid)
            {
                db.General.Add(general);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(general);
        }

        // GET: Admin/Generals/Edit/5
        public ActionResult Edit()
        {
            General general = db.General.FirstOrDefault();
            if (general == null)
            {
                return HttpNotFound();
            }
            return View(general);
        }

        // POST: Admin/Generals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SiteTitle,SiteDesc,HeaderTitle,HeaderDescription,CTA1_Title,CTA1_Description,CTA2_Title,CTA2_Button,Address,Email,Phone")] General general,HttpPostedFileBase LogoImage)
        {

            if (LogoImage != null && LogoImage.ContentLength != 0)
            {
                var path = Server.MapPath("/Content/");
                var filename = LogoImage.FileName;
                LogoImage.SaveAs(path + filename);
                general.LogoURL = filename;

            }
            else
            {
                //resim değişmesdiyse eski resim kalsın
                var kayit = db.General.FirstOrDefault();
                general.LogoURL = kayit.LogoURL;
                db.Entry(kayit).State = EntityState.Detached;
            }
            if (ModelState.IsValid)
            {
                db.Entry(general).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(general);
        }

        // GET: Admin/Generals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            General general = db.General.Find(id);
            if (general == null)
            {
                return HttpNotFound();
            }
            return View(general);
        }

        // POST: Admin/Generals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            General general = db.General.Find(id);
            db.General.Remove(general);
            db.SaveChanges();
            return RedirectToAction("Index");
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
