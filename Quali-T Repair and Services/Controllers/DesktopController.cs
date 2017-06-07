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
    public class DesktopController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Desktop
        public ActionResult Index()
        {
            return View();
        }

        // GET: Desktop/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Desktops desktops = await db.Desktops.FindAsync(id);
            if (desktops == null)
            {
                return HttpNotFound();
            }
            return View(desktops);
        }

        // GET: Desktop/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Desktop/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Manufacturer,Processor,Rating,SystemType,ModelNumber,SerialNumber,DateManufactured,GraphicsCard,OpticalDrive,ScreenResolution")] Desktops desktops)
        {
            if (ModelState.IsValid)
            {
                db.Desktops.Add(desktops);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(desktops);
        }

        // GET: Desktop/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Desktops desktops = await db.Desktops.FindAsync(id);
            if (desktops == null)
            {
                return HttpNotFound();
            }
            return View(desktops);
        }

        // POST: Desktop/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Manufacturer,Processor,Rating,SystemType,ModelNumber,SerialNumber,DateManufactured,GraphicsCard,OpticalDrive,ScreenResolution")] Desktops desktops)
        {
            if (ModelState.IsValid)
            {
                db.Entry(desktops).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(desktops);
        }

        // GET: Desktop/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Desktops desktops = await db.Desktops.FindAsync(id);
            if (desktops == null)
            {
                return HttpNotFound();
            }
            return View(desktops);
        }

        // POST: Desktop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Desktops desktops = await db.Desktops.FindAsync(id);
            db.Desktops.Remove(desktops);
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
