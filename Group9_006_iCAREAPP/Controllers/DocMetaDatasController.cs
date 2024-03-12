using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Group9_006_iCAREAPP.Models;

namespace Group9_006_iCAREAPP.Controllers
{
    public class DocMetaDatasController : Controller
    {
        private Group9_006_iCAREDBEntities1 db = new Group9_006_iCAREDBEntities1();

        // GET: DocMetaDatas
        public ActionResult Index()
        {
            var docMetaData = db.DocMetaData.Include(d => d.PatientRecord).Include(d => d.Worker);
            return View(docMetaData.ToList());
        }
        //....


        // GET: DocMetaDatas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocMetaData docMetaData = db.DocMetaData.Find(id);
            if (docMetaData == null)
            {
                return HttpNotFound();
            }
            return View(docMetaData);
        }

        // GET: DocMetaDatas/Create
        public ActionResult Create()
        {
            ViewBag.PatientId = new SelectList(db.PatientRecord, "PatientId", "TreatmentId");
            ViewBag.UserId = new SelectList(db.Worker, "UserId", "RoleId");
            return View();
        }

        // POST: DocMetaDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DocId,DocName,DocCreationDate,PatientId,UserId")] DocMetaData docMetaData)
        {
            if (ModelState.IsValid)
            {
                db.DocMetaData.Add(docMetaData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PatientId = new SelectList(db.PatientRecord, "PatientId", "TreatmentId", docMetaData.PatientId);
            ViewBag.UserId = new SelectList(db.Worker, "UserId", "RoleId", docMetaData.UserId);
            return View(docMetaData);
        }

        // GET: DocMetaDatas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocMetaData docMetaData = db.DocMetaData.Find(id);
            if (docMetaData == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatientId = new SelectList(db.PatientRecord, "PatientId", "TreatmentId", docMetaData.PatientId);
            ViewBag.UserId = new SelectList(db.Worker, "UserId", "RoleId", docMetaData.UserId);
            return View(docMetaData);
        }

        // POST: DocMetaDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DocId,DocName,DocCreationDate,PatientId,UserId")] DocMetaData docMetaData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(docMetaData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PatientId = new SelectList(db.PatientRecord, "PatientId", "TreatmentId", docMetaData.PatientId);
            ViewBag.UserId = new SelectList(db.Worker, "UserId", "RoleId", docMetaData.UserId);
            return View(docMetaData);
        }

        // GET: DocMetaDatas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocMetaData docMetaData = db.DocMetaData.Find(id);
            if (docMetaData == null)
            {
                return HttpNotFound();
            }
            return View(docMetaData);
        }

        // POST: DocMetaDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DocMetaData docMetaData = db.DocMetaData.Find(id);
            db.DocMetaData.Remove(docMetaData);
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
