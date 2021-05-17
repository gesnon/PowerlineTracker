using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using OfficeOpenXml;
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
        public ActionResult Edit([Bind(Include = "ID,Name,Comments")] Powerline powerline)
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

        public byte[] BuildFile()
        {
            string tempDir = Path.GetTempPath();
            var tempFile = Path.Combine(tempDir, Guid.NewGuid() + ".xlsx");

            using (var package = new ExcelPackage())
            {
                List<TypeOfContract> types = new List<TypeOfContract> { new TypeOfContract { ID = 1, Name = "NameOne" }, new TypeOfContract { ID = 2, Name = "NameTwo" }, new TypeOfContract { ID = 3, Name = "NameThree" } };

                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report"); // Добавляет в эксель новый лист
                SaveToExcell(worksheet, types);
                var xlFile = GetFileInfo(tempFile);
                package.SaveAs(xlFile);
            }

            byte[] file = new byte[0];            
 
            if (System.IO.File.Exists(tempFile))
            {
                file = System.IO.File.ReadAllBytes(tempFile);
                System.IO.File.Delete(tempFile);
            }

            return file;
        }

        private FileInfo GetFileInfo(string file, bool deleteIfExists = true)
        {
            var fi = new FileInfo(file);
            if (deleteIfExists && fi.Exists)
            {
                fi.Delete();
            }
            return fi;
        }
        public void SaveToExcell(ExcelWorksheet worksheet, List<TypeOfContract> typesOFContract)
        {
            for (int i = 0; i < typesOFContract.Count; i++)
            {
                worksheet.Cells[i + 2, 1].Value = $"ID: {typesOFContract[i].ID} ";
                worksheet.Cells[i + 2, 2].Value = $"Наименование: {typesOFContract[i].Name}";

            }
        }
        public IHttpActionResult DownloadFile() {

            byte[] buildFile = BuildFile();

            var Stream = new MemoryStream(buildFile);

            return new FileResult(Stream, Request, "TypesOfContract");
        }
    }
}
