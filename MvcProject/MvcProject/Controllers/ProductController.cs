using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProject.Models.Entity;

namespace MvcProject.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        MvcProjectDBEntities db = new MvcProjectDBEntities();
        public ActionResult Index()
        {
            var values = db.product.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            //Listeden öğe seç.
            List<SelectListItem> values = (from i in db.category.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.categoryName,
                                               Value = i.categoryId.ToString()
                                           }).ToList();
            ViewBag.values = values; // diğer sayfaya değer taşıma
                                           
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(product product)
        {
            if (!ModelState.IsValid) //doğrulama yapılmadıysa
            {
                return View("AddProduct");
            }
            db.product.Add(product);
            db.SaveChanges();
            return View();
        }
        public ActionResult Delete(int id)
        {
            var product = db.product.Find(id);
            db.product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult productList(int id)
        {
            var product = db.product.Find(id);




            List<SelectListItem> values = (from i in db.category.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.categoryName,
                                               Value = i.categoryId.ToString()
                                           }).ToList();
            ViewBag.values = values; // diğer sayfaya değer taşıma




            return View("productList", product);

        }
        public ActionResult Update(product product)
        {
            var products = db.product.Find(product.productId);
            products.productName = product.productName;
            var category = db.category.Where(m => m.categoryId == product.category.categoryId).FirstOrDefault();
            products.productCategory = category.categoryId;
            products.productUnitPrice = product.productUnitPrice;
            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}