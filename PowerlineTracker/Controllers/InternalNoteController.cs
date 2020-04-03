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
    public class InternalNoteController : Controller
    {
        private Context db = new Context();

        // GET: InternalNote
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewData["PowerlineID"] = id;

            var dataIN = db.InternalNotes.Where(q => q.PowerlineID==id).ToList();

            return View(dataIN);
        }

        // GET: InternalNote/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InternalNote internalNote = db.InternalNotes.Find(id);
            if (internalNote == null)
            {
                return HttpNotFound();
            }
            return View(internalNote);
        }

        // GET: InternalNote/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InternalNote/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PowerlineID,Number,Date,Theme,Department")] InternalNote internalNote)
        {                       
            if (ModelState.IsValid)
            {
                db.InternalNotes.Add(internalNote);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = internalNote.PowerlineID});
            }

            return View(internalNote);
        }

        // GET: InternalNote/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InternalNote internalNote = db.InternalNotes.Find(id);
            if (internalNote == null)
            {
                return HttpNotFound();
            }
            return View(internalNote);
        }

        // POST: InternalNote/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Number,Date,Theme,Department")] InternalNote internalNote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(internalNote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = internalNote.PowerlineID });
            }
            return View(internalNote);
        }

        // GET: InternalNote/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InternalNote internalNote = db.InternalNotes.Find(id);
            if (internalNote == null)
            {
                return HttpNotFound();
            }
            return View(internalNote);
        }

        // POST: InternalNote/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InternalNote internalNote = db.InternalNotes.Find(id);
            db.InternalNotes.Remove(internalNote);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = internalNote.PowerlineID });
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
