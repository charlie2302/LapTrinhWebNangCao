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
    public class PhieuXuatController : Controller
    {
        private WebQuanLyBanHangDbContext db = new WebQuanLyBanHangDbContext();

        // GET: Administrator/PhieuXuat
        public ActionResult Index()
        {
            var phieuXuats = db.PhieuXuats.Include(p => p.SanPham).Include(p => p.ThongKeNhapXuat);
            return View(phieuXuats.ToList());
        }

        // GET: Administrator/PhieuXuat/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuXuat phieuXuat = db.PhieuXuats.Find(id);
            if (phieuXuat == null)
            {
                return HttpNotFound();
            }
            return View(phieuXuat);
        }

        // GET: Administrator/PhieuXuat/Create
        public ActionResult Create()
        {
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP");
            ViewBag.MaNX = new SelectList(db.ThongKeNhapXuats, "MaNX", "MaBC");
            return View();
        }

        // POST: Administrator/PhieuXuat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCTPXuat,MaNX,Thang,MaSP,TenSP,SLXuat,GiaXuat")] PhieuXuat phieuXuat)
        {
            if (ModelState.IsValid)
            {
                db.PhieuXuats.Add(phieuXuat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP", phieuXuat.MaSP);
            ViewBag.MaNX = new SelectList(db.ThongKeNhapXuats, "MaNX", "MaBC", phieuXuat.MaNX);
            return View(phieuXuat);
        }

        // GET: Administrator/PhieuXuat/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuXuat phieuXuat = db.PhieuXuats.Find(id);
            if (phieuXuat == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP", phieuXuat.MaSP);
            ViewBag.MaNX = new SelectList(db.ThongKeNhapXuats, "MaNX", "MaBC", phieuXuat.MaNX);
            return View(phieuXuat);
        }

        // POST: Administrator/PhieuXuat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCTPXuat,MaNX,Thang,MaSP,TenSP,SLXuat,GiaXuat")] PhieuXuat phieuXuat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuXuat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP", phieuXuat.MaSP);
            ViewBag.MaNX = new SelectList(db.ThongKeNhapXuats, "MaNX", "MaBC", phieuXuat.MaNX);
            return View(phieuXuat);
        }

        // GET: Administrator/PhieuXuat/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuXuat phieuXuat = db.PhieuXuats.Find(id);
            if (phieuXuat == null)
            {
                return HttpNotFound();
            }
            return View(phieuXuat);
        }

        // POST: Administrator/PhieuXuat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PhieuXuat phieuXuat = db.PhieuXuats.Find(id);
            db.PhieuXuats.Remove(phieuXuat);
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
