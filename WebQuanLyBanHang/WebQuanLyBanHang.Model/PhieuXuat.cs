namespace WebQuanLyBanHang.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuXuat")]
    public partial class PhieuXuat
    {
        [Key]
        [StringLength(50)]
        public string MaCTPXuat { get; set; }

        [StringLength(50)]
        public string MaNX { get; set; }

        public int? Thang { get; set; }

        [StringLength(50)]
        public string MaSP { get; set; }

        [StringLength(50)]
        public string TenSP { get; set; }

        public int? SLXuat { get; set; }

        public double? GiaXuat { get; set; }

        public virtual SanPham SanPham { get; set; }

        public virtual ThongKeNhapXuat ThongKeNhapXuat { get; set; }
    }
}
