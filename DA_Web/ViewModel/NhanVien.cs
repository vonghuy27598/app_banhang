using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DA_Web.ViewModel
{
    public class NhanVien
    {

        public int? ID_NHANVIEN { get; set; }
        [DisplayName("Họ và tên")]
        [Required(ErrorMessage = "Họ tên nhân viên không được rỗng")]
        public string HoTen { get; set; }
        [Required(ErrorMessage = "Tài khoản không được rỗng")]
        [DisplayName("Tài khoản")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được rỗng")]
        [DisplayName("Mật khảu")]
        public string Password { get; set; }
        [DisplayName("Giới tính")]
        public bool? GioiTinh { get; set; }
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Số điện thoại không hợp lệ")]
        [Required(ErrorMessage = "Số điện thoại không được rỗng")]
        [DisplayName("Số điện thoại")]
        public string SDT { get; set; }
        [Required(ErrorMessage = "Tài khoản ngân hàng không được rỗng")]
        [DisplayName("Tài khoản ngân hàng")]
        public string TKBank { get; set; }
        [DisplayName("Địa chỉ")]
        public string Diachi { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }
        public string Skype { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn chức vụ")]
        [DisplayName("Chức vụ")]
        public int? ID_LOAINHANVIEN { get; set; }
        public int? ID_SANPHAM { get; set; }
        public double? ChietKhau { get; set; }
        public double? ChietKhauNgay { get; set; }
        public double? ChietKhauThang { get; set; }
        [DisplayName("Chọn hình ảnh")]
        public string ANHDAIDIEN { get; set; }
        public string Tenloainhanvien { get; set; }
        public string TenKH { get; set; }
        public string LyDo { get; set; }
        public string TenSanPham { get; set; }
        public string TuyChon { get; set; }
        public int? SoLuong { get; set; }
        public double DonGia { get; set; }
        public double TongTien { get; set; }
        public int? TongDH { get; set; }
        public double? TongDoanhThu { get; set; }
        public int? TongSoDon { get; set; }
        public int? ID_DONHANG { get; set; }
        public DateTime NgayDatHang { get; set; }
        public DateTime NgayGiaoHang { get; set; }
        public System.Guid ActivityCode { get; set; }
    }
}