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
    public class ThongKeNhapXuatController : Controller
    {
        private WebQuanLyBanHangDbContext db = new WebQuanLyBanHangDbContext();

        // GET: Administrator/ThongKeNhapXuat
        public ActionResult Index()
        {
            var thongKeNhapXuats = db.ThongKeNhapXuats.Include(t => t.BaoCaoThongKe);
            return View(thongKeNhapXuats.ToList());
        }

        // GET: Administrator/ThongKeNhapXuat/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongKeNhapXuat thongKeNhapXuat = db.ThongKeNhapXuats.Find(id);
            if (thongKeNhapXuat == null)
            {
                return HttpNotFound();
            }
            return View(thongKeNhapXuat);
        }

        // GET: Administrator/ThongKeNhapXuat/Create
        public ActionResult Create()
        {
            ViewBag.MaBC = new SelectList(db.BaoCaoThongKes, "MaBC", "MaBC");
            return View();
        }

        // POST: Administrator/ThongKeNhapXuat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNX,MaBC,Thang,SoTienChi,SoTienThu,SoTienLai")] ThongKeNhapXuat thongKeNhapXuat)
        {
            if (ModelState.IsValid)
            {
                db.ThongKeNhapXuats.Add(thongKeNhapXuat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaBC = new SelectList(db.BaoCaoThongKes, "MaBC", "MaBC", thongKeNhapXuat.MaBC);
            return View(thongKeNhapXuat);
        }

        // GET: Administrator/ThongKeNhapXuat/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongKeNhapXuat thongKeNhapXuat = db.ThongKeNhapXuats.Find(id);
            if (thongKeNhapXuat == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaBC = new SelectList(db.BaoCaoThongKes, "MaBC", "MaBC", thongKeNhapXuat.MaBC);
            return View(thongKeNhapXuat);
        }

        // POST: Administrator/ThongKeNhapXuat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNX,MaBC,Thang,SoTienChi,SoTienThu,SoTienLai")] ThongKeNhapXuat thongKeNhapXuat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thongKeNhapXuat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaBC = new SelectList(db.BaoCaoThongKes, "MaBC", "MaBC", thongKeNhapXuat.MaBC);
            return View(thongKeNhapXuat);
        }

        // GET: Administrator/ThongKeNhapXuat/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongKeNhapXuat thongKeNhapXuat = db.ThongKeNhapXuats.Find(id);
            if (thongKeNhapXuat == null)
            {
                return HttpNotFound();
            }
            return View(thongKeNhapXuat);
        }

        // POST: Administrator/ThongKeNhapXuat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ThongKeNhapXuat thongKeNhapXuat = db.ThongKeNhapXuats.Find(id);
            db.ThongKeNhapXuats.Remove(thongKeNhapXuat);
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
