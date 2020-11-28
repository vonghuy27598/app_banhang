namespace DA_Web.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table_DONHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Table_DONHANG()
        {
            Table_BANSANPHAM = new HashSet<Table_BANSANPHAM>();
            Table_DONHANG_DM = new HashSet<Table_DONHANG_DM>();
        }

        [Key]
        public int ID_DONHANG { get; set; }

        public int? ID_NGUOIBAN { get; set; }

        public int? ID_NGUOIGIAO { get; set; }

        public int? ID_NGUOICHOT { get; set; }

        public int? ID_KHACHHANG { get; set; }

        public double? TONGTIEN { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayGiaoDich { get; set; }

        public bool? Damua { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayGiaoHang { get; set; }

        [StringLength(500)]
        public string GhiChu { get; set; }

        public bool? TinhTrang { get; set; }

        [StringLength(500)]
        public string PhanHoi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Table_BANSANPHAM> Table_BANSANPHAM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Table_DONHANG_DM> Table_DONHANG_DM { get; set; }

        public virtual Table_KHACHHANG Table_KHACHHANG { get; set; }

        public virtual Table_NHANVIEN Table_NHANVIEN { get; set; }
    }
}
