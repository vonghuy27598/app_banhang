using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DA_Web.ViewModel
{
    public class LoaiNV
    {

        public int? ID_LOAINHANVIEN { get; set; }
        [DisplayName("Tên chức vụ")]
        [Required(ErrorMessage = "Tên chức vụ không được rỗng")]
      
        public string Tenloainhanvien{get;set;}
        public int soluongNV { get; set; }
    }
}