using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA_Web.ViewModel
{
    public class KhachHang
    {
        public int? ID_KHACHHANG { get; set; }
        public string HoTen { get; set; }
        public string SDT { get; set; }
        public string DIACHI { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
        public string Skype { get; set; }
        public string Whatapp { get; set; }
        public string Telegram { get; set; }
        public int? ID_GIOITHIEU { get; set; }
        public DateTime NgayGioiThieu { get; set; }
    }
}