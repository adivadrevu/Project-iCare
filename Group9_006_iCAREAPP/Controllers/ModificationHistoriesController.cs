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
    public class ModificationHistoriesController : Controller
    {
        private Group9_006_iCAREDBEntities1 db = new Group9_006_iCAREDBEntities1();

        // GET: ModificationHistories
        public ActionResult Index()
        {
            var modificationHistory = db.ModificationHistory.Include(m => m.DocMetaData).Include(m => m.Worker);
            return View(modificationHistory.ToList());
        }

        // GET: ModificationHistories/Details/5
        public ActionResult Details(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModificationHistory modificationHistory = db.ModificationHistory.Find(id);
            if (modificationHistory == null)
            {
                return HttpNotFound();
            }
            return View(modificationHistory);
        }

        // GET: ModificationHistories/Create
        public ActionResult Create()
        {
            ViewBag.DocId = new SelectList(db.DocMetaData, "DocId", "DocName");
            ViewBag.UserId = new SelectList(db.Worker, "UserId", "RoleId");
            return View();
        }

        // POST: ModificationHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DateOfModification,Description,DocId,UserId")] ModificationHistory modificationHistory)
        {
            if (ModelState.IsValid)
            {
                db.ModificationHistory.Add(modificationHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DocId = new SelectList(db.DocMetaData, "DocId", "DocName", modificationHistory.DocId);
            ViewBag.UserId = new SelectList(db.Worker, "UserId", "RoleId", modificationHistory.UserId);
            return View(modificationHistory);
        }

        // GET: ModificationHistories/Edit/5
        public ActionResult Edit(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModificationHistory modificationHistory = db.ModificationHistory.Find(id);
            if (modificationHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.DocId = new SelectList(db.DocMetaData, "DocId", "DocName", modificationHistory.DocId);
            ViewBag.UserId = new SelectList(db.Worker, "UserId", "RoleId", modificationHistory.UserId);
            return View(modificationHistory);
        }

        // POST: ModificationHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DateOfModification,Description,DocId,UserId")] ModificationHistory modificationHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modificationHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DocId = new SelectList(db.DocMetaData, "DocId", "DocName", modificationHistory.DocId);
            ViewBag.UserId = new SelectList(db.Worker, "UserId", "RoleId", modificationHistory.UserId);
            return View(modificationHistory);
        }

        // GET: ModificationHistories/Delete/5
        public ActionResult Delete(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModificationHistory modificationHistory = db.ModificationHistory.Find(id);
            if (modificationHistory == null)
            {
                return HttpNotFound();
            }
            return View(modificationHistory);
        }

        // POST: ModificationHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DateTime id)
        {
            ModificationHistory modificationHistory = db.ModificationHistory.Find(id);
            db.ModificationHistory.Remove(modificationHistory);
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
