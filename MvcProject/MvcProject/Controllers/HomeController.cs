using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Hakkımızda Sayfasına Hoş Geldiniz.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "İletişim Sayfasına Hoş Geldiniz.";

            return View();
        }

        public ActionResult Category()
        {
            ViewBag.Message = "Kategori Sayfasına Hoş Geldiniz.";

            return View();
        }

        public ActionResult Customer()
        {
            ViewBag.Message = "Müşteri Sayfasına Hoş Geldiniz.";

            return View();
        }

        public ActionResult Sales()
        {
            ViewBag.Message = "Satış Sayfasına Hoş Geldiniz.";

            return View();
        }

        public ActionResult Product()
        {
            ViewBag.Message = "Ürün Sayfasına Hoş Geldiniz.";

            return View();
        }
    }
}