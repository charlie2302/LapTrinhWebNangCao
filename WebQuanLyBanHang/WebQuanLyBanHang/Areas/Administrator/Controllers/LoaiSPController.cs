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
    public class LoaiSPController : Controller
    {
        private WebQuanLyBanHangDbContext db = new WebQuanLyBanHangDbContext();

        // GET: Administrator/LoaiSP
        public ActionResult Index()
        {
            return View(db.LoaiSPs.ToList());
        }

        // GET: Administrator/LoaiSP/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSP loaiSP = db.LoaiSPs.Find(id);
            if (loaiSP == null)
            {
                return HttpNotFound();
            }
            return View(loaiSP);
        }

        // GET: Administrator/LoaiSP/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/LoaiSP/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoaiSP,TenLoaiSP")] LoaiSP loaiSP)
        {
            if (ModelState.IsValid)
            {
                db.LoaiSPs.Add(loaiSP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiSP);
        }

        // GET: Administrator/LoaiSP/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSP loaiSP = db.LoaiSPs.Find(id);
            if (loaiSP == null)
            {
                return HttpNotFound();
            }
            return View(loaiSP);
        }

        // POST: Administrator/LoaiSP/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoaiSP,TenLoaiSP")] LoaiSP loaiSP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiSP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiSP);
        }

        // GET: Administrator/LoaiSP/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSP loaiSP = db.LoaiSPs.Find(id);
            if (loaiSP == null)
            {
                return HttpNotFound();
            }
            return View(loaiSP);
        }

        // POST: Administrator/LoaiSP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LoaiSP loaiSP = db.LoaiSPs.Find(id);
            db.LoaiSPs.Remove(loaiSP);
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
