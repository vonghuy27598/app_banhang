using DA_Web.Models;
using DA_Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA_Web.XuLy
{
    public class DanhMucCon
    {
        public static dbQL_BanHangDataContext db = new dbQL_BanHangDataContext();

        public static List<Product_Full> full_sanpham_byIDLOAISP_child(int Root)
        {
            var model = (from a in db.Table_SANPHAMs
                        join b in db.Table_LOAISANPHAMs on a.ID_LOAISANPHAM equals b.ID_LOAISANPHAM
                        join c in db.Table_NhaSXes on a.ID_NSX equals c.ID_NSX
                         where a.ID_LOAISANPHAM == Root
                        select new Product_Full()
                        {
                            ID_SANPHAM = a.ID_SANPHAM,
                            ID_LOAISANPHAM = b.ID_LOAISANPHAM,
                            ID_NSX = a.ID_NSX,
                            ChietKhau = a.ChietKhau,
                            ChiTiet = a.ChiTiet,
                            DonGia =(double) a.DonGia,
                            HINHANH = a.HINHANH,
                            Ngung = a.Ngung,
                            NhaSX =c.NhaSX,
                            NoiSX =c.NoiSX,
                            TENLOAISANPHAM = b.TenLoaiSanPham,
                            TenSanPham = a.TenSanPham
                          
                        }).Distinct();
            return model.OrderBy(m => m.ID_SANPHAM).ToList();
        }

        public static List<Product_Full> full_sanpham_byIDLOAISP_parent(int Root)
        {
            var model = (from a in db.Table_SANPHAMs
                         join b in db.Table_LOAISANPHAMs on a.ID_LOAISANPHAM equals b.ID_LOAISANPHAM
                         join c in db.Table_NhaSXes on a.ID_NSX equals c.ID_NSX
                         where b.Root == Root
                         select new Product_Full()
                         {
                             ID_SANPHAM = a.ID_SANPHAM,
                             ID_LOAISANPHAM = b.ID_LOAISANPHAM,
                             ID_NSX = a.ID_NSX,
                             ChietKhau = a.ChietKhau,
                             ChiTiet = a.ChiTiet,
                             DonGia = (double)a.DonGia,
                             HINHANH = a.HINHANH,
                             Ngung = a.Ngung,
                             NhaSX = c.NhaSX,
                             NoiSX = c.NoiSX,
                             TENLOAISANPHAM = b.TenLoaiSanPham,
                             TenSanPham = a.TenSanPham,
                             UuTien = a.UuTien
                             
                         }).Distinct();
            return model.OrderBy(m => m.ID_SANPHAM).ToList();
        }
        public static List<Product_Full> getImg_byID(int id_hinhanh)
        {
            var model = from a in db.Table_SANPHAMs
                        join b in db.Table_MUCHINHANHs on a.ID_SANPHAM equals b.ID_SANPHAM
                        where b.ID_HINHANH == id_hinhanh
                        select new Product_Full()
                        {
                            ID_SANPHAM = a.ID_SANPHAM,
                            ID_HINHANH = b.ID_HINHANH,
                            HINHANH = b.HINHANH_N
                        };
            return model.OrderBy(m => m.ID_SANPHAM).ToList();
        }
        public static List<Product_Full> getImg_byIDSP(int id_sanpham)
        {
            var model = from a in db.Table_SANPHAMs
                        join b in db.Table_MUCHINHANHs on a.ID_SANPHAM equals b.ID_SANPHAM
                        where a.ID_SANPHAM == id_sanpham
                        select new Product_Full()
                        {
                            ID_SANPHAM = a.ID_SANPHAM,
                            ID_HINHANH = b.ID_HINHANH,
                            HINHANH = b.HINHANH_N
                        };
            return model.OrderBy(m => m.ID_SANPHAM).ToList();
        }

        public static List<Product_Full> full_sanpham_byID_SANPHAM(int id_sanpham)
        {
            var model = (from a in db.Table_SANPHAMs
                         join b in db.Table_LOAISANPHAMs on a.ID_LOAISANPHAM equals b.ID_LOAISANPHAM
                         join c in db.Table_NhaSXes on a.ID_NSX equals c.ID_NSX
                         where a.ID_SANPHAM == id_sanpham
                         select new Product_Full()
                         {
                             ID_SANPHAM = a.ID_SANPHAM,
                             ID_LOAISANPHAM = b.ID_LOAISANPHAM,
                             ID_NSX = a.ID_NSX,
                             ChietKhau = a.ChietKhau,
                             ChiTiet = a.ChiTiet,
                             DonGia = (double)a.DonGia,
                             HINHANH = a.HINHANH,
                             Ngung = a.Ngung,
                             NhaSX = c.NhaSX,
                             NoiSX = c.NoiSX,
                             TENLOAISANPHAM = b.TenLoaiSanPham,
                             TenSanPham = a.TenSanPham,
                             Root = b.Root
                         }).Distinct();
            return model.OrderBy(m => m.ID_SANPHAM).ToList();
        }

        public static List<LoaiSanPham> getLoai_byRoot(int root)
        {
            var model = from a in db.Table_LOAISANPHAMs
                        where a.Root == root
                        select new LoaiSanPham()
                        {
                            ID_LOAISANPHAM = a.ID_LOAISANPHAM,
                            TenLoaiSanPham = a.TenLoaiSanPham,
                            Root = a.Root,
                            soluonghienco = db.Table_SANPHAMs.Where(m=>m.ID_LOAISANPHAM == a.ID_LOAISANPHAM).Count()
                        };
            return model.OrderBy(m => m.ID_LOAISANPHAM).ToList();
        }

        public static List<LoaiSanPham> getLoaiGoc()
        {
            var model = from a in db.Table_LOAISANPHAMs
                        where a.Root == 0
                        select new LoaiSanPham()
                        {
                            ID_LOAISANPHAM = a.ID_LOAISANPHAM,
                            TenLoaiSanPham = a.TenLoaiSanPham,
                            Root = a.Root,
                            soluonghienco = db.Table_LOAISANPHAMs.Where(m => m.Root == a.ID_LOAISANPHAM).Count(),
                            
                        };
            return model.OrderBy(m => m.ID_LOAISANPHAM).ToList();
        }

        public static List<Product_Full> getTuyChon_byIDSP(int id_sanpham)
        {
            var model = from a in db.Table_SANPHAMs
                        join b in db.Table_TUYCHONs on a.ID_SANPHAM equals b.ID_SANPHAM
                        where a.ID_SANPHAM == id_sanpham
                        select new Product_Full()
                        {
                            ID_TUYCHON = b.ID_TUYCHON,
                            ID_SANPHAM = a.ID_SANPHAM,
                            TuyChon = b.TuyChon,
                            SoLuong = b.SoLuong,
                            DonGia = b.DonGia,
                        };
            return model.OrderBy(m => m.ID_SANPHAM).ToList();
        }

        public static List<Product_Full> getTuyChon_byIDTC(int id_tuychon)
        {
            var model = from a in db.Table_TUYCHONs
                        join b in db.Table_SANPHAMs on a.ID_SANPHAM equals b.ID_SANPHAM
                        where  a.ID_TUYCHON == id_tuychon
                        select new Product_Full()
                        {
                            ID_TUYCHON = a.ID_TUYCHON,
                            ID_SANPHAM = b.ID_SANPHAM,
                            TuyChon = a.TuyChon,
                            SoLuong = a.SoLuong,
                            DonGia = a.DonGia,
                        };
            return model.OrderBy(m => m.ID_SANPHAM).ToList();
        }
    }
}