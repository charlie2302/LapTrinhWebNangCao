using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebQuanLyBanHang.Model;
namespace WebQuanLyBanHang.Models
{
    public class CartItem
    {
        public string masp { get; set; }
        public string tensp { get; set; }
        public int soluong { get; set; }
        public string hinhanh { get; set; }
        public decimal dongia { get; set; }
        public decimal thanhtien { get; set; }

        public CartItem(string id)
        {
            WebQuanLyBanHangDbContext db = new WebQuanLyBanHangDbContext();

            masp = id;
            soluong = 1;
            SanPham sp = db.SanPhams.Single(n => n.MaSP == id);
            tensp = sp.TenSP;
            hinhanh = sp.HinhAnh;
            dongia = sp.Gia.Value;
            thanhtien = soluong * dongia;
        }
        public CartItem() { }

    }
}