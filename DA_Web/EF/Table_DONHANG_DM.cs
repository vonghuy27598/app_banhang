namespace DA_Web.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table_DONHANG_DM
    {
        [Key]
        public int ID_DONHANG_DM { get; set; }

        public int ID_DONHANG { get; set; }

        public int ID_SANPHAM { get; set; }

        [Required]
        [StringLength(50)]
        public string TuyChon { get; set; }

        public int? SoLuong { get; set; }

        public double? Giatien { get; set; }

        public bool? TinhTrang { get; set; }

        [Column(TypeName = "ntext")]
        public string GHICHU { get; set; }

        public virtual Table_DONHANG Table_DONHANG { get; set; }

        public virtual Table_SANPHAM Table_SANPHAM { get; set; }
    }
}
