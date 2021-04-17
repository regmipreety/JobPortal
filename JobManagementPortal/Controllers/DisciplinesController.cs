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
    public class DisciplinesController : Controller
    {
        private JobManagementDBEntities db = new JobManagementDBEntities();

        // GET: Disciplines
        public ActionResult Index()
        {
            return View(db.tbl_disciplines.ToList());
        }

        // GET: Disciplines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_disciplines tbl_disciplines = db.tbl_disciplines.Find(id);
            if (tbl_disciplines == null)
            {
                return HttpNotFound();
            }
            return View(tbl_disciplines);
        }

        // GET: Disciplines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Disciplines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name")] tbl_disciplines tbl_disciplines)
        {
            if (ModelState.IsValid)
            {
                db.tbl_disciplines.Add(tbl_disciplines);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_disciplines);
        }

        // GET: Disciplines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_disciplines tbl_disciplines = db.tbl_disciplines.Find(id);
            if (tbl_disciplines == null)
            {
                return HttpNotFound();
            }
            return View(tbl_disciplines);
        }

        // POST: Disciplines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name")] tbl_disciplines tbl_disciplines)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_disciplines).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_disciplines);
        }

        // GET: Disciplines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_disciplines tbl_disciplines = db.tbl_disciplines.Find(id);
            if (tbl_disciplines == null)
            {
                return HttpNotFound();
            }
            return View(tbl_disciplines);
        }

        // POST: Disciplines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_disciplines tbl_disciplines = db.tbl_disciplines.Find(id);
            db.tbl_disciplines.Remove(tbl_disciplines);
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
