using DA_Web.Models;
using DA_Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA_Web.Areas.Admin.Models
{
    public class DonHangDAO
    {
        public static dbQL_BanHangDataContext db = new dbQL_BanHangDataContext();

        public static List<HoaDon> getHoaDon()
        {
            var model = from a in db.Table_DONHANGs
                        where a.NgayGiaoDich == DateTime.Now.Date
                        select new HoaDon()
                        {
                            ID_DONHANG = a.ID_DONHANG,
                            ID_KHACHHANG = a.ID_KHACHHANG,
                            ID_NGUOIBAN = a.ID_NGUOIBAN,
                            ID_NGUOIGIAO = a.ID_NGUOIGIAO,
                            Damua = a.Damua,
                            TONGTIEN = a.TONGTIEN,
                            TongHD = (db.Table_DONHANGs.Where(m => m.ID_DONHANG == a.ID_DONHANG).Count()),
                        };
            return model.OrderBy(m => m.ID_DONHANG).ToList();
        }
        public static List<HoaDon> getHoaDon_ByDate(DateTime date)
        {
            var model = from a in db.Table_DONHANGs
                        where a.NgayGiaoDich == date.Date
                        select new HoaDon()
                        {
                            ID_DONHANG = a.ID_DONHANG,
                            ID_KHACHHANG = a.ID_KHACHHANG,
                            ID_NGUOIBAN = a.ID_NGUOIBAN,
                            ID_NGUOIGIAO = a.ID_NGUOIGIAO,
                            Damua = a.Damua,
                            TONGTIEN = a.TONGTIEN,
                            TongHD = (db.Table_DONHANGs.Where(m => m.ID_DONHANG == a.ID_DONHANG).Count()),
                        };
            return model.OrderBy(m => m.ID_DONHANG).ToList();
        }
        public static List<HoaDon> getHoaDon_Full(int ID_DONHANG)
        {
            var model = from a in db.Table_DONHANGs
                        join c in db.Table_KHACHHANGs on a.ID_KHACHHANG equals c.ID_KHACHHANG                                               
                        where a.ID_DONHANG == ID_DONHANG
                        select new HoaDon()
                        {
                            ID_DONHANG = a.ID_DONHANG,
                            ID_KHACHHANG = a.ID_KHACHHANG,
                            HOTEN = c.HoTen,
                            SDT = c.SDT,
                            ID_NGUOIBAN = a.ID_NGUOIBAN,
                            TEN_NGUOIBAN = db.Table_NHANVIENs.Where(m=>m.ID_NHANVIEN == a.ID_NGUOIBAN).Select(n=>n.HoTen).SingleOrDefault(),
                            TKBank = db.Table_NHANVIENs.Where(m => m.ID_NHANVIEN == a.ID_NGUOIBAN).Select(n => n.TKBank).SingleOrDefault(),
                            ID_NGUOIGIAO = a.ID_NGUOIGIAO,
                            TEN_NGUOIGIAO = db.Table_NHANVIENs.Where(m => m.ID_NHANVIEN == a.ID_NGUOIGIAO).Select(n => n.HoTen).SingleOrDefault(),
                            TKBank_NguoiGiao = db.Table_NHANVIENs.Where(m => m.ID_NHANVIEN == a.ID_NGUOIGIAO).Select(n => n.TKBank).SingleOrDefault(),

                            NgayGiaoDich = (DateTime)a.NgayGiaoDich,
                          
                            TONGTIEN = a.TONGTIEN
                        };
            return model.OrderBy(m => m.ID_DONHANG).ToList();
        }

        public static List<ChiTietHoaDon> getChiTietHoaDon_byID(int ID_DONHANG)
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
                            Giatien  = b.DonGia,
                            TinhTrang = a.TinhTrang,
                            HinhAnh = b.HINHANH
                        };
            return model.OrderBy(m => m.TinhTrang).ToList();
        }
    }
}