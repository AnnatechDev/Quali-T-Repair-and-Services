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
    public class LaptopController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }


        // GET: Laptops/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laptops laptops = await db.Laptops.FindAsync(id);
            if (laptops == null)
            {
                return HttpNotFound();
            }
            return View(laptops);
        }

        // GET: Laptops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Laptops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Manufacturer,Processor,FormFactor,Rating,SerialNumber,ModelNumber,DateManufactured,ScreenResolution")] Laptops laptops)
        {
            if (ModelState.IsValid)
            {
                db.Laptops.Add(laptops);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(laptops);
        }

        // GET: Laptops/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laptops laptops = await db.Laptops.FindAsync(id);
            if (laptops == null)
            {
                return HttpNotFound();
            }
            return View(laptops);
        }

        // POST: Laptops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Manufacturer,Processor,FormFactor,Rating,SerialNumber,ModelNumber,DateManufactured,ScreenResolution")] Laptops laptops)
        {
            if (ModelState.IsValid)
            {
                db.Entry(laptops).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(laptops);
        }

        // GET: Laptops/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laptops laptops = await db.Laptops.FindAsync(id);
            if (laptops == null)
            {
                return HttpNotFound();
            }
            return View(laptops);
        }

        // POST: Laptops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Laptops laptops = await db.Laptops.FindAsync(id);
            db.Laptops.Remove(laptops);
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
