using DA_Web.ViewModel;
using DA_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace DA_Web.Areas.Admin.Models
{
    public class SanPhamDAO
    {
       
        dbQL_BanHangDataContext db = new dbQL_BanHangDataContext();
     
   
        public Table_LOAISANPHAM listDanhMuc_byID(int id)
        {
            return db.Table_LOAISANPHAMs.First(m => m.ID_LOAISANPHAM == id);
        }

        public List<MenuView> listgetRoot(int id)
        {
            var model = from a in db.Table_LOAISANPHAMs where a.ID_LOAISANPHAM == id
                        select new MenuView()
                        {
                            ID_LOAISANPHAM = a.ID_LOAISANPHAM,
                            TENLOAISANPHAM = a.TenLoaiSanPham,
                            ROOT = a.Root,
                        }
                ;
            return model.OrderBy(m => m.ID_LOAISANPHAM).ToList();
        }

        public List<Product_Full> getSP_byid(int id_sp)
        {
            var model = from a in db.Table_SANPHAMs
                        
                        where a.ID_SANPHAM == id_sp
                        select new Product_Full()
                        {
                            ID_SANPHAM = a.ID_SANPHAM,
                            TenSanPham = a.TenSanPham,
                            SoLuong = a.SoLuong,
                            ChietKhau = a.ChietKhau,
                            ChiTiet = a.ChiTiet,
                            ID_LOAISANPHAM = a.ID_LOAISANPHAM,
                            Ngung = a.Ngung,
                            DonGia = a.DonGia,
                            ID_NSX = a.ID_NSX,
                            HINHANH =a.HINHANH,
                            Size = a.SIZE,
                            CHATLIEU = a.CHATLIEU,
                            MauSac = a.MAUSAC,
                            UuTien = a.UuTien
                        };
            return model.ToList();
        }
    }
}