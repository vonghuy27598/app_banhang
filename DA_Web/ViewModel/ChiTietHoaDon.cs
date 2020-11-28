using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA_Web.ViewModel
{
    public class ChiTietHoaDon
    {
        public int? ID_DONHANG_DM { get; set; }
        public int? ID_DONHANG { get; set; }
        public int? ID_SANPHAM { get; set; }
        public string TenSanPham { get; set; }
        public int? SoLuong { get; set; }
        public double? Giatien { get; set; }
        public bool? TinhTrang { get; set; }
        public string TuyChon { get; set; }
        public string HinhAnh { get; set; }
      

    }
}