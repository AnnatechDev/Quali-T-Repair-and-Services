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
    public class TvBoxController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Android_Tv_Box
        public ActionResult Index()
        {
            return View();
        }

        // GET: Android_Tv_Box/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TvBox android_Tv_Boxes = await db.Android_Tv_Boxes.FindAsync(id);
            if (android_Tv_Boxes == null)
            {
                return HttpNotFound();
            }
            return View(android_Tv_Boxes);
        }

        // GET: Android_Tv_Box/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Android_Tv_Box/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,OperatingSystem,Size,Hdmi,ModelNumber")] TvBox android_Tv_Boxes)
        {
            if (ModelState.IsValid)
            {
                db.Android_Tv_Boxes.Add(android_Tv_Boxes);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(android_Tv_Boxes);
        }

        // GET: Android_Tv_Box/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TvBox android_Tv_Boxes = await db.Android_Tv_Boxes.FindAsync(id);
            if (android_Tv_Boxes == null)
            {
                return HttpNotFound();
            }
            return View(android_Tv_Boxes);
        }

        // POST: Android_Tv_Box/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,OperatingSystem,Size,Hdmi,ModelNumber")] TvBox android_Tv_Boxes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(android_Tv_Boxes).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(android_Tv_Boxes);
        }

        // GET: Android_Tv_Box/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TvBox android_Tv_Boxes = await db.Android_Tv_Boxes.FindAsync(id);
            if (android_Tv_Boxes == null)
            {
                return HttpNotFound();
            }
            return View(android_Tv_Boxes);
        }

        // POST: Android_Tv_Box/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TvBox android_Tv_Boxes = await db.Android_Tv_Boxes.FindAsync(id);
            db.Android_Tv_Boxes.Remove(android_Tv_Boxes);
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
