using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA_Web.ViewModel
{
    public class HoaDonGiaoHang
    {
        public int? ID_DONHANG { get; set; }
        public string TENKH { get; set; }
        public string SDT { get; set; }
        public double? TongTien { get; set; }
        public string DIACHI { get; set; }
        public bool? Dagiao { get; set; }
    }
}