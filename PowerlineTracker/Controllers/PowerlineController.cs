using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PowerlineTracker.DAL;
using PowerlineTracker.Models;

namespace PowerlineTracker.Controllers
{
    public class PowerlineController : Controller
    {
        private Context db = new Context();

        // GET: Powerline
        public ActionResult Index()
        {
            var data = db.Powerlines
                .Include(i => i.ContractPIR)
                .Include(i => i.ConractSMR)
                .Include(i => i.InternalNotes)
                .ToList();
            return View(data);
        }

        // GET: Powerline/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Powerline powerline = db.Powerlines
                .Include(i => i.ContractPIR)
                .Include(i => i.ConractSMR)
                .Include(i => i.InternalNotes)
                .FirstOrDefault(i => i.ID == id);
            if (powerline == null)
            {
                return HttpNotFound();
            }
            return View(powerline);
        }

        // GET: Powerline/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Powerline/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Powerline powerline)
        {
            if (ModelState.IsValid)
            {
                db.Powerlines.Add(powerline);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(powerline);
        }

        // GET: Powerline/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Powerline powerline = db.Powerlines.Find(id);
            if (powerline == null)
            {
                return HttpNotFound();
            }
            return View(powerline);
        }

        // POST: Powerline/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Powerline powerline)
        {
            if (ModelState.IsValid)
            {
                db.Entry(powerline).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(powerline);
        }

        // GET: Powerline/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Powerline powerline = db.Powerlines.Find(id);
            if (powerline == null)
            {
                return HttpNotFound();
            }
            return View(powerline);
        }

        // POST: Powerline/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Powerline powerline = db.Powerlines.Find(id);
            db.Powerlines.Remove(powerline);
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
