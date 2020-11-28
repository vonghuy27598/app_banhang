using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DA_Web.ViewModel
{
    public class LoaiSanPham
    {
        public int? ID_LOAISANPHAM { get; set; }
        [DisplayName("Tên danh mục con")]
        [Required(ErrorMessage = "Tên danh mục không được rỗng")]     
        public string TenLoaiSanPham { get; set; }       
        public int? Root { get; set; }
        public int? soluonghienco { get; set; }
        public string TenThuMuc { get; set; }
    }
}