namespace WebQuanLyBanHang.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            CTHoaDons = new HashSet<CTHoaDon>();
        }

        [Key]
        [StringLength(50)]
        public string MaHD { get; set; }

        [StringLength(50)]
        public string MaNV { get; set; }

        [StringLength(50)]
        public string MaKH { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayMuaHang { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayGiaoHang { get; set; }

        public decimal? TongHoaDon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHoaDon> CTHoaDons { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
