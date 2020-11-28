namespace DA_Web.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table_NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Table_NHANVIEN()
        {
            Table_DONHANG = new HashSet<Table_DONHANG>();
            Table_NHAPKHO = new HashSet<Table_NHAPKHO>();
        }

        [Key]
        public int ID_NHANVIEN { get; set; }

        [Required]
        [StringLength(500)]
        public string HoTen { get; set; }

        [StringLength(100)]
        public string Username { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        public bool? GioiTinh { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        [StringLength(100)]
        public string TKBank { get; set; }

        [StringLength(500)]
        public string Diachi { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Skype { get; set; }

        [StringLength(100)]
        public string ANHDAIDIEN { get; set; }

        public int? ID_LOAINHANVIEN { get; set; }

        [StringLength(100)]
        public string Code { get; set; }

        [StringLength(100)]
        public string ActiveCode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Table_DONHANG> Table_DONHANG { get; set; }

        public virtual Table_LOAINHANVIEN Table_LOAINHANVIEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Table_NHAPKHO> Table_NHAPKHO { get; set; }
    }
}
