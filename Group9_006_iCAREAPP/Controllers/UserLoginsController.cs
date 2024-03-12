using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Group9_006_iCAREAPP.Models;
using System.Data.SqlClient;

namespace Group9_006_iCAREAPP.Controllers
{
    public class UserLoginsController : Controller
    {
        private Group9_006_iCAREDBEntities1 db = new Group9_006_iCAREDBEntities1();
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
  

        void connectionString()
        {
            conn.ConnectionString = "Data Source=DESKTOP-7UQ6PKP\\SQLEXPRESS;Initial Catalog=Group9_006_iCAREDB;Integrated Security=True";


        }

        // Verify UserPasswords
        [HttpPost]
        public ActionResult Verify(Login login)
        {
            connectionString();
            conn.Open();

            com.Connection = conn;

            com.CommandText = "select * from UserLogin where UserName='" + login.UserName + "' and Password='" + login.Password + "'";

            dr = com.ExecuteReader();

            if (dr.Read())
            {
                conn.Close();



                if ((login.UserName == "Admin") && (login.Password == "Admin@123"))
                {
                    return View("AdminPage");
                }
                else
                {
                    return View("WorkerPage");
                }


            }
            else
            {
                conn.Close();
                return View("Error");
            }
        }

            // GET: UserLogins
            public ActionResult Index()
        {
            var userLogin = db.UserLogin.Include(u => u.User);
            return View(userLogin.ToList());
        }

        // GET: UserLogins/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLogin userLogin = db.UserLogin.Find(id);
            if (userLogin == null)
            {
                return HttpNotFound();
            }
            return View(userLogin);
        }

        // GET: UserLogins/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.User, "UserId", "Name");
            return View();
        }

        // POST: UserLogins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,UserName,Password,PasswordExpiryTime,UserAccountExpiryDate")] UserLogin userLogin)
        {
            if (ModelState.IsValid)
            {
                db.UserLogin.Add(userLogin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.User, "UserId", "Name", userLogin.UserId);
            return View(userLogin);
        }

        // GET: UserLogins/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLogin userLogin = db.UserLogin.Find(id);
            if (userLogin == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.User, "UserId", "Name", userLogin.UserId);
            return View(userLogin);
        }

        // POST: UserLogins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,UserName,Password,PasswordExpiryTime,UserAccountExpiryDate")] UserLogin userLogin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userLogin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.User, "UserId", "Name", userLogin.UserId);
            return View(userLogin);
        }

        // GET: UserLogins/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLogin userLogin = db.UserLogin.Find(id);
            if (userLogin == null)
            {
                return HttpNotFound();
            }
            return View(userLogin);
        }

        // POST: UserLogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserLogin userLogin = db.UserLogin.Find(id);
            db.UserLogin.Remove(userLogin);
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
