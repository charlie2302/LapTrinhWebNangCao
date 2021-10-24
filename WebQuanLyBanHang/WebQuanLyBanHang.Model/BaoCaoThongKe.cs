namespace WebQuanLyBanHang.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaoCaoThongKe")]
    public partial class BaoCaoThongKe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaoCaoThongKe()
        {
            ThongKeNhapXuats = new HashSet<ThongKeNhapXuat>();
        }

        [Key]
        [StringLength(50)]
        public string MaBC { get; set; }

        [StringLength(50)]
        public string MaNV { get; set; }

        [StringLength(50)]
        public string TenNV { get; set; }

        public int? Thang { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongKeNhapXuat> ThongKeNhapXuats { get; set; }
    }
}
