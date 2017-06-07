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
    public class SmartphonesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Smartphones
        public ActionResult Index()
        {
            return View();
        }

        // GET: Smartphones/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smartphones smartphones = await db.Smartphones.FindAsync(id);
            if (smartphones == null)
            {
                return HttpNotFound();
            }
            return View(smartphones);
        }

        // GET: Smartphones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Smartphones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Manufacturer,FormFactor,OperatingSystem,sim,Camera,Comms,Sound,Memory,Sensors,Battery,Colors")] Smartphones smartphones)
        {
            if (ModelState.IsValid)
            {
                db.Smartphones.Add(smartphones);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(smartphones);
        }

        // GET: Smartphones/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smartphones smartphones = await db.Smartphones.FindAsync(id);
            if (smartphones == null)
            {
                return HttpNotFound();
            }
            return View(smartphones);
        }

        // POST: Smartphones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Manufacturer,FormFactor,OperatingSystem,sim,Camera,Comms,Sound,Memory,Sensors,Battery,Colors")] Smartphones smartphones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(smartphones).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(smartphones);
        }

        // GET: Smartphones/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smartphones smartphones = await db.Smartphones.FindAsync(id);
            if (smartphones == null)
            {
                return HttpNotFound();
            }
            return View(smartphones);
        }

        // POST: Smartphones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Smartphones smartphones = await db.Smartphones.FindAsync(id);
            db.Smartphones.Remove(smartphones);
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
