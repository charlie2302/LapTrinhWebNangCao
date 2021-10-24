using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuanLyBanHang.Model;
using WebQuanLyBanHang.Models;
namespace WebQuanLyBanHang.Controllers
{
    public class CartController : Controller
    {
        WebQuanLyBanHangDbContext db = new WebQuanLyBanHangDbContext();

        public List<CartItem> GetCart()
        {
            List<CartItem> LstCart = Session["Cart"] as List<CartItem>;// khởi tạo giỏ hàng và session để lư sản phẩm
            if (LstCart == null)// nếu chwua có thì tạo mới
            {
                LstCart = new List<CartItem>();
                Session["Cart"] = LstCart;
                return LstCart;
            }
            return LstCart;
        }
        public ActionResult AddToCart(string id, string url)
        {
            //Kiểm tra sản phẩm
            var sp = db.SanPhams.SingleOrDefault(n=>n.MaSP==id);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy giỏ hàng
            List<CartItem> LstCart = GetCart();
            //Nếu sản phẩm đã tồn tại
            CartItem CartCheck = LstCart.SingleOrDefault(n => n.masp == id );
            if (CartCheck != null)//sản phẩm chưa có trong giỏ hàng
            {
                if (sp.SoLuong < CartCheck.soluong) // nếu số tồn trong kho nhỏ hơn số mua 
                {
                    return null;
                }
                CartCheck.soluong++;// tăng ẳn phẩm
                CartCheck.thanhtien = CartCheck.soluong * CartCheck.dongia;// tính tiền
                return Redirect(url);
            }

            CartItem itemcart = new CartItem(id);
            if (sp.SoLuong < itemcart.soluong) return null;
            LstCart.Add(itemcart);
            return Redirect(url);
        }
        [HttpGet]
        public ActionResult UpdateCart(string id, string cfid)
        {
            if (Session["Cart"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var sp = db.SanPhams.SingleOrDefault(n => n.MaSP == id);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<CartItem> LstCart = GetCart();
            CartItem CartCheck = LstCart.SingleOrDefault(n => n.masp == id );
            if (CartCheck == null) return RedirectToAction("Index", "Home");
            ViewBag.Cart = LstCart;
            return View(CartCheck);
        }
        public string lastid()
        {
            int a = 0;
            List<int> lstid = new List<int>();
            IEnumerable<string> id = from temp in db.HoaDons select temp.MaHD;
            foreach (var temp in id)
            {
                a = int.Parse(temp);
                lstid.Add(int.Parse(temp));
            }
            lstid.Sort();
            int max = lstid.Last();
            max++;
            return max.ToString();
        }
        public string lastctid()
        {
            int a = 0;
            List<int> lstid = new List<int>();
            IEnumerable<string> id = from temp in db.CTHoaDons select temp.MaCTHD;
            foreach (var temp in id)
            {
                a = int.Parse(temp);
                lstid.Add(int.Parse(temp));
            }
            lstid.Sort();
            int max = lstid.Last();
            max++;
            return max.ToString();
        }
        public string lastkhid()
        {
            int a = 0;
            List<int> lstid = new List<int>();
            IEnumerable<string> id = from temp in db.KhachHangs select temp.MaKH;
            foreach (var temp in id)
            {
                a = int.Parse(temp);
                lstid.Add(int.Parse(temp));
            }
            lstid.Sort();
            int max = lstid.Last();
            max++;
            return max.ToString();
        }
        [HttpPost]
        public ActionResult UpdateCart(CartItem cartItem)
        {
            var sp = db.SanPhams.SingleOrDefault(n => n.MaSP == cartItem.masp);
            if (sp.SoLuong < cartItem.soluong)
            {
                return null;
            }
            List<CartItem> LstCart = GetCart();
            CartItem ItemUpdate = LstCart.Find(n => n.masp == cartItem.masp);
            ItemUpdate.soluong = cartItem.soluong;
            if (ItemUpdate.soluong == 0) DeleteCart(ItemUpdate.masp);
            ItemUpdate.thanhtien = ItemUpdate.soluong * ItemUpdate.dongia;
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCart(string id)
        {
            if (Session["Cart"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var sp = db.SanPhams.SingleOrDefault(n => n.MaSP == id);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<CartItem> LstCart = GetCart();
            CartItem CartCheck = LstCart.SingleOrDefault(n => n.masp == id);
            if (CartCheck == null) return RedirectToAction("Index", "Home");
            LstCart.Remove(CartCheck);
            return RedirectToAction("Index");
        }
        public decimal TotalMoney()
        {
            List<CartItem> LstCart = Session["Cart"] as List<CartItem>;
            if (LstCart == null)
            {
                return 0;
            }
            decimal tt = LstCart.Sum(n=>n.thanhtien);
            return tt;
        }
        public ActionResult Order(HoaDon order, KhachHang customer)
        {

            if (Session["Cart"] == null)
                return RedirectToAction("Index", "Home");
            KhachHang Customer = new KhachHang();
            Customer = customer;
            Customer.MaKH = lastkhid();
            db.KhachHangs.Add(Customer);
            db.SaveChanges();
            order.MaKH = Customer.MaKH;
            order.MaHD = lastid();
            order.NgayMuaHang = DateTime.Now;
            order.TongHoaDon = TotalMoney();
            db.HoaDons.Add(order);
            db.SaveChanges();
            List<CartItem> LstCart = GetCart();

            foreach (var item in LstCart)
            {
                CTHoaDon dtorder = new CTHoaDon();
                dtorder.MaCTHD = lastctid();
                dtorder.MaHD = order.MaHD;
                dtorder.MaSP = item.masp;
                dtorder.SoLuong = item.soluong;
                dtorder.Gia = item.dongia;
                dtorder.ThanhTien = item.thanhtien;
                dtorder.Voucher = 0;
                dtorder.PhiVanChuyen = 0;
                db.CTHoaDons.Add(dtorder);
                db.SaveChanges();
            }
            
            Session["Cart"] = null;
            return RedirectToAction("Index");
        }
        // GET: Cart
        public ActionResult Index()
        {
            
            List<CartItem> cart = GetCart();
            ViewBag.Total = TotalMoney();
            return View(cart);
        }
    }
}