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
    public class BaoCaoThongKeController : Controller
    {
        private WebQuanLyBanHangDbContext db = new WebQuanLyBanHangDbContext();

        // GET: Administrator/BaoCaoThongKe
        public ActionResult Index()
        {
            var baoCaoThongKes = db.BaoCaoThongKes.Include(b => b.NhanVien);
            return View(baoCaoThongKes.ToList());
        }

        // GET: Administrator/BaoCaoThongKe/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaoCaoThongKe baoCaoThongKe = db.BaoCaoThongKes.Find(id);
            if (baoCaoThongKe == null)
            {
                return HttpNotFound();
            }
            return View(baoCaoThongKe);
        }

        // GET: Administrator/BaoCaoThongKe/Create
        public ActionResult Create()
        {
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "MaNV");
            return View();
        }

        // POST: Administrator/BaoCaoThongKe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaBC,MaNV,TenNV,Thang")] BaoCaoThongKe baoCaoThongKe)
        {
            if (ModelState.IsValid)
            {
                db.BaoCaoThongKes.Add(baoCaoThongKe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "MaNV", baoCaoThongKe.MaNV);
            return View(baoCaoThongKe);
        }

        // GET: Administrator/BaoCaoThongKe/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaoCaoThongKe baoCaoThongKe = db.BaoCaoThongKes.Find(id);
            if (baoCaoThongKe == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "MaNV", baoCaoThongKe.MaNV);
            return View(baoCaoThongKe);
        }

        // POST: Administrator/BaoCaoThongKe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaBC,MaNV,TenNV,Thang")] BaoCaoThongKe baoCaoThongKe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baoCaoThongKe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "MaNV", baoCaoThongKe.MaNV);
            return View(baoCaoThongKe);
        }

        // GET: Administrator/BaoCaoThongKe/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaoCaoThongKe baoCaoThongKe = db.BaoCaoThongKes.Find(id);
            if (baoCaoThongKe == null)
            {
                return HttpNotFound();
            }
            return View(baoCaoThongKe);
        }

        // POST: Administrator/BaoCaoThongKe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BaoCaoThongKe baoCaoThongKe = db.BaoCaoThongKes.Find(id);
            db.BaoCaoThongKes.Remove(baoCaoThongKe);
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
