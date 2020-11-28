
using DA_Web.EF;
using DA_Web.Models;
using DA_Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA_Web.XuLy
{
    public class DonHang
    {
        public static dbQL_BanHangDataContext db = new dbQL_BanHangDataContext();

        public static List<HoaDon> getHoaDon_byIDNHANVIEN(int ID_NHANVIEN)
        {
            var model = from a in db.Table_DONHANGs
                        where a.ID_NGUOIBAN == ID_NHANVIEN

                        select new HoaDon() 
                        {
                            ID_DONHANG = a.ID_DONHANG,
                            ID_KHACHHANG = a.ID_KHACHHANG,
                            ID_NGUOIBAN = a.ID_NGUOIBAN,
                            ID_NGUOIGIAO = a.ID_NGUOIGIAO,
                            NgayGiaoDich = (DateTime)a.NgayGiaoDich,
                            Damua = a.Damua,
                            TONGTIEN = a.TONGTIEN
                        };
            return model.OrderByDescending(m => m.NgayGiaoDich).Take(15).ToList();
        }

        public static List<ChiTietHoaDon> getChiTietHoaDon_byIDDONHANG(int ID_DONHANG)
        {
            var model = from a in db.Table_DONHANG_DMs
                        join b in db.Table_SANPHAMs on a.ID_SANPHAM equals b.ID_SANPHAM
                        where a.ID_DONHANG == ID_DONHANG
                        select new ChiTietHoaDon()
                        {
                            ID_DONHANG_DM = a.ID_DONHANG_DM,
                            ID_DONHANG = a.ID_DONHANG,
                            ID_SANPHAM = a.ID_SANPHAM,
                            SoLuong = a.SoLuong,
                            TenSanPham = b.TenSanPham,
                            TuyChon = a.TuyChon,
                            Giatien = b.DonGia,
                            TinhTrang = a.TinhTrang,
                            HinhAnh = b.HINHANH,
                                
                        };
            return model.OrderBy(m => m.ID_DONHANG_DM).ToList();
        }

        public static int getCount_HoaDonChuaGiao(int ID_NGUOIGIAO)
        {
            var model = from a in db.Table_DONHANGs
                        where a.ID_NGUOIGIAO == ID_NGUOIGIAO && a.Damua == false
                        select a;
            int soluong = model.Count();
            return soluong;
        }

        public static List<HoaDonGiaoHang> getHoaDonGiaoHang()
        {
            var model = from a in db.Table_DONHANGs                       
                        join b in db.Table_KHACHHANGs on a.ID_KHACHHANG equals b.ID_KHACHHANG
                        join c in db.Table_NHANVIENs on a.ID_NGUOIGIAO equals c.ID_NHANVIEN
                        where c.ID_LOAINHANVIEN == 2 && a.TinhTrang == true || a.TinhTrang == null
                        select new HoaDonGiaoHang()
                        {                           
                            ID_DONHANG = a.ID_DONHANG,
                            TENKH = b.HoTen,
                            SDT = b.SDT,
                            TongTien = a.TONGTIEN,
                            DIACHI = b.DiaChi,
                            Dagiao = a.Damua
                        };
            return model.OrderBy(m => m.Dagiao).ToList();
        }

        public static List<HoaDonGiaoHang> getHoaDonGiaoHang_DaHuy()
        {
            var model = from a in db.Table_DONHANGs
                        join b in db.Table_KHACHHANGs on a.ID_KHACHHANG equals b.ID_KHACHHANG
                        join c in db.Table_NHANVIENs on a.ID_NGUOIGIAO equals c.ID_NHANVIEN
                        where c.ID_LOAINHANVIEN == 2 && a.TinhTrang == false 
                        select new HoaDonGiaoHang()
                        {
                            ID_DONHANG = a.ID_DONHANG,
                            TENKH = b.HoTen,
                            SDT = b.SDT,
                            TongTien = a.TONGTIEN,
                            DIACHI = b.DiaChi,
                            Dagiao = a.Damua
                        };
            return model.OrderBy(m => m.Dagiao).ToList();
        }

        public static List<HoaDon> getHoaDonGiaoHang_ChuaMua(int ID_NHANVIEN)
        {
            var model = from a in db.Table_DONHANGs
                        join b in db.Table_KHACHHANGs on a.ID_KHACHHANG equals b.ID_KHACHHANG
                        where a.ID_NGUOICHOT == ID_NHANVIEN || a.ID_NGUOICHOT == null
                        select new HoaDon() 
                        {
                            ID_DONHANG = a.ID_DONHANG,
                            ID_KHACHHANG = a.ID_KHACHHANG,
                            ID_NGUOIBAN = a.ID_NGUOIBAN,
                            ID_NGUOIGIAO = a.ID_NGUOIGIAO,
                            TEN_NGUOIBAN = db.Table_NHANVIENs.Where(m=>m.ID_NHANVIEN == a.ID_NGUOIBAN).Select(m=>m.HoTen).Single(),
                            NgayGiaoDich =(DateTime)a.NgayGiaoDich,
                            TinhTrangDon = (bool)a.TinhTrang,
                            Damua = a.Damua,
                            TONGTIEN = a.TONGTIEN,
                            
                        };
            return model.OrderBy(m => m.ID_NGUOIGIAO).ThenBy(m=>m.Damua).ToList();
        }
        public static List<HoaDon> getHoaDonGiaoHang_ChuaMua_ByDate(string date)
        {
            var model = from a in db.Table_DONHANGs
                        join b in db.Table_KHACHHANGs on a.ID_KHACHHANG equals b.ID_KHACHHANG
                        where a.NgayGiaoDich.ToString().Contains(date)
                        select new HoaDon()
                        {
                            ID_DONHANG = a.ID_DONHANG,
                            ID_KHACHHANG = a.ID_KHACHHANG,
                            ID_NGUOIBAN = a.ID_NGUOIBAN,
                            ID_NGUOIGIAO = a.ID_NGUOIGIAO,
                            TEN_NGUOIBAN = db.Table_NHANVIENs.Where(m => m.ID_NHANVIEN == a.ID_NGUOIBAN).Select(m => m.HoTen).Single(),
                            NgayGiaoDich = (DateTime)a.NgayGiaoDich,
                            Damua = a.Damua,
                            TinhTrangDon = (bool)a.TinhTrang,
                            TONGTIEN = a.TONGTIEN,

                        };
            return model.OrderBy(m => m.ID_NGUOIGIAO != null).ThenBy(m => m.Damua).ToList();
        }

        public static List<NhanVien> getNhanVien_byID(int ID_NHANVIEN)
        {
            var model = from a in db.Table_NHANVIENs
                        where a.ID_NHANVIEN == ID_NHANVIEN
                        select new NhanVien()
                        {
                            ID_NHANVIEN = a.ID_NHANVIEN,
                            HoTen = a.HoTen,
                            GioiTinh = a.GioiTinh,
                            Diachi = a.Diachi,
                            Email = a.Email,
                            ID_LOAINHANVIEN = a.ID_LOAINHANVIEN,
                            Username = a.Username,
                            Password = a.Password,
                            ANHDAIDIEN = a.ANHDAIDIEN,
                            SDT = a.SDT
                        };
            return model.ToList();
        }

        public static List<ChiTietHoaDon> getChiTietHoaDon_byIDDONHANG_DM(int ID_DONHANG_DM)
        {
            var model = from a in db.Table_DONHANG_DMs
                        join b in db.Table_SANPHAMs on a.ID_SANPHAM equals b.ID_SANPHAM
                        where a.ID_DONHANG_DM == ID_DONHANG_DM
                        select new ChiTietHoaDon()
                        {
                            ID_DONHANG_DM = a.ID_DONHANG_DM,
                            ID_DONHANG = a.ID_DONHANG,
                            ID_SANPHAM = a.ID_SANPHAM,
                            SoLuong = a.SoLuong,
                            TuyChon =  a.TuyChon,
                            TenSanPham = b.TenSanPham,
                            Giatien = b.DonGia,
                            TinhTrang = a.TinhTrang,
                            HinhAnh = b.HINHANH
                        };
            return model.OrderBy(m => m.ID_DONHANG_DM).ToList();
        }


        public static List<HoaDon> getDonHang_bySelect(int form, int ID_NHANVIEN)
        {
            if(form == 0)
            {
                //get đơn hàng đã thanh toán
                var model = from a in db.Table_DONHANGs
                            join b in db.Table_KHACHHANGs on a.ID_KHACHHANG equals b.ID_KHACHHANG
                            where (a.ID_NGUOICHOT == ID_NHANVIEN || a.ID_NGUOICHOT == null) && a.Damua == true
                            select new HoaDon()
                            {
                                ID_DONHANG = a.ID_DONHANG,
                                ID_KHACHHANG = a.ID_KHACHHANG,
                                ID_NGUOIBAN = a.ID_NGUOIBAN,
                                ID_NGUOIGIAO = a.ID_NGUOIGIAO,
                                TEN_NGUOIBAN = db.Table_NHANVIENs.Where(m => m.ID_NHANVIEN == a.ID_NGUOIBAN).Select(m => m.HoTen).Single(),
                                NgayGiaoDich = (DateTime)a.NgayGiaoDich,
                                TinhTrangDon = (bool)a.TinhTrang,
                                Damua = a.Damua,
                                TONGTIEN = a.TONGTIEN,

                            };
                return model.OrderBy(m => m.ID_NGUOIGIAO != null).ThenBy(m => m.Damua).ToList();
            }else if(form == 1)
            {
                //get đơn hàng chưa thanh toán
                var model = from a in db.Table_DONHANGs
                            join b in db.Table_KHACHHANGs on a.ID_KHACHHANG equals b.ID_KHACHHANG
                            where (a.ID_NGUOICHOT == ID_NHANVIEN || a.ID_NGUOICHOT == null) && a.Damua == false && a.TinhTrang != false
                            select new HoaDon()
                            {
                                ID_DONHANG = a.ID_DONHANG,
                                ID_KHACHHANG = a.ID_KHACHHANG,
                                ID_NGUOIBAN = a.ID_NGUOIBAN,
                                ID_NGUOIGIAO = a.ID_NGUOIGIAO,
                                TEN_NGUOIBAN = db.Table_NHANVIENs.Where(m => m.ID_NHANVIEN == a.ID_NGUOIBAN).Select(m => m.HoTen).Single(),
                                NgayGiaoDich = (DateTime)a.NgayGiaoDich,
                                TinhTrangDon = (bool)a.TinhTrang,
                                Damua = a.Damua,
                                TONGTIEN = a.TONGTIEN,

                            };
                return model.OrderBy(m => m.ID_NGUOIGIAO != null).ThenBy(m => m.Damua).ToList();
            }
            else
            {
                // get đơn hàng đã bị hủy
                var model = from a in db.Table_DONHANGs
                            join b in db.Table_KHACHHANGs on a.ID_KHACHHANG equals b.ID_KHACHHANG
                            where (a.ID_NGUOICHOT == ID_NHANVIEN || a.ID_NGUOICHOT == null) && a.TinhTrang == false
                            select new HoaDon()
                            {
                                ID_DONHANG = a.ID_DONHANG,
                                ID_KHACHHANG = a.ID_KHACHHANG,
                                ID_NGUOIBAN = a.ID_NGUOIBAN,
                                ID_NGUOIGIAO = a.ID_NGUOIGIAO,
                                TEN_NGUOIBAN = db.Table_NHANVIENs.Where(m => m.ID_NHANVIEN == a.ID_NGUOIBAN).Select(m => m.HoTen).Single(),
                                NgayGiaoDich = (DateTime)a.NgayGiaoDich,
                                TinhTrangDon = (bool)a.TinhTrang,
                                Damua = a.Damua,
                                TONGTIEN = a.TONGTIEN,

                            };
                return model.OrderBy(m => m.ID_NGUOIGIAO != null).ThenBy(m => m.Damua).ToList();
            }
           
        }

        public static List<HoaDon> getDonHang_bySelect_bydate(int form, int ID_NHANVIEN,string date)
        {
            if(form == 0)
            {
                //get đơn hàng đã thanh toán
                var model = from a in db.Table_DONHANGs
                            join b in db.Table_KHACHHANGs on a.ID_KHACHHANG equals b.ID_KHACHHANG
                            where (a.ID_NGUOICHOT == ID_NHANVIEN || a.ID_NGUOICHOT == null) && a.Damua == true &&  a.NgayGiaoDich.ToString().Contains(date)
                            select new HoaDon()
                            {
                                ID_DONHANG = a.ID_DONHANG,
                                ID_KHACHHANG = a.ID_KHACHHANG,
                                ID_NGUOIBAN = a.ID_NGUOIBAN,
                                ID_NGUOIGIAO = a.ID_NGUOIGIAO,
                                TEN_NGUOIBAN = db.Table_NHANVIENs.Where(m => m.ID_NHANVIEN == a.ID_NGUOIBAN).Select(m => m.HoTen).Single(),
                                NgayGiaoDich = (DateTime)a.NgayGiaoDich,
                                TinhTrangDon = (bool)a.TinhTrang,
                                Damua = a.Damua,
                                TONGTIEN = a.TONGTIEN,

                            };
                return model.OrderBy(m => m.ID_NGUOIGIAO != null).ThenBy(m => m.Damua).ToList();
            }else if(form == 1)
            {
                //get đơn hàng chưa thanh toán
                var model = from a in db.Table_DONHANGs
                            join b in db.Table_KHACHHANGs on a.ID_KHACHHANG equals b.ID_KHACHHANG
                            where (a.ID_NGUOICHOT == ID_NHANVIEN || a.ID_NGUOICHOT == null) && a.Damua == false && a.TinhTrang != false && a.NgayGiaoDich.ToString().Contains(date)
                            select new HoaDon()
                            {
                                ID_DONHANG = a.ID_DONHANG,
                                ID_KHACHHANG = a.ID_KHACHHANG,
                                ID_NGUOIBAN = a.ID_NGUOIBAN,
                                ID_NGUOIGIAO = a.ID_NGUOIGIAO,
                                TEN_NGUOIBAN = db.Table_NHANVIENs.Where(m => m.ID_NHANVIEN == a.ID_NGUOIBAN).Select(m => m.HoTen).Single(),
                                NgayGiaoDich = (DateTime)a.NgayGiaoDich,
                                TinhTrangDon = (bool)a.TinhTrang,
                                Damua = a.Damua,
                                TONGTIEN = a.TONGTIEN,

                            };
                return model.OrderBy(m => m.ID_NGUOIGIAO != null).ThenBy(m => m.Damua).ToList();
            }
            else
            {
                // get đơn hàng đã bị hủy
                var model = from a in db.Table_DONHANGs
                            join b in db.Table_KHACHHANGs on a.ID_KHACHHANG equals b.ID_KHACHHANG
                            where (a.ID_NGUOICHOT == ID_NHANVIEN || a.ID_NGUOICHOT == null) && a.TinhTrang == false && a.NgayGiaoDich.ToString().Contains(date)
                            select new HoaDon()
                            {
                                ID_DONHANG = a.ID_DONHANG,
                                ID_KHACHHANG = a.ID_KHACHHANG,
                                ID_NGUOIBAN = a.ID_NGUOIBAN,
                                ID_NGUOIGIAO = a.ID_NGUOIGIAO,
                                TEN_NGUOIBAN = db.Table_NHANVIENs.Where(m => m.ID_NHANVIEN == a.ID_NGUOIBAN).Select(m => m.HoTen).Single(),
                                NgayGiaoDich = (DateTime)a.NgayGiaoDich,
                                TinhTrangDon = (bool)a.TinhTrang,
                                Damua = a.Damua,
                                TONGTIEN = a.TONGTIEN,

                            };
                return model.OrderBy(m => m.ID_NGUOIGIAO != null).ThenBy(m => m.Damua).ToList();
            }
           
        }

        
    }
}