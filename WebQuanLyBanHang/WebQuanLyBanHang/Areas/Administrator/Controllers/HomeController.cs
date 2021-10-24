using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuanLyBanHang.Model;

namespace WebQuanLyBanHang.Areas.Administrator.Controllers
{
    public class HomeController : Controller
    {
        WebQuanLyBanHangDbContext db = new WebQuanLyBanHangDbContext();
        // GET: Administrator/Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            User user = db.Users.SingleOrDefault(x => x.Username == username && x.Password == password && x.Allowed == 1);
            if (user != null)
            {
                Session["userid"] = user.Userid;
                Session["username"] = user.Username;
                Session["avatar"] = user.Avatar;
                return RedirectToAction("Index");
                //mé, lưu gì lắm session vậy== Mạng dạy:>
            }
            ViewBag.error = "Sai tên đăng nhập hoặc mật khẩu!";
            return View();
        }
    }
}