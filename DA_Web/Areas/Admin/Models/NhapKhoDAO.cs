using DA_Web.Models;
using DA_Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA_Web.Areas.Admin.Models
{
    public class NhapKhoDAO
    {
        public static dbQL_BanHangDataContext db = new dbQL_BanHangDataContext();

        public static List<NhapKho> getLichSuNhap()
        {
            var model = from a in db.Table_NHAPKHOs
                        join b in db.Table_SANPHAMs on a.ID_SANPHAM equals b.ID_SANPHAM
                        select new NhapKho()
                        {
                            ID_NHANVIEN = a.ID_NHANVIEN,
                            ID_NHAPKHO = a.ID_NHAPKHO,
                            ID_SANPHAM=a.ID_SANPHAM,
                            NgayNhap =(DateTime) a.NgayNhap,
                            SoLuong =(int) a.SoLuong,
                            TENSANPHAM = b.TenSanPham
                            
                        };
            return model.OrderByDescending(m => m.NgayNhap).ToList();
                       
        }
    }
}