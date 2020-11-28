namespace DA_Web.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table_MUCHINHANH
    {
        [Key]
        public int ID_HINHANH { get; set; }

        public int ID_SANPHAM { get; set; }

        [StringLength(200)]
        public string HINHANH_N { get; set; }

        public virtual Table_SANPHAM Table_SANPHAM { get; set; }
    }
}
