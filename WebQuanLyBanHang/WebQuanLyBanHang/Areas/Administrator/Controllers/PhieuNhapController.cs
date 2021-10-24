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
    public class PhieuNhapController : Controller
    {
        private WebQuanLyBanHangDbContext db = new WebQuanLyBanHangDbContext();

        // GET: Administrator/PhieuNhap
        public ActionResult Index()
        {
            var phieuNhaps = db.PhieuNhaps.Include(p => p.SanPham).Include(p => p.ThongKeNhapXuat);
            return View(phieuNhaps.ToList());
        }

        // GET: Administrator/PhieuNhap/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuNhap phieuNhap = db.PhieuNhaps.Find(id);
            if (phieuNhap == null)
            {
                return HttpNotFound();
            }
            return View(phieuNhap);
        }

        // GET: Administrator/PhieuNhap/Create
        public ActionResult Create()
        {
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP");
            ViewBag.MaNX = new SelectList(db.ThongKeNhapXuats, "MaNX", "MaNX");
            return View();
        }

        // POST: Administrator/PhieuNhap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCTPNhap,MaNX,Thang,MaSP,TenSP,SLNhap,GiaNhap")] PhieuNhap phieuNhap)
        {
            if (ModelState.IsValid)
            {
                db.PhieuNhaps.Add(phieuNhap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP", phieuNhap.MaSP);
            ViewBag.MaNX = new SelectList(db.ThongKeNhapXuats, "MaNX", "MaNX", phieuNhap.MaNX);
            return View(phieuNhap);
        }

        // GET: Administrator/PhieuNhap/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuNhap phieuNhap = db.PhieuNhaps.Find(id);
            if (phieuNhap == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP", phieuNhap.MaSP);
            ViewBag.MaNX = new SelectList(db.ThongKeNhapXuats, "MaNX", "MaNX", phieuNhap.MaNX);
            return View(phieuNhap);
        }

        // POST: Administrator/PhieuNhap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCTPNhap,MaNX,Thang,MaSP,TenSP,SLNhap,GiaNhap")] PhieuNhap phieuNhap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuNhap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP", phieuNhap.MaSP);
            ViewBag.MaNX = new SelectList(db.ThongKeNhapXuats, "MaNX", "MaNX", phieuNhap.MaNX);
            return View(phieuNhap);
        }

        // GET: Administrator/PhieuNhap/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuNhap phieuNhap = db.PhieuNhaps.Find(id);
            if (phieuNhap == null)
            {
                return HttpNotFound();
            }
            return View(phieuNhap);
        }

        // POST: Administrator/PhieuNhap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PhieuNhap phieuNhap = db.PhieuNhaps.Find(id);
            db.PhieuNhaps.Remove(phieuNhap);
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
