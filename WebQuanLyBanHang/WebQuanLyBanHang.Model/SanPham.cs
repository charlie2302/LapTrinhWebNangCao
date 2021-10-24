namespace WebQuanLyBanHang.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            CTHoaDons = new HashSet<CTHoaDon>();
            PhieuNhaps = new HashSet<PhieuNhap>();
            PhieuXuats = new HashSet<PhieuXuat>();
        }

        [Key]
        [StringLength(50)]
        public string MaSP { get; set; }

        [StringLength(50)]
        public string TenSP { get; set; }

        [StringLength(50)]
        public string MaLoaiSP { get; set; }

        public int? SoLuong { get; set; }

        public decimal? Gia { get; set; }

        public string HinhAnh { get; set; }

        public string MoTa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHoaDon> CTHoaDons { get; set; }

        public virtual LoaiSP LoaiSP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuXuat> PhieuXuats { get; set; }
    }
}
