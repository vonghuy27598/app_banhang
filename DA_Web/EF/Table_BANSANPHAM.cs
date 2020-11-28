namespace DA_Web.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table_BANSANPHAM
    {
        [Key]
        public int ID_BANSANPHAM { get; set; }

        public int ID_DONHANG { get; set; }

        public double? ThanhToanTienCK { get; set; }

        public double? TinhTrangThanhToan { get; set; }

        public virtual Table_DONHANG Table_DONHANG { get; set; }
    }
}
