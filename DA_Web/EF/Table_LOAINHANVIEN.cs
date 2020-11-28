namespace DA_Web.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table_LOAINHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Table_LOAINHANVIEN()
        {
            Table_NHANVIEN = new HashSet<Table_NHANVIEN>();
        }

        [Key]
        public int ID_LOAINHANVIEN { get; set; }

        [Required]
        [StringLength(500)]
        public string Tenloainhanvien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Table_NHANVIEN> Table_NHANVIEN { get; set; }
    }
}
