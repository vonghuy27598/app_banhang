using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA_Web.ViewModel
{
    public class HoaDon
    {
        public int? ID_DONHANG { get; set; }      
        public double? TONGTIEN { get; set; }        
        public bool? Damua { get; set; }
        public double? TongTien { get; set; }
        public DateTime NgayGiaoDich { get; set; }
        

        public int? ID_KHACHHANG { get; set; }
        public string HOTEN { get; set; }
        public string SDT { get; set; }

        public int? ID_NGUOIBAN { get; set; }
        public string TEN_NGUOIBAN { get; set; }
        public string TKBank { get; set; }

        public int? ID_NGUOIGIAO { get; set; }
        public string TEN_NGUOIGIAO { get; set; }
        public string TKBank_NguoiGiao { get; set; }

        public int? TongHD { get; set; }
        public bool TinhTrangDon { get; set; }
    }
}