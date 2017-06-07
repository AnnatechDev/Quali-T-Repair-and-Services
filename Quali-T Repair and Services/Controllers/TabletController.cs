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
    public class TabletController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tablet
        public ActionResult Index()
        {
            return View();
        }

        // GET: Tablet/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tablets tablets = await db.Tablets.FindAsync(id);
            if (tablets == null)
            {
                return HttpNotFound();
            }
            return View(tablets);
        }

        // GET: Tablet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tablet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,OperatingSystem,Cpu,Camera,InternalMemory,CardSlot,Resolution,Sensors,Weight,Sim,Rating,Network")] Tablets tablets)
        {
            if (ModelState.IsValid)
            {
                db.Tablets.Add(tablets);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tablets);
        }

        // GET: Tablet/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tablets tablets = await db.Tablets.FindAsync(id);
            if (tablets == null)
            {
                return HttpNotFound();
            }
            return View(tablets);
        }

        // POST: Tablet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,OperatingSystem,Cpu,Camera,InternalMemory,CardSlot,Resolution,Sensors,Weight,Sim,Rating,Network")] Tablets tablets)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tablets).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tablets);
        }

        // GET: Tablet/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tablets tablets = await db.Tablets.FindAsync(id);
            if (tablets == null)
            {
                return HttpNotFound();
            }
            return View(tablets);
        }

        // POST: Tablet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Tablets tablets = await db.Tablets.FindAsync(id);
            db.Tablets.Remove(tablets);
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
