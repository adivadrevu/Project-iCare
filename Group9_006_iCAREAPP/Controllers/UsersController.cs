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
    public class UsersController : Controller
    {
        private Group9_006_iCAREDBEntities1 db = new Group9_006_iCAREDBEntities1();

        // GET: Users
        public ActionResult Index()
        {
            var user = db.User.Include(u => u.Admin).Include(u => u.UserLogin).Include(u => u.Worker);
            return View(user.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Admin, "UserId", "UserId");
            ViewBag.UserId = new SelectList(db.UserLogin, "UserId", "UserName");
            ViewBag.UserId = new SelectList(db.Worker, "UserId", "RoleId");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,Name")] User user)
        {
            if (ModelState.IsValid)
            {
                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Admin, "UserId", "UserId", user.UserId);
            ViewBag.UserId = new SelectList(db.UserLogin, "UserId", "UserName", user.UserId);
            ViewBag.UserId = new SelectList(db.Worker, "UserId", "RoleId", user.UserId);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Admin, "UserId", "UserId", user.UserId);
            ViewBag.UserId = new SelectList(db.UserLogin, "UserId", "UserName", user.UserId);
            ViewBag.UserId = new SelectList(db.Worker, "UserId", "RoleId", user.UserId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,Name")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Admin, "UserId", "UserId", user.UserId);
            ViewBag.UserId = new SelectList(db.UserLogin, "UserId", "UserName", user.UserId);
            ViewBag.UserId = new SelectList(db.Worker, "UserId", "RoleId", user.UserId);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            User user = db.User.Find(id);
            db.User.Remove(user);
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
