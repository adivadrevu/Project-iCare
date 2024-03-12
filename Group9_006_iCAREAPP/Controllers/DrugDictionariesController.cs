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
    public class DrugDictionariesController : Controller
    {
        private Group9_006_iCAREDBEntities1 db = new Group9_006_iCAREDBEntities1();

        // GET: DrugDictionaries
        public ActionResult Index()
        {
            return View(db.DrugDictionary.ToList());
        }
        public ActionResult Data()
        {
            return View(db.DrugDictionary.ToList());
        }
        // GET: DrugDictionaries/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrugDictionary drugDictionary = db.DrugDictionary.Find(id);
            if (drugDictionary == null)
            {
                return HttpNotFound();
            }
            return View(drugDictionary);
        }

        // GET: DrugDictionaries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DrugDictionaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DrugId,DrugName")] DrugDictionary drugDictionary)
        {
            if (ModelState.IsValid)
            {
                db.DrugDictionary.Add(drugDictionary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(drugDictionary);
        }

        // GET: DrugDictionaries/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrugDictionary drugDictionary = db.DrugDictionary.Find(id);
            if (drugDictionary == null)
            {
                return HttpNotFound();
            }
            return View(drugDictionary);
        }

        // POST: DrugDictionaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DrugId,DrugName")] DrugDictionary drugDictionary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drugDictionary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drugDictionary);
        }

        // GET: DrugDictionaries/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrugDictionary drugDictionary = db.DrugDictionary.Find(id);
            if (drugDictionary == null)
            {
                return HttpNotFound();
            }
            return View(drugDictionary);
        }

        // POST: DrugDictionaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DrugDictionary drugDictionary = db.DrugDictionary.Find(id);
            db.DrugDictionary.Remove(drugDictionary);
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
