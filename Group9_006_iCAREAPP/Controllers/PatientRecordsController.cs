﻿using System;
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
    public class PatientRecordsController : Controller
    {
        private Group9_006_iCAREDBEntities1 db = new Group9_006_iCAREDBEntities1();

        // GET: PatientRecords
        public ActionResult Index()
        {
            var patientRecord = db.PatientRecord.Include(p => p.GeoCode).Include(p => p.Worker);
            return View(patientRecord.ToList());
        }

        // GET: PatientRecords/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientRecord patientRecord = db.PatientRecord.Find(id);
            if (patientRecord == null)
            {
                return HttpNotFound();
            }
            return View(patientRecord);
        }

        // GET: PatientRecords/Create
        public ActionResult Create()
        {
            ViewBag.GeoId = new SelectList(db.GeoCode, "GeoId", "Place");
            ViewBag.UserId = new SelectList(db.Worker, "UserId", "RoleId");
            return View();
        }

        // POST: PatientRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientId,TreatmentId,PatientName,Address,DateOfBirth,Height,Weight,BloodGroup,BedId,TreatmentArea,GeoId,UserId")] PatientRecord patientRecord)
        {
            if (ModelState.IsValid)
            {
                db.PatientRecord.Add(patientRecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GeoId = new SelectList(db.GeoCode, "GeoId", "Place", patientRecord.GeoId);
            ViewBag.UserId = new SelectList(db.Worker, "UserId", "RoleId", patientRecord.UserId);
            return View(patientRecord);
        }

        // GET: PatientRecords/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientRecord patientRecord = db.PatientRecord.Find(id);
            if (patientRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.GeoId = new SelectList(db.GeoCode, "GeoId", "Place", patientRecord.GeoId);
            ViewBag.UserId = new SelectList(db.Worker, "UserId", "RoleId", patientRecord.UserId);
            return View(patientRecord);
        }

        // POST: PatientRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatientId,TreatmentId,PatientName,Address,DateOfBirth,Height,Weight,BloodGroup,BedId,TreatmentArea,GeoId,UserId")] PatientRecord patientRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patientRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GeoId = new SelectList(db.GeoCode, "GeoId", "Place", patientRecord.GeoId);
            ViewBag.UserId = new SelectList(db.Worker, "UserId", "RoleId", patientRecord.UserId);
            return View(patientRecord);
        }

        // GET: PatientRecords/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientRecord patientRecord = db.PatientRecord.Find(id);
            if (patientRecord == null)
            {
                return HttpNotFound();
            }
            return View(patientRecord);
        }

        // POST: PatientRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PatientRecord patientRecord = db.PatientRecord.Find(id);
            db.PatientRecord.Remove(patientRecord);
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
