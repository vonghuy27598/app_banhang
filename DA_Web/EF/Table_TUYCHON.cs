namespace DA_Web.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table_TUYCHON
    {
        [Key]
        public int ID_TUYCHON { get; set; }

        public int ID_SANPHAM { get; set; }

        [StringLength(50)]
        public string TuyChon { get; set; }

        public double? DonGia { get; set; }

        public int? SoLuong { get; set; }

        public virtual Table_SANPHAM Table_SANPHAM { get; set; }
    }
}
