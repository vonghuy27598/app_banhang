namespace DA_Web.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table_NHAPKHO
    {
        [Key]
        public int ID_NHAPKHO { get; set; }

        public int ID_SANPHAM { get; set; }

        public int ID_NHANVIEN { get; set; }

        public int? SoLuong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayNhap { get; set; }

        public virtual Table_NHANVIEN Table_NHANVIEN { get; set; }

        public virtual Table_SANPHAM Table_SANPHAM { get; set; }
    }
}
