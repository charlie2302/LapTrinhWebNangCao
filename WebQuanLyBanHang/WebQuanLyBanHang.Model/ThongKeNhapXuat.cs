namespace WebQuanLyBanHang.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongKeNhapXuat")]
    public partial class ThongKeNhapXuat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThongKeNhapXuat()
        {
            PhieuNhaps = new HashSet<PhieuNhap>();
            PhieuXuats = new HashSet<PhieuXuat>();
        }

        [Key]
        [StringLength(50)]
        public string MaNX { get; set; }

        [StringLength(50)]
        public string MaBC { get; set; }

        public int? Thang { get; set; }

        public double? SoTienChi { get; set; }

        public double? SoTienThu { get; set; }

        public double? SoTienLai { get; set; }

        public virtual BaoCaoThongKe BaoCaoThongKe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuXuat> PhieuXuats { get; set; }
    }
}
