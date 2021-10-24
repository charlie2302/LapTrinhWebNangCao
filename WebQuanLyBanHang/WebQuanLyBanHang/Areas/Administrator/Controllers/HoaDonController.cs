using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebQuanLyBanHang.Model;

namespace WebQuanLyBanHang.Areas.Administrator.Controllers
{
    public class HoaDonController : Controller
    {
        private WebQuanLyBanHangDbContext db = new WebQuanLyBanHangDbContext();

        // GET: Administrator/HoaDon
        public ActionResult Index()
        {
            var hoaDons = db.HoaDons.Include(h => h.KhachHang).Include(h => h.NhanVien);
            return View(hoaDons.ToList());
        }

        // GET: Administrator/HoaDon/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // GET: Administrator/HoaDon/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoTen");
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "HoTen");
            return View();
        }

        // POST: Administrator/HoaDon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHD,MaNV,MaKH,NgayMuaHang,NgayGiaoHang,TongHoaDon")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.HoaDons.Add(hoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoTen", hoaDon.MaKH);
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "HoTen", hoaDon.MaNV);
            return View(hoaDon);
        }

        // GET: Administrator/HoaDon/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoTen", hoaDon.MaKH);
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "HoTen", hoaDon.MaNV);
            return View(hoaDon);
        }

        // POST: Administrator/HoaDon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHD,MaNV,MaKH,NgayMuaHang,NgayGiaoHang,TongHoaDon")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoTen", hoaDon.MaKH);
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "HoTen", hoaDon.MaNV);
            return View(hoaDon);
        }

        // GET: Administrator/HoaDon/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // POST: Administrator/HoaDon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
            db.HoaDons.Remove(hoaDon);
            db.SaveChanges();
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
