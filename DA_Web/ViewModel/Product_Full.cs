using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DA_Web.ViewModel
{
    public class Product_Full
    {
        public int? ID_HINHANH { get; set; }
        [DisplayName("Mã sản sản phẩm")]
        public int? ID_SANPHAM { get; set; }
        [DisplayName("Tên sản phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm không được rỗng")]
        public string TenSanPham { get; set; }
        [DisplayName("Chi tiết")]
        [Required(ErrorMessage = "Chi tiết không được rỗng")]
        public string ChiTiet { get; set; }

        [DisplayName("Màu sắc")]
        [Required(ErrorMessage = "Màu sắc không được rỗng")]
        public string MauSac { get; set; }


        [DisplayName("Size")]
        [Required(ErrorMessage = "Size không được rỗng")]
        public string Size { get; set; }

        [DisplayName("Chất liệu")]
        [Required(ErrorMessage = "Chất liệu không được rỗng")]
        public string CHATLIEU { get; set; }



        [DisplayName("Đơn giá")]
        [Required(ErrorMessage = "Đơn giá không được rỗng")]
        public double? DonGia { get; set; }
        [DisplayName("Chiết khấu")]
        [Required(ErrorMessage = "Chiết khấu không được rỗng")]
        public double? ChietKhau { get; set; }
        [DisplayName("Hoạt động")]
        public bool? Ngung { get; set; }
        [DisplayName("Số lượng")]

        public int? SoLuong { get; set; }
        [DisplayName("Hình ảnh")]
       
        public string HINHANH { get; set; }
        [DisplayName("Nhà sản xuất")]
        public int? ID_NSX { get; set; }
        public string NhaSX { get; set; }
        public string NoiSX { get; set; }

        public int? Viewer { get; set; }

        [DisplayName("Danh mục")]
        public int? ID_LOAISANPHAM { get; set; }
        public int? Root { get; set; }
        public bool? UuTien { get; set; }
        public int? soluongdangco { get; set; }
        public string TENLOAISANPHAM { get; set; }  
        public int? ID_TUYCHON{get;set;}
        public string TuyChon {get;set;}
        public int? soluongtheosize {get;set;}
    }
}