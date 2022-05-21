using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProject.Models.Entity;
namespace MvcProject.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        MvcProjectDBEntities db = new MvcProjectDBEntities();
        public ActionResult Index()
        {
            var values = db.sales.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddSales()
        {
            if (!ModelState.IsValid) //doğrulama yapılmadıysa
            {
                return View("AddSales");
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddSales(sales sales)
        {
            db.sales.Add(sales);
            db.SaveChanges();
            return View();
        }
        public ActionResult Delete(int id)
        {
            var sales = db.sales.Find(id);
            db.sales.Remove(sales);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult salesList(int id)
        {
            var sales = db.sales.Find(id);
            return View("salesList", sales);
        }
    }
}