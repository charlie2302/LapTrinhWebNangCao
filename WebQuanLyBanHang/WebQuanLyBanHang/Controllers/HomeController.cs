using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuanLyBanHang.Model;

namespace WebQuanLyBanHang.Controllers
{
    public class HomeController : Controller
    {
        WebQuanLyBanHangDbContext db = new WebQuanLyBanHangDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Loadproducts() 
        { //Gọi thế nào?
            var sp = db.SanPhams;
            return PartialView(sp);
        }
        public ActionResult Loadproducts2()
        {
            var sp = db.SanPhams;
            return PartialView(sp);
        }
        public ActionResult Loadproducts3()
        {
            var sp = db.SanPhams;
            return PartialView(sp);
        }
    }
}