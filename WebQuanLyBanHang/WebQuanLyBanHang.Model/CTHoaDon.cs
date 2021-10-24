namespace WebQuanLyBanHang.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTHoaDon")]
    public partial class CTHoaDon
    {
        [Key]
        [StringLength(50)]
        public string MaCTHD { get; set; }

        [StringLength(50)]
        public string MaHD { get; set; }

        [StringLength(50)]
        public string MaSP { get; set; }

        public decimal? Gia { get; set; }

        public int? SoLuong { get; set; }

        public decimal? ThanhTien { get; set; }

        public double? Voucher { get; set; }

        public decimal? PhiVanChuyen { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
