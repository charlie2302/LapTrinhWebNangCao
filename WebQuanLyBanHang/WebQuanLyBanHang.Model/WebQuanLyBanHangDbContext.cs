using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebQuanLyBanHang.Model
{
    public partial class WebQuanLyBanHangDbContext : DbContext
    {
        public WebQuanLyBanHangDbContext()
            : base("name=WebQuanLyBanHangDbContext")
        {
        }

        public virtual DbSet<BaoCaoThongKe> BaoCaoThongKes { get; set; }
        public virtual DbSet<CTHoaDon> CTHoaDons { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiSP> LoaiSPs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public virtual DbSet<PhieuXuat> PhieuXuats { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<ThongKeNhapXuat> ThongKeNhapXuats { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SanPham>()
                .Property(e => e.HinhAnh)
                .IsUnicode(false);
        }
    }
}
