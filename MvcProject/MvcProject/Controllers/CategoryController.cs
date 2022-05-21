using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProject.Models.Entity;
namespace MvcProject.Controllers
{

    public class CategoryController : Controller
    {


    
        // GET: Category
        MvcProjectDBEntities db = new MvcProjectDBEntities();

        public ActionResult Index()
        {
            var values = db.category.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(category category)
        {
            if(!ModelState.IsValid) //doğrulama yapılmadıysa
            {
                return View("AddCategory");
            }
            db.category.Add(category);
            db.SaveChanges();
            return View();
        }

        public ActionResult Delete(int id)
        {
            var category = db.category.Find(id);
            db.category.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult categoryList(int id)
        {
            var category = db.category.Find(id);
            return View("categoryList",category);
        }
        public ActionResult Update(category category)
        {
            var categories = db.category.Find(category.categoryId);
            categories.categoryName = category.categoryName;
            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}