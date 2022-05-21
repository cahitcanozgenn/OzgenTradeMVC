using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProject.Models.Entity;

namespace MvcProject.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        MvcProjectDBEntities db = new MvcProjectDBEntities();
        public ActionResult Index()
        {
            var values = db.customer.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(customer customer)
        {
            if (!ModelState.IsValid) //doğrulama yapılmadıysa
            {
                return View("AddCustomer");
            }
            db.customer.Add(customer);
            db.SaveChanges();
            return View();
        }
        public ActionResult Delete(int id)
        {
            var customer = db.customer.Find(id);
            db.customer.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult customerList(int id)
        {
            var customer = db.customer.Find(id);
            return View("customerList", customer);
        }
        public ActionResult Update(customer customer)
        {
            var customers = db.customer.Find(customer.customerId);
            customers.firstName = customer.firstName;
            customers.lastName = customer.lastName;
            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}