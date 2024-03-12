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
    public class TreatmentRecordsController : Controller
    {
        private Group9_006_iCAREDBEntities1 db = new Group9_006_iCAREDBEntities1();

        // GET: TreatmentRecords
        public ActionResult Index()
        {
            var treatmentRecord = db.TreatmentRecord.Include(t => t.PatientRecord).Include(t => t.Worker);
            return View(treatmentRecord.ToList());
        }

        // GET: TreatmentRecords/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreatmentRecord treatmentRecord = db.TreatmentRecord.Find(id);
            if (treatmentRecord == null)
            {
                return HttpNotFound();
            }
            return View(treatmentRecord);
        }

        // GET: TreatmentRecords/Create
        public ActionResult Create()
        {
            ViewBag.PatientId = new SelectList(db.PatientRecord, "PatientId", "TreatmentId");
            ViewBag.UserId = new SelectList(db.Worker, "UserId", "RoleId");
            return View();
        }

        // POST: TreatmentRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TreatmentId,Description,TreatmentDate,UserId,PatientId")] TreatmentRecord treatmentRecord)
        {
            if (ModelState.IsValid)
            {
                db.TreatmentRecord.Add(treatmentRecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PatientId = new SelectList(db.PatientRecord, "PatientId", "TreatmentId", treatmentRecord.PatientId);
            ViewBag.UserId = new SelectList(db.Worker, "UserId", "RoleId", treatmentRecord.UserId);
            return View(treatmentRecord);
        }

        // GET: TreatmentRecords/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreatmentRecord treatmentRecord = db.TreatmentRecord.Find(id);
            if (treatmentRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatientId = new SelectList(db.PatientRecord, "PatientId", "TreatmentId", treatmentRecord.PatientId);
            ViewBag.UserId = new SelectList(db.Worker, "UserId", "RoleId", treatmentRecord.UserId);
            return View(treatmentRecord);
        }

        // POST: TreatmentRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TreatmentId,Description,TreatmentDate,UserId,PatientId")] TreatmentRecord treatmentRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(treatmentRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PatientId = new SelectList(db.PatientRecord, "PatientId", "TreatmentId", treatmentRecord.PatientId);
            ViewBag.UserId = new SelectList(db.Worker, "UserId", "RoleId", treatmentRecord.UserId);
            return View(treatmentRecord);
        }

        // GET: TreatmentRecords/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreatmentRecord treatmentRecord = db.TreatmentRecord.Find(id);
            if (treatmentRecord == null)
            {
                return HttpNotFound();
            }
            return View(treatmentRecord);
        }

        // POST: TreatmentRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TreatmentRecord treatmentRecord = db.TreatmentRecord.Find(id);
            db.TreatmentRecord.Remove(treatmentRecord);
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
