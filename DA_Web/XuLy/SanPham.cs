using DA_Web.Models;
using DA_Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA_Web.XuLy
{
    public class SanPham
    {

        public static List<Product_Full> Product_Full()
        {
            dbQL_BanHangDataContext data = new dbQL_BanHangDataContext();     
            var model =( from a in data.Table_SANPHAMs
                        join b in data.Table_LOAISANPHAMs on a.ID_LOAISANPHAM equals b.ID_LOAISANPHAM
                        join c in data.Table_NhaSXes on a.ID_NSX equals c.ID_NSX
                         select new Product_Full()
                        {
                            HINHANH = a.HINHANH,
                            DonGia = a.DonGia,
                            ID_LOAISANPHAM = b.ID_LOAISANPHAM,
                            ID_NSX = a.ID_NSX,
                            ID_SANPHAM = a.ID_SANPHAM,
                            ChiTiet = a.ChiTiet,
                            SoLuong = a.SoLuong,
                            TenSanPham = a.TenSanPham,
                            TENLOAISANPHAM = b.TenLoaiSanPham,
                            NhaSX = c.NhaSX,
                            NoiSX = c.NoiSX,
                            soluongdangco = (data.Table_SANPHAMs.Where(m=>m.ID_LOAISANPHAM == b.ID_LOAISANPHAM).Count()),
                            Ngung = a.Ngung,
                            UuTien = a.UuTien

                        }).Distinct();
            return model.OrderBy(m=>m.ID_SANPHAM).ToList();
        }

        public static List<Product_Full> Product_Full_byID(int id)
        {
            dbQL_BanHangDataContext data = new dbQL_BanHangDataContext();
            var model = from a in data.Table_SANPHAMs
                        join b in data.Table_LOAISANPHAMs on a.ID_LOAISANPHAM equals b.ID_LOAISANPHAM 
                        join c in data.Table_NhaSXes on a.ID_NSX equals c.ID_NSX
                        where a.ID_SANPHAM == id
                        select new Product_Full()
                        {
                            HINHANH = a.HINHANH,
                            DonGia = a.DonGia,
                            ID_LOAISANPHAM = b.ID_LOAISANPHAM,
                            ID_NSX = a.ID_NSX,
                            ID_SANPHAM = a.ID_SANPHAM,
                            ChiTiet = a.ChiTiet,
                            Size = a.SIZE,
                            MauSac = a.MAUSAC,
                            CHATLIEU = a.CHATLIEU,
                            SoLuong = a.SoLuong,
                            TenSanPham = a.TenSanPham,
                            TENLOAISANPHAM = b.TenLoaiSanPham,
                            NhaSX = c.NhaSX,
                            Ngung = a.Ngung,
                            Viewer = a.VIEWER,                           
                            ChietKhau = a.ChietKhau,
                            UuTien = a.UuTien
                            
                        };
            return model.OrderByDescending(m => m.ID_SANPHAM).ToList();
        }
        public static List<Product_Full> Product_Full_byNAMEGROUP_child(string TENLOAI)
        {
            dbQL_BanHangDataContext data = new dbQL_BanHangDataContext();
            var model = from a in data.Table_SANPHAMs
                        join b in data.Table_LOAISANPHAMs on a.ID_LOAISANPHAM equals b.ID_LOAISANPHAM
                        where b.TenLoaiSanPham == TENLOAI && a.Ngung == false
                        select new Product_Full()
                        {
                            HINHANH = a.HINHANH,
                            DonGia = a.DonGia,
                            ID_LOAISANPHAM = a.ID_LOAISANPHAM,
                            ID_NSX = a.ID_NSX,
                            ID_SANPHAM = a.ID_SANPHAM,
                            ChiTiet = a.ChiTiet,
                            SoLuong = a.SoLuong,
                            TenSanPham = a.TenSanPham,
                            TENLOAISANPHAM = b.TenLoaiSanPham,
                        };
            return model.OrderBy(m => m.ID_SANPHAM).ToList();
        }

        public static List<Product_Full> Product_Full_byNAMEGROUP_parent(int id_loaisanpham_parent)
        {
            dbQL_BanHangDataContext data = new dbQL_BanHangDataContext();
            var model = from a in data.Table_SANPHAMs
                        join b in data.Table_LOAISANPHAMs on a.ID_LOAISANPHAM equals b.ID_LOAISANPHAM
                        where  b.Root== id_loaisanpham_parent && a.Ngung == false
                        select new Product_Full()
                        {
                            HINHANH = a.HINHANH,
                            DonGia = a.DonGia,
                            ID_LOAISANPHAM = a.ID_LOAISANPHAM,
                            ID_NSX = a.ID_NSX,
                            ID_SANPHAM = a.ID_SANPHAM,
                            ChiTiet = a.ChiTiet,
                            SoLuong = a.SoLuong,
                            TenSanPham = a.TenSanPham,
                            TENLOAISANPHAM = b.TenLoaiSanPham,
                        };
            return model.OrderBy(m => m.ID_SANPHAM).ToList();
        }

        public List<string> ListName(string keyword)
        {
            dbQL_BanHangDataContext data = new dbQL_BanHangDataContext();
            return data.Table_SANPHAMs.Where(x => x.TenSanPham.Contains(keyword) && x.Ngung == false).Select(x => x.TenSanPham).ToList();
        }

        public static List<Product_Full> Search(string keyword)
        {
            dbQL_BanHangDataContext data = new dbQL_BanHangDataContext();
            var model = (from a in data.Table_SANPHAMs
                         join b in data.Table_LOAISANPHAMs on a.ID_LOAISANPHAM equals b.ID_LOAISANPHAM
                         where a.TenSanPham.Contains(keyword) && a.Ngung== false
                         select new Product_Full()
                         {
                             HINHANH = a.HINHANH,
                             DonGia = a.DonGia,
                             ID_LOAISANPHAM = a.ID_LOAISANPHAM,
                             ID_NSX = a.ID_NSX,
                             ID_SANPHAM = a.ID_SANPHAM,
                             ChiTiet = a.ChiTiet,
                             SoLuong = a.SoLuong,
                             TenSanPham = a.TenSanPham,
                             TENLOAISANPHAM = b.TenLoaiSanPham,
                         }).Distinct();
            return model.OrderBy(m => m.TenSanPham).ToList();
        }

        
        public static bool getParent(string ten_loai)
        {
            dbQL_BanHangDataContext data = new dbQL_BanHangDataContext();
            int model = (int)(from a in data.Table_LOAISANPHAMs where a.TenLoaiSanPham == ten_loai select a.Root).SingleOrDefault();
            if (model ==0)
                return true;
            else
                return false;
             
        }

        public static List<Product_Full> getSanPhamBanChay()
        {
            dbQL_BanHangDataContext data = new dbQL_BanHangDataContext();
            var model = from a in data.Table_SANPHAMs
                        join b in data.Table_DONHANG_DMs on a.ID_SANPHAM equals b.ID_SANPHAM
                        select new Product_Full()
                        {
                            ID_SANPHAM = a.ID_SANPHAM,
                            TenSanPham = a.TenSanPham,
                            DonGia = a.DonGia,
                            HINHANH = a.HINHANH,
                            SoLuong = (data.Table_DONHANG_DMs.Where(m => m.ID_SANPHAM == a.ID_SANPHAM)).Count(),
                            Ngung = a.Ngung
                            
                        };
            return model.GroupBy(m=>m.ID_SANPHAM).Select(m=>m.First()).OrderByDescending(m=>m.SoLuong).Take(10).ToList();
        }

        public static List<Product_Full> getSanPhamLienQuan(int ID_LOAISANPHAM, int ID_SANPHAM)
        {
            dbQL_BanHangDataContext data = new dbQL_BanHangDataContext();
            var model = from a in data.Table_SANPHAMs
                        join b in data.Table_LOAISANPHAMs on a.ID_LOAISANPHAM equals b.ID_LOAISANPHAM
                        where a.ID_LOAISANPHAM == ID_LOAISANPHAM && a.ID_SANPHAM != ID_SANPHAM && a.Ngung == false
                        select new Product_Full()
                        {
                            ID_SANPHAM = a.ID_SANPHAM,
                            TenSanPham = a.TenSanPham,
                            DonGia = a.DonGia,
                            HINHANH = a.HINHANH,
                            Ngung = a.Ngung
                        };
            return model.ToList();
        }

        public static List<KhachHang> getInfoKH_byPhone(string SDT,int ID_GIOITHIEU)
        {
            dbQL_BanHangDataContext data = new dbQL_BanHangDataContext();
            var model = from a in data.Table_KHACHHANGs                       
                        where a.SDT == SDT && a.ID_GIOITHIEU == ID_GIOITHIEU
                        select new KhachHang()
                        {
                            HoTen = a.HoTen,
                            SDT = a.SDT,
                            DIACHI = a.DiaChi
                        };
            return model.ToList();
        }
    }
}