namespace DA_Web.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table_SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Table_SANPHAM()
        {
            Table_DONHANG_DM = new HashSet<Table_DONHANG_DM>();
            Table_MUCHINHANH = new HashSet<Table_MUCHINHANH>();
            Table_NHAPKHO = new HashSet<Table_NHAPKHO>();
            Table_TUYCHON = new HashSet<Table_TUYCHON>();
        }

        [Key]
        public int ID_SANPHAM { get; set; }

        public int ID_LOAISANPHAM { get; set; }

        [Required]
        [StringLength(500)]
        public string TenSanPham { get; set; }

        [StringLength(500)]
        public string ChiTiet { get; set; }

        [StringLength(100)]
        public string MAUSAC { get; set; }

        [StringLength(100)]
        public string SIZE { get; set; }

        [StringLength(100)]
        public string CHATLIEU { get; set; }

        public double DonGia { get; set; }

        public double? ChietKhau { get; set; }

        public int? ID_NSX { get; set; }

        public bool? Ngung { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(50)]
        public string HINHANH { get; set; }

        public int? VIEWER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Table_DONHANG_DM> Table_DONHANG_DM { get; set; }

        public virtual Table_LOAISANPHAM Table_LOAISANPHAM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Table_MUCHINHANH> Table_MUCHINHANH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Table_NHAPKHO> Table_NHAPKHO { get; set; }

        public virtual Table_NhaSX Table_NhaSX { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Table_TUYCHON> Table_TUYCHON { get; set; }
    }
}
