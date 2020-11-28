using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA_Web.ViewModel
{
    public class NhapKho
    {
        public int? ID_NHAPKHO { get; set; }
        public int? ID_SANPHAM { get; set; }
        public string TENSANPHAM { get; set; }
        public int? ID_NHANVIEN { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgayNhap { get; set; }
    }
}