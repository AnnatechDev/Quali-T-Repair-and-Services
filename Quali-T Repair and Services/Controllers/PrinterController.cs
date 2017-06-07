using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Quali_T_Repair_and_Services.Models;

namespace Quali_T_Repair_and_Services.Controllers
{
    public class PrinterController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Printer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Printer/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Printers printers = await db.Printers.FindAsync(id);
            if (printers == null)
            {
                return HttpNotFound();
            }
            return View(printers);
        }

        // GET: Printer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Printer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,PrintColor,Processor,PrintCatridges,Wireless,SystemRequirements,MobilePrinting,TypeofPrinter,Dimensions,Weight")] Printers printers)
        {
            if (ModelState.IsValid)
            {
                db.Printers.Add(printers);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(printers);
        }

        // GET: Printer/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Printers printers = await db.Printers.FindAsync(id);
            if (printers == null)
            {
                return HttpNotFound();
            }
            return View(printers);
        }

        // POST: Printer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,PrintColor,Processor,PrintCatridges,Wireless,SystemRequirements,MobilePrinting,TypeofPrinter,Dimensions,Weight")] Printers printers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(printers).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(printers);
        }

        // GET: Printer/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Printers printers = await db.Printers.FindAsync(id);
            if (printers == null)
            {
                return HttpNotFound();
            }
            return View(printers);
        }

        // POST: Printer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Printers printers = await db.Printers.FindAsync(id);
            db.Printers.Remove(printers);
            await db.SaveChangesAsync();
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
