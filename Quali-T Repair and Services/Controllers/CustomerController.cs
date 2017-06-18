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
using Quali_T_Repair_and_Services.ViewModels;

namespace Quali_T_Repair_and_Services.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customer
        public ActionResult Index()
        {
            var customer = db.Customer.Include(c => c.CustomerType);
            return View(customer);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            Customer customer = db.Customer.Find(id);
            var customertype = db.CustomerType.Where(user => user.CustomerTypeId == customer.CustomerTypeId).FirstOrDefault();

            var newCustomer = new Customer
            {
                CustomerId = customer.CustomerId,
                Firstname = customer.Firstname,
                Lastname = customer.Lastname,
                UserName = customer.UserName,
                Email = customer.Email,
                BillingAddress = customer.BillingAddress,
                DateOfBirth = customer.DateOfBirth,
                MobileNumber = customer.MobileNumber,
                CustomerTypeId = customer.CustomerTypeId
            };

            if (Session["UserId"] != null)
            {
                return View(newCustomer);
            }
            else
            {
                return RedirectToAction("Login");
            } 
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            var customerTypes = db.CustomerType.ToList();

            var customerViewModel = new CustomerViewModel
            {
                CustomerType = customerTypes
            }; 
            return View(customerViewModel);
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
         
            if (ModelState.IsValid)
            { 
                customer.MemberSince = DateTime.Now.Date;
                customer.IsActive = true;
                customer.IsDeleted = false;

                db.Customer.Add(customer);
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.Message = customer.Firstname + " " + customer.Lastname + "successfully registered";

                return RedirectToAction("Login");
            }
            return View(customer);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Customer customerLogin)
        {
            var customer = db.Customer.Where(user => user.Email == customerLogin.Email && user.Password == customerLogin.Password).FirstOrDefault();
            if (customer != null)
            {
                Session["UserId"] = customer.CustomerId.ToString();
                Session["Email"] = customer.Email.ToString();
                Session["Username"] = customer.UserName.ToString();

                return RedirectToAction("Details", new { id = Session["UserId"].ToString()} );
            }
            else
            {
                ModelState.Clear();
                ViewBag.Message = customer.Firstname + " " + customer.Lastname + "successfully registered";
            }
            
               
            return View();
        }

        // GET: Customer/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = await db.Customer.FindAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerAddressId = new SelectList(db.CustomerType, "AddressId", "BillingAddress", customer.CustomerTypeId);
            return View(customer);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CustomerId,Firstname,Lastname,Email,UserName,MobileNumber,DateOfBirth,Password,ConfirmPassword,MemberSince,IsActive,IsDeleted,CustomerAddressId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerAddressId = new SelectList(db.CustomerType, "AddressId", "BillingAddress", customer.CustomerTypeId);
            return View(customer);
        }

        // GET: Customer/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = await db.Customer.FindAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Customer customer = await db.Customer.FindAsync(id);
            db.Customer.Remove(customer);
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
