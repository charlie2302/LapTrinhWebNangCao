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
    public class CTHoaDonController : Controller
    {
        private WebQuanLyBanHangDbContext db = new WebQuanLyBanHangDbContext();

        // GET: Administrator/CTHoaDon
        public ActionResult Index()
        {
            var cTHoaDons = db.CTHoaDons.Include(c => c.HoaDon).Include(c => c.SanPham);
            return View(cTHoaDons.ToList());
        }

        // GET: Administrator/CTHoaDon/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTHoaDon cTHoaDon = db.CTHoaDons.Find(id);
            if (cTHoaDon == null)
            {
                return HttpNotFound();
            }
            return View(cTHoaDon);
        }

        // GET: Administrator/CTHoaDon/Create
        public ActionResult Create()
        {
            ViewBag.MaHD = new SelectList(db.HoaDons, "MaHD", "MaHD");
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP");
            
            return View();
        }

        // POST: Administrator/CTHoaDon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCTHD,MaHD,MaSP,Gia,SoLuong,ThanhTien,Voucher,PhiVanChuyen")] CTHoaDon cTHoaDon)
        {
            if (ModelState.IsValid)
            {
                db.CTHoaDons.Add(cTHoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHD = new SelectList(db.HoaDons, "MaHD", "MaHD", cTHoaDon.MaHD);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP", cTHoaDon.MaSP);
            return View(cTHoaDon);
        }

        // GET: Administrator/CTHoaDon/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTHoaDon cTHoaDon = db.CTHoaDons.Find(id);
            if (cTHoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHD = new SelectList(db.HoaDons, "MaHD", "MaHD", cTHoaDon.MaHD);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP", cTHoaDon.MaSP);
            return View(cTHoaDon);
        }

        // POST: Administrator/CTHoaDon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCTHD,MaHD,MaSP,Gia,SoLuong,ThanhTien,Voucher,PhiVanChuyen")] CTHoaDon cTHoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTHoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHD = new SelectList(db.HoaDons, "MaHD", "MaHD", cTHoaDon.MaHD);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP", cTHoaDon.MaSP);
            return View(cTHoaDon);
        }

        // GET: Administrator/CTHoaDon/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTHoaDon cTHoaDon = db.CTHoaDons.Find(id);
            if (cTHoaDon == null)
            {
                return HttpNotFound();
            }
            return View(cTHoaDon);
        }

        // POST: Administrator/CTHoaDon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CTHoaDon cTHoaDon = db.CTHoaDons.Find(id);
            db.CTHoaDons.Remove(cTHoaDon);
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
