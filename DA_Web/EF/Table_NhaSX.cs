namespace DA_Web.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table_NhaSX
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Table_NhaSX()
        {
            Table_SANPHAM = new HashSet<Table_SANPHAM>();
        }

        [Key]
        public int ID_NSX { get; set; }

        [Required]
        [StringLength(50)]
        public string NhaSX { get; set; }

        [Required]
        [StringLength(500)]
        public string NoiSX { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Table_SANPHAM> Table_SANPHAM { get; set; }
    }
}
