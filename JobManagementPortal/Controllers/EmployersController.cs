using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobManagementPortal.Context;

namespace JobManagementPortal.Controllers
{
    public class EmployersController : Controller
    {
        private JobManagementDBEntities db = new JobManagementDBEntities();

        // GET: Employers
        public ActionResult Index()
        {
            var tbl_employers = db.tbl_employers.Include(t => t.tbl_users);
            return View(tbl_employers.ToList());
        }

        // GET: Employers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_employers tbl_employers = db.tbl_employers.Find(id);
            if (tbl_employers == null)
            {
                return HttpNotFound();
            }
            return View(tbl_employers);
        }

        // GET: Employers/Create
        public ActionResult Create()
        {
            ViewBag.user_id = new SelectList(db.tbl_users, "Id", "first_name");
            return View();
        }

        // POST: Employers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,company_name,company_location,company_description")] tbl_employers tbl_employers)
        {
            if (ModelState.IsValid)
            {
                tbl_employers.user_id = (int)Session["id"];
                db.tbl_employers.Add(tbl_employers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_id = new SelectList(db.tbl_users, "Id", "first_name", tbl_employers.user_id);
            return View(tbl_employers);
        }

        // GET: Employers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_employers tbl_employers = db.tbl_employers.Find(id);
            if (tbl_employers == null)
            {
                return HttpNotFound();
            }
            return View(tbl_employers);
        }

        // POST: Employers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,company_name,company_location,company_description")] tbl_employers tbl_employers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_employers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_employers);
        }

        // GET: Employers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_employers tbl_employers = db.tbl_employers.Find(id);
            if (tbl_employers == null)
            {
                return HttpNotFound();
            }
            return View(tbl_employers);
        }

        // POST: Employers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_employers tbl_employers = db.tbl_employers.Find(id);
            db.tbl_employers.Remove(tbl_employers);
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
