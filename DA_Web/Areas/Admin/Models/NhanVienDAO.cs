using DA_Web.Models;
using DA_Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA_Web.Areas.Admin.Models
{
    public class NhanVienDAO
    {
        public static dbQL_BanHangDataContext data = new dbQL_BanHangDataContext();

        public static List<NhanVien> getNhanVien_byIDLOAINV(int id_loainv)
        {
            var model = from a in data.Table_NHANVIENs
                        join b in data.Table_LOAINHANVIENs on a.ID_LOAINHANVIEN equals b.ID_LOAINHANVIEN
                        where b.ID_LOAINHANVIEN == id_loainv
                        select new NhanVien()
                        {
                            ID_NHANVIEN = a.ID_NHANVIEN,
                            HoTen = a.HoTen,
                            Username = a.Username,
                            Password = a.Password,
                            GioiTinh = a.GioiTinh,
                            SDT = a.SDT,
                            TKBank = a.TKBank,
                            Diachi = a.Diachi,
                            Email = a.Email,
                            Skype = a.Skype,
                            ID_LOAINHANVIEN = a.ID_LOAINHANVIEN,
                            Tenloainhanvien = b.Tenloainhanvien
                        };
            return model.OrderBy(m => m.ID_NHANVIEN).ToList();
        }

        public static List<NhanVien> getNhanVien_byLoai(int id)
        {
            if (id == 0)
            {
                var model = from a in data.Table_NHANVIENs
                            join b in data.Table_LOAINHANVIENs on a.ID_LOAINHANVIEN equals b.ID_LOAINHANVIEN
                            where b.ID_LOAINHANVIEN > 1
                            select new NhanVien()
                            {
                                ID_NHANVIEN = a.ID_NHANVIEN,
                                HoTen = a.HoTen,
                                Username = a.Username,
                                Password = a.Password,
                                GioiTinh = a.GioiTinh,
                                SDT = a.SDT,
                                TKBank = a.TKBank,
                                Diachi = a.Diachi,
                                Email = a.Email,
                                Skype = a.Skype,
                                ID_LOAINHANVIEN = a.ID_LOAINHANVIEN,
                                Tenloainhanvien = b.Tenloainhanvien
                            };
                return model.OrderBy(m => m.ID_NHANVIEN).ToList();
            }
            else
            {
                var model = from a in data.Table_NHANVIENs
                            join b in data.Table_LOAINHANVIENs on a.ID_LOAINHANVIEN equals b.ID_LOAINHANVIEN
                            where b.ID_LOAINHANVIEN == 1
                            select new NhanVien()
                            {
                                ID_NHANVIEN = a.ID_NHANVIEN,
                                HoTen = a.HoTen,
                                Username = a.Username,
                                Password = a.Password,
                                GioiTinh = a.GioiTinh,
                                SDT = a.SDT,
                                TKBank = a.TKBank,
                                Diachi = a.Diachi,
                                Email = a.Email,
                                Skype = a.Skype,
                                ID_LOAINHANVIEN = a.ID_LOAINHANVIEN,
                                Tenloainhanvien = b.Tenloainhanvien
                            };
                return model.OrderBy(m => m.ID_NHANVIEN).ToList();
            }
        }

        public static List<NhanVien> getNhanVien_byNV(int id_nv)
        {
            var model = from a in data.Table_NHANVIENs
                        join b in data.Table_LOAINHANVIENs
                        on a.ID_LOAINHANVIEN equals b.ID_LOAINHANVIEN
                        where a.ID_NHANVIEN == id_nv
                        select new NhanVien()
                        {
                            ID_NHANVIEN = a.ID_NHANVIEN,
                            HoTen = a.HoTen,
                            Username = a.Username,
                            Password = a.Password,
                            GioiTinh = a.GioiTinh,
                            SDT = a.SDT,
                            TKBank = a.TKBank,
                            Diachi = a.Diachi,
                            Email = a.Email,
                            Skype = a.Skype,
                            ID_LOAINHANVIEN = a.ID_LOAINHANVIEN,
                            Tenloainhanvien = b.Tenloainhanvien,
                            ANHDAIDIEN = a.ANHDAIDIEN
                        };
            return model.ToList();
        }
        public static List<NhanVien> getNhanVIen_ChotDon()
        {
            var model = from a in data.Table_NHANVIENs
                        where a.ID_LOAINHANVIEN == 3
                        select new NhanVien()
                        {
                            ID_NHANVIEN = a.ID_NHANVIEN,
                            HoTen = a.HoTen,
                            Username = a.Username,
                            Password = a.Password,
                            GioiTinh = a.GioiTinh,
                            SDT = a.SDT,
                            TKBank = a.TKBank,
                            Diachi = a.Diachi,
                            Email = a.Email,
                            Skype = a.Skype,
                            ID_LOAINHANVIEN = a.ID_LOAINHANVIEN,

                            ANHDAIDIEN = a.ANHDAIDIEN
                        };
            return model.ToList();
        }
        public static List<NhanVien> getNhanVIen_CTV()
        {
            var model = from a in data.Table_NHANVIENs
                        where a.ID_LOAINHANVIEN != 0 && a.ID_LOAINHANVIEN != 2
                        select new NhanVien()
                        {
                            ID_NHANVIEN = a.ID_NHANVIEN,
                            HoTen = a.HoTen,
                            Username = a.Username,
                            Password = a.Password,
                            GioiTinh = a.GioiTinh,
                            SDT = a.SDT,
                            TKBank = a.TKBank,
                            Diachi = a.Diachi,
                            Email = a.Email,
                            Skype = a.Skype,
                            ID_LOAINHANVIEN = a.ID_LOAINHANVIEN,

                            ANHDAIDIEN = a.ANHDAIDIEN
                        };
            return model.ToList();
        }

        //Chức vụ
        public static List<LoaiNV> getChucVu()
        {
            var model = from a in data.Table_LOAINHANVIENs
                        where a.ID_LOAINHANVIEN != 0
                        select new LoaiNV()
                        {
                            ID_LOAINHANVIEN = a.ID_LOAINHANVIEN,
                            Tenloainhanvien = a.Tenloainhanvien,
                            soluongNV = (data.Table_NHANVIENs.Where(m => m.ID_LOAINHANVIEN == a.ID_LOAINHANVIEN).Count())
                        };
            return model.OrderBy(m => m.ID_LOAINHANVIEN).ToList();
        }

        public static List<LoaiNV> getChucVu_byID_loai(int id_loainv)
        {
            var model = from a in data.Table_LOAINHANVIENs
                        where a.ID_LOAINHANVIEN == id_loainv
                        select new LoaiNV()
                        {
                            ID_LOAINHANVIEN = a.ID_LOAINHANVIEN,
                            Tenloainhanvien = a.Tenloainhanvien,

                        };
            return model.OrderBy(m => m.ID_LOAINHANVIEN).ToList();
        }
        public static List<NhanVien> getChietKhau_byIDNV()
        {
            var model = from a in data.Table_NHANVIENs
                        join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOICHOT
                        join c in data.Table_DONHANG_DMs on b.ID_DONHANG equals c.ID_DONHANG
                        join d in data.Table_SANPHAMs on c.ID_SANPHAM equals d.ID_SANPHAM
                        where b.Damua == true && a.ID_LOAINHANVIEN == 3 && b.NgayGiaoDich == DateTime.Now && b.ID_NGUOIBAN != null

                        select new NhanVien()
                        {
                            ID_SANPHAM = d.ID_SANPHAM,
                            ID_NHANVIEN = a.ID_NHANVIEN,
                            HoTen = a.HoTen,
                            ChietKhau = d.ChietKhau,
                            TongDoanhThu = data.Table_DONHANGs.Where(m => m.ID_NGUOICHOT == a.ID_NHANVIEN && m.Damua == true && m.NgayGiaoDich == DateTime.Now).Sum(m => m.TONGTIEN),
                            ChietKhauNgay = d.ChietKhau * c.SoLuong,
                            TongSoDon = (data.Table_DONHANGs.Where(m => m.ID_NGUOICHOT == a.ID_NHANVIEN && m.Damua == true && m.NgayGiaoDich == DateTime.Now).Count()),
                        };
            return model.ToList();
        }

        public static List<NhanVien> getChietKhau_byIDNV_CTV()
        {
            var model = from a in data.Table_NHANVIENs
                        join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOIBAN
                        join c in data.Table_DONHANG_DMs on b.ID_DONHANG equals c.ID_DONHANG
                        join d in data.Table_SANPHAMs on c.ID_SANPHAM equals d.ID_SANPHAM
                        where b.Damua == true && a.ID_LOAINHANVIEN != 0 && b.NgayGiaoDich == DateTime.Now && b.ID_NGUOIBAN != null

                        select new NhanVien()
                        {
                            ID_SANPHAM = d.ID_SANPHAM,
                            ID_NHANVIEN = a.ID_NHANVIEN,
                            HoTen = a.HoTen,
                            ChietKhau = d.ChietKhau,
                            TongDoanhThu = data.Table_DONHANGs.Where(m => m.ID_NGUOIBAN == a.ID_NHANVIEN && m.Damua == true && m.NgayGiaoDich == DateTime.Now).Sum(m => m.TONGTIEN),
                            ChietKhauNgay = d.ChietKhau * c.SoLuong,
                            TongSoDon = (data.Table_DONHANGs.Where(m => m.ID_NGUOIBAN == a.ID_NHANVIEN && m.Damua == true && m.NgayGiaoDich == DateTime.Now).Count()),
                        };
            return model.ToList();
        }

        public static List<NhanVien> getChietKhau_byIDNV_Fail()
        {
            var model = from a in data.Table_NHANVIENs
                        join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOICHOT
                        join c in data.Table_DONHANG_DMs on b.ID_DONHANG equals c.ID_DONHANG
                        join d in data.Table_SANPHAMs on c.ID_SANPHAM equals d.ID_SANPHAM
                        where b.Damua == false && a.ID_LOAINHANVIEN == 3 && b.NgayGiaoDich == DateTime.Now && b.TinhTrang == false
                        select new NhanVien()
                        {
                            ID_SANPHAM = d.ID_SANPHAM,
                            ID_NHANVIEN = a.ID_NHANVIEN,
                            HoTen = a.HoTen,
                            ChietKhau = d.ChietKhau,
                            TongDoanhThu = data.Table_DONHANGs.Where(m => m.ID_NGUOICHOT == a.ID_NHANVIEN && m.Damua == false && m.NgayGiaoDich == DateTime.Now && m.TinhTrang == false).Sum(m => m.TONGTIEN),
                            ChietKhauNgay = d.ChietKhau * c.SoLuong,
                            TongSoDon = (data.Table_DONHANGs.Where(m => m.ID_NGUOICHOT == a.ID_NHANVIEN && m.Damua == false && m.NgayGiaoDich == DateTime.Now && m.TinhTrang == false).Count()),
                        };
            return model.ToList();
        }
        //success
        public static List<NhanVien> getChietKhau_byDate(DateTime date, int idnv)
        {
            if (idnv != -1)
            {

                var model = from a in data.Table_NHANVIENs
                            join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOICHOT
                            join c in data.Table_DONHANG_DMs on b.ID_DONHANG equals c.ID_DONHANG
                            join d in data.Table_SANPHAMs on c.ID_SANPHAM equals d.ID_SANPHAM
                            where b.Damua == true && b.NgayGiaoDich == date && a.ID_NHANVIEN == idnv && b.ID_NGUOIBAN != null

                            select new NhanVien()
                            {
                                ID_SANPHAM = d.ID_SANPHAM,
                                ID_NHANVIEN = a.ID_NHANVIEN,
                                HoTen = a.HoTen,
                                ChietKhau = d.ChietKhau,
                                TongDoanhThu = data.Table_DONHANGs.Where(m => m.ID_NGUOICHOT == a.ID_NHANVIEN && m.Damua == true && m.NgayGiaoDich == date).Sum(m => m.TONGTIEN),
                                ChietKhauNgay = d.ChietKhau * c.SoLuong,
                                TongSoDon = (data.Table_DONHANGs.Where(m => m.ID_NGUOICHOT == a.ID_NHANVIEN && m.Damua == true && m.NgayGiaoDich == date).Count()),
                            };
                return model.ToList();


            }
            else
            {
                var model = from a in data.Table_NHANVIENs
                            join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOICHOT
                            join c in data.Table_DONHANG_DMs on b.ID_DONHANG equals c.ID_DONHANG
                            join d in data.Table_SANPHAMs on c.ID_SANPHAM equals d.ID_SANPHAM
                            where b.Damua == true && b.NgayGiaoDich == date && a.ID_LOAINHANVIEN == 3 && b.ID_NGUOIBAN != null

                            select new NhanVien()
                            {
                                ID_SANPHAM = d.ID_SANPHAM,
                                ID_NHANVIEN = a.ID_NHANVIEN,
                                HoTen = a.HoTen,
                                ChietKhau = d.ChietKhau,
                                TongDoanhThu = data.Table_DONHANGs.Where(m => m.ID_NGUOICHOT == a.ID_NHANVIEN && m.Damua == true && m.NgayGiaoDich == date).Sum(m => m.TONGTIEN),
                                ChietKhauNgay = d.ChietKhau * c.SoLuong,
                                TongSoDon = (data.Table_DONHANGs.Where(m => m.ID_NGUOICHOT == a.ID_NHANVIEN && m.Damua == true && m.NgayGiaoDich == date).Count()),
                            };
                return model.ToList();
            }
        }
        //fail
        public static List<NhanVien> getChietKhau_byDate_Fail(DateTime date, int idnv)
        {
            if (idnv != -1)
            {

                var model = from a in data.Table_NHANVIENs
                            join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOICHOT
                            join c in data.Table_DONHANG_DMs on b.ID_DONHANG equals c.ID_DONHANG
                            join d in data.Table_SANPHAMs on c.ID_SANPHAM equals d.ID_SANPHAM
                            where b.Damua == false && b.NgayGiaoDich == date && a.ID_NHANVIEN == idnv && b.TinhTrang == false

                            select new NhanVien()
                            {
                                ID_SANPHAM = d.ID_SANPHAM,
                                ID_NHANVIEN = a.ID_NHANVIEN,
                                HoTen = a.HoTen,
                                ChietKhau = d.ChietKhau,
                                TongDoanhThu = data.Table_DONHANGs.Where(m => m.ID_NGUOICHOT == a.ID_NHANVIEN && m.Damua == false && m.TinhTrang == false && m.NgayGiaoDich == date).Sum(m => m.TONGTIEN),
                                ChietKhauNgay = d.ChietKhau * c.SoLuong,
                                TongSoDon = (data.Table_DONHANGs.Where(m => m.ID_NGUOICHOT == a.ID_NHANVIEN && m.Damua == false && m.TinhTrang == false && m.NgayGiaoDich == date).Count()),
                            };
                return model.ToList();


            }
            else
            {
                var model = from a in data.Table_NHANVIENs
                            join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOICHOT
                            join c in data.Table_DONHANG_DMs on b.ID_DONHANG equals c.ID_DONHANG
                            join d in data.Table_SANPHAMs on c.ID_SANPHAM equals d.ID_SANPHAM
                            where b.Damua == false && b.NgayGiaoDich == date && a.ID_LOAINHANVIEN == 3 && b.TinhTrang == false

                            select new NhanVien()
                            {
                                ID_SANPHAM = d.ID_SANPHAM,
                                ID_NHANVIEN = a.ID_NHANVIEN,
                                HoTen = a.HoTen,
                                ChietKhau = d.ChietKhau,
                                TongDoanhThu = data.Table_DONHANGs.Where(m => m.ID_NGUOICHOT == a.ID_NHANVIEN && m.Damua == false && m.TinhTrang == false && m.NgayGiaoDich == date).Sum(m => m.TONGTIEN),
                                ChietKhauNgay = d.ChietKhau * c.SoLuong,
                                TongSoDon = (data.Table_DONHANGs.Where(m => m.ID_NGUOICHOT == a.ID_NHANVIEN && m.Damua == false && m.TinhTrang == false && m.NgayGiaoDich == date).Count()),
                            };
                return model.ToList();
            }
        }

        //success
        public static List<NhanVien> getChietKhau_byMonth(DateTime date, int idnv)
        {
            if (idnv != -1)
            {
                var model = from a in data.Table_NHANVIENs
                            join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOICHOT
                            join c in data.Table_DONHANG_DMs on b.ID_DONHANG equals c.ID_DONHANG
                            join d in data.Table_SANPHAMs on c.ID_SANPHAM equals d.ID_SANPHAM
                            where b.Damua == true && b.NgayGiaoDich.ToString().Contains(date.ToString("yyyy-MM")) && a.ID_NHANVIEN == idnv && b.ID_NGUOIBAN != null

                            select new NhanVien()
                            {
                                ID_SANPHAM = d.ID_SANPHAM,
                                ID_NHANVIEN = a.ID_NHANVIEN,
                                HoTen = a.HoTen,
                                ChietKhau = d.ChietKhau,
                                TongDoanhThu = data.Table_DONHANGs.Where(m => m.ID_NGUOICHOT == a.ID_NHANVIEN && m.Damua == true && m.NgayGiaoDich.ToString().Contains(date.ToString("yyyy-MM"))).Sum(m => m.TONGTIEN),
                                ChietKhauNgay = d.ChietKhau * c.SoLuong,
                                TongSoDon = (data.Table_DONHANGs.Where(m => m.ID_NGUOICHOT == a.ID_NHANVIEN && m.Damua == true && m.NgayGiaoDich.ToString().Contains(date.ToString("yyyy-MM"))).Count()),
                            };
                return model.ToList();


            }
            else
            {
                var model = from a in data.Table_NHANVIENs
                            join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOICHOT
                            join c in data.Table_DONHANG_DMs on b.ID_DONHANG equals c.ID_DONHANG
                            join d in data.Table_SANPHAMs on c.ID_SANPHAM equals d.ID_SANPHAM
                            where b.Damua == true && b.NgayGiaoDich.ToString().Contains(date.ToString("yyyy-MM")) && a.ID_LOAINHANVIEN == 3 && b.ID_NGUOIBAN != null

                            select new NhanVien()
                            {
                                ID_SANPHAM = d.ID_SANPHAM,
                                ID_NHANVIEN = a.ID_NHANVIEN,
                                HoTen = a.HoTen,
                                ChietKhau = d.ChietKhau,
                                TongDoanhThu = data.Table_DONHANGs.Where(m => m.ID_NGUOICHOT == a.ID_NHANVIEN && m.Damua == true && m.NgayGiaoDich.ToString().Contains(date.ToString("yyyy-MM"))).Sum(m => m.TONGTIEN),
                                ChietKhauNgay = d.ChietKhau * c.SoLuong,
                                TongSoDon = (data.Table_DONHANGs.Where(m => m.ID_NGUOICHOT == a.ID_NHANVIEN && m.Damua == true && m.NgayGiaoDich.ToString().Contains(date.ToString("yyyy-MM"))).Count()),
                            };
                return model.ToList();
            }
        }

        //fail
        public static List<NhanVien> getChietKhau_byMonth_Fail(DateTime date, int idnv)
        {
            if (idnv != -1)
            {
                var model = from a in data.Table_NHANVIENs
                            join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOICHOT
                            join c in data.Table_DONHANG_DMs on b.ID_DONHANG equals c.ID_DONHANG
                            join d in data.Table_SANPHAMs on c.ID_SANPHAM equals d.ID_SANPHAM
                            where b.Damua == false && b.NgayGiaoDich.ToString().Contains(date.ToString("yyyy-MM")) && a.ID_NHANVIEN == idnv && b.TinhTrang == false

                            select new NhanVien()
                            {
                                ID_SANPHAM = d.ID_SANPHAM,
                                ID_NHANVIEN = a.ID_NHANVIEN,
                                HoTen = a.HoTen,
                                ChietKhau = d.ChietKhau,
                                TongDoanhThu = data.Table_DONHANGs.Where(m => m.ID_NGUOICHOT == a.ID_NHANVIEN && m.Damua == false && m.TinhTrang == false && m.NgayGiaoDich.ToString().Contains(date.ToString("yyyy-MM"))).Sum(m => m.TONGTIEN),
                                ChietKhauNgay = d.ChietKhau * c.SoLuong,
                                TongSoDon = (data.Table_DONHANGs.Where(m => m.ID_NGUOICHOT == a.ID_NHANVIEN && m.Damua == false && m.TinhTrang == false && m.NgayGiaoDich.ToString().Contains(date.ToString("yyyy-MM"))).Count()),
                            };
                return model.ToList();


            }
            else
            {
                var model = from a in data.Table_NHANVIENs
                            join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOICHOT
                            join c in data.Table_DONHANG_DMs on b.ID_DONHANG equals c.ID_DONHANG
                            join d in data.Table_SANPHAMs on c.ID_SANPHAM equals d.ID_SANPHAM
                            where b.Damua == false && b.NgayGiaoDich.ToString().Contains(date.ToString("yyyy-MM")) && a.ID_LOAINHANVIEN == 3 && b.TinhTrang == false

                            select new NhanVien()
                            {
                                ID_SANPHAM = d.ID_SANPHAM,
                                ID_NHANVIEN = a.ID_NHANVIEN,
                                HoTen = a.HoTen,
                                ChietKhau = d.ChietKhau,
                                TongDoanhThu = data.Table_DONHANGs.Where(m => m.ID_NGUOICHOT == a.ID_NHANVIEN && m.Damua == false && m.TinhTrang == false && m.NgayGiaoDich.ToString().Contains(date.ToString("yyyy-MM"))).Sum(m => m.TONGTIEN),
                                ChietKhauNgay = d.ChietKhau * c.SoLuong,
                                TongSoDon = (data.Table_DONHANGs.Where(m => m.ID_NGUOICHOT == a.ID_NHANVIEN && m.Damua == false && m.TinhTrang == false && m.NgayGiaoDich.ToString().Contains(date.ToString("yyyy-MM"))).Count()),
                            };
                return model.ToList();
            }
        }

        //success
        public static List<NhanVien> getChietKhau_byYear(string date, int idnv)
        {
            if (idnv != -1)
            {
                var model = from a in data.Table_NHANVIENs
                            join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOICHOT
                            join c in data.Table_DONHANG_DMs on b.ID_DONHANG equals c.ID_DONHANG
                            join d in data.Table_SANPHAMs on c.ID_SANPHAM equals d.ID_SANPHAM
                            where b.Damua == true && b.NgayGiaoDich.ToString().Contains(date) && a.ID_NHANVIEN == idnv && b.ID_NGUOIBAN != null

                            select new NhanVien()
                            {
                                ID_SANPHAM = d.ID_SANPHAM,
                                ID_NHANVIEN = a.ID_NHANVIEN,
                                HoTen = a.HoTen,
                                ChietKhau = d.ChietKhau,
                                TongDoanhThu = data.Table_DONHANGs.Where(m => m.ID_NGUOICHOT == a.ID_NHANVIEN && m.Damua == true && m.NgayGiaoDich.ToString().Contains(date)).Sum(m => m.TONGTIEN),
                                ChietKhauNgay = d.ChietKhau * c.SoLuong,
                                TongSoDon = (data.Table_DONHANGs.Where(m => m.ID_NGUOICHOT == a.ID_NHANVIEN && m.Damua == true && m.NgayGiaoDich.ToString().Contains(date)).Count()),
                            };
                return model.ToList();
            }
            else
            {
                var model = from a in data.Table_NHANVIENs
                            join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOICHOT
                            join c in data.Table_DONHANG_DMs on b.ID_DONHANG equals c.ID_DONHANG
                            join d in data.Table_SANPHAMs on c.ID_SANPHAM equals d.ID_SANPHAM
                            where b.Damua == true && b.NgayGiaoDich.ToString().Contains(date) && a.ID_LOAINHANVIEN == 3 && b.ID_NGUOIBAN != null

                            select new NhanVien()
                            {
                                ID_SANPHAM = d.ID_SANPHAM,
                                ID_NHANVIEN = a.ID_NHANVIEN,
                                HoTen = a.HoTen,
                                ChietKhau = d.ChietKhau,
                                TongDoanhThu = data.Table_DONHANGs.Where(m => m.ID_NGUOICHOT == a.ID_NHANVIEN && m.Damua == true && m.NgayGiaoDich.ToString().Contains(date)).Sum(m => m.TONGTIEN),
                                ChietKhauNgay = d.ChietKhau * c.SoLuong,
                                TongSoDon = (data.Table_DONHANGs.Where(m => m.ID_NGUOICHOT == a.ID_NHANVIEN && m.Damua == true && m.NgayGiaoDich.ToString().Contains(date)).Count()),
                            };
                return model.ToList();
            }

        }

        //fail
        public static List<NhanVien> getChietKhau_byYear_Fail(string date, int idnv)
        {
            if (idnv != -1)
            {
                var model = from a in data.Table_NHANVIENs
                            join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOICHOT
                            join c in data.Table_DONHANG_DMs on b.ID_DONHANG equals c.ID_DONHANG
                            join d in data.Table_SANPHAMs on c.ID_SANPHAM equals d.ID_SANPHAM
                            where b.Damua == false && b.NgayGiaoDich.ToString().Contains(date) && a.ID_NHANVIEN == idnv && b.TinhTrang == false

                            select new NhanVien()
                            {
                                ID_SANPHAM = d.ID_SANPHAM,
                                ID_NHANVIEN = a.ID_NHANVIEN,
                                HoTen = a.HoTen,
                                ChietKhau = d.ChietKhau,
                                TongDoanhThu = data.Table_DONHANGs.Where(m => m.ID_NGUOICHOT == a.ID_NHANVIEN && m.Damua == false && m.TinhTrang == false && m.NgayGiaoDich.ToString().Contains(date)).Sum(m => m.TONGTIEN),
                                ChietKhauNgay = d.ChietKhau * c.SoLuong,
                                TongSoDon = (data.Table_DONHANGs.Where(m => m.ID_NGUOICHOT == a.ID_NHANVIEN && m.Damua == false && m.TinhTrang == false && m.NgayGiaoDich.ToString().Contains(date)).Count()),
                            };
                return model.ToList();
            }
            else
            {
                var model = from a in data.Table_NHANVIENs
                            join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOICHOT
                            join c in data.Table_DONHANG_DMs on b.ID_DONHANG equals c.ID_DONHANG
                            join d in data.Table_SANPHAMs on c.ID_SANPHAM equals d.ID_SANPHAM
                            where b.Damua == false && b.NgayGiaoDich.ToString().Contains(date) && a.ID_LOAINHANVIEN == 3 && b.TinhTrang == false

                            select new NhanVien()
                            {
                                ID_SANPHAM = d.ID_SANPHAM,
                                ID_NHANVIEN = a.ID_NHANVIEN,
                                HoTen = a.HoTen,
                                ChietKhau = d.ChietKhau,
                                TongDoanhThu = data.Table_DONHANGs.Where(m => m.ID_NGUOICHOT == a.ID_NHANVIEN && m.Damua == false && m.TinhTrang == false && m.NgayGiaoDich.ToString().Contains(date)).Sum(m => m.TONGTIEN),
                                ChietKhauNgay = d.ChietKhau * c.SoLuong,
                                TongSoDon = (data.Table_DONHANGs.Where(m => m.ID_NGUOICHOT == a.ID_NHANVIEN && m.Damua == false && m.TinhTrang == false && m.NgayGiaoDich.ToString().Contains(date)).Count()),
                            };
                return model.ToList();
            }

        }

        //getChiTietChietKhau
        //success
        public static List<NhanVien> getChiTietChietKhau(string date, int idnv, string form)
        {
            if (form != "no_date")
            {
                var model = from a in data.Table_NHANVIENs
                            join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOICHOT
                            join c in data.Table_DONHANG_DMs on b.ID_DONHANG equals c.ID_DONHANG
                            join d in data.Table_SANPHAMs on c.ID_SANPHAM equals d.ID_SANPHAM
                            join e in data.Table_KHACHHANGs on b.ID_KHACHHANG equals e.ID_KHACHHANG
                            where b.NgayGiaoDich.ToString().Contains(date) && b.Damua == true && b.ID_NGUOICHOT == idnv
                            select new NhanVien()
                            {
                                ID_SANPHAM = d.ID_SANPHAM,
                                HoTen = data.Table_NHANVIENs.Where(m => m.ID_NHANVIEN == b.ID_NGUOIBAN).Select(m => m.HoTen).Single(),
                                TenKH = data.Table_KHACHHANGs.Where(m => m.ID_KHACHHANG == b.ID_KHACHHANG).Select(m => m.HoTen).Single(),
                                TenSanPham = d.TenSanPham,
                                SoLuong = c.SoLuong,
                                DonGia = (double)c.Giatien,
                                TuyChon = c.TuyChon,
                                ChietKhau = d.ChietKhau,
                                TongTien = (double)(c.SoLuong * c.Giatien),
                                ID_NHANVIEN = data.Table_NHANVIENs.Where(m => m.ID_NHANVIEN == b.ID_NGUOIBAN).Select(m => m.ID_NHANVIEN).Single(),
                                ID_DONHANG = b.ID_DONHANG,
                                NgayDatHang = (DateTime)b.NgayGiaoDich,
                                TongDoanhThu = b.TONGTIEN
                            };
                return model.OrderByDescending(m => m.HoTen).ToList();
            }
            else
            {
                var model = from a in data.Table_NHANVIENs
                            join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOICHOT
                            join c in data.Table_DONHANG_DMs on b.ID_DONHANG equals c.ID_DONHANG
                            join d in data.Table_SANPHAMs on c.ID_SANPHAM equals d.ID_SANPHAM
                            join e in data.Table_KHACHHANGs on b.ID_KHACHHANG equals e.ID_KHACHHANG
                            where b.NgayGiaoDich == DateTime.Now && b.Damua == true && b.ID_NGUOICHOT == idnv
                            select new NhanVien()
                            {
                                ID_SANPHAM = d.ID_SANPHAM,
                                HoTen = data.Table_NHANVIENs.Where(m => m.ID_NHANVIEN == b.ID_NGUOIBAN).Select(m => m.HoTen).Single(),
                                TenKH = data.Table_KHACHHANGs.Where(m => m.ID_KHACHHANG == b.ID_KHACHHANG).Select(m => m.HoTen).Single(),
                                TenSanPham = data.Table_SANPHAMs.Where(m => m.ID_SANPHAM == c.ID_SANPHAM).Select(m => m.TenSanPham).Single(),
                                SoLuong = c.SoLuong,
                                TuyChon = c.TuyChon,
                                DonGia = (double)c.Giatien,
                                ChietKhau = d.ChietKhau,
                                TongTien = (double)(c.SoLuong * c.Giatien),
                                ID_NHANVIEN = data.Table_NHANVIENs.Where(m => m.ID_NHANVIEN == b.ID_NGUOIBAN).Select(m => m.ID_NHANVIEN).Single(),
                                ID_DONHANG = b.ID_DONHANG,
                                NgayDatHang = (DateTime)b.NgayGiaoDich,
                                TongDoanhThu = b.TONGTIEN
                            };
                return model.OrderByDescending(m => m.HoTen).ToList();
            }

        }

        //fail
        public static List<NhanVien> getChiTietChietKhau_Fail(string date, int idnv, string form)
        {
            if (form != "no_date")
            {
                var model = from a in data.Table_NHANVIENs
                            join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOICHOT
                            join c in data.Table_DONHANG_DMs on b.ID_DONHANG equals c.ID_DONHANG
                            join d in data.Table_SANPHAMs on c.ID_SANPHAM equals d.ID_SANPHAM
                            join e in data.Table_KHACHHANGs on b.ID_KHACHHANG equals e.ID_KHACHHANG
                            where b.NgayGiaoDich.ToString().Contains(date) && b.Damua == false && b.ID_NGUOICHOT == idnv && b.TinhTrang == false
                            select new NhanVien()
                            {
                                ID_SANPHAM = d.ID_SANPHAM,
                                HoTen = data.Table_NHANVIENs.Where(m => m.ID_NHANVIEN == b.ID_NGUOIBAN).Select(m => m.HoTen).Single(),
                                TenKH = data.Table_KHACHHANGs.Where(m => m.ID_KHACHHANG == b.ID_KHACHHANG).Select(m => m.HoTen).Single(),
                                TenSanPham = d.TenSanPham,
                                SoLuong = c.SoLuong,
                                LyDo = b.GhiChu,
                                DonGia = (double)c.Giatien,
                                TuyChon = c.TuyChon,
                                ChietKhau = d.ChietKhau,
                                TongTien = (double)(c.SoLuong * c.Giatien),
                                ID_NHANVIEN = data.Table_NHANVIENs.Where(m => m.ID_NHANVIEN == b.ID_NGUOIBAN).Select(m => m.ID_NHANVIEN).Single(),
                                ID_DONHANG = b.ID_DONHANG,
                                NgayDatHang = (DateTime)b.NgayGiaoDich,
                                TongDoanhThu = b.TONGTIEN
                            };
                return model.OrderByDescending(m => m.HoTen).ToList();
            }
            else
            {
                var model = from a in data.Table_NHANVIENs
                            join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOICHOT
                            join c in data.Table_DONHANG_DMs on b.ID_DONHANG equals c.ID_DONHANG
                            join d in data.Table_SANPHAMs on c.ID_SANPHAM equals d.ID_SANPHAM
                            join e in data.Table_KHACHHANGs on b.ID_KHACHHANG equals e.ID_KHACHHANG
                            where b.NgayGiaoDich == DateTime.Now && b.Damua == false && b.ID_NGUOICHOT == idnv && b.TinhTrang == false
                            select new NhanVien()
                            {
                                ID_SANPHAM = d.ID_SANPHAM,
                                HoTen = data.Table_NHANVIENs.Where(m => m.ID_NHANVIEN == b.ID_NGUOIBAN).Select(m => m.HoTen).Single(),
                                TenKH = data.Table_KHACHHANGs.Where(m => m.ID_KHACHHANG == b.ID_KHACHHANG).Select(m => m.HoTen).Single(),
                                TenSanPham = data.Table_SANPHAMs.Where(m => m.ID_SANPHAM == c.ID_SANPHAM).Select(m => m.TenSanPham).Single(),
                                SoLuong = c.SoLuong,
                                TuyChon = c.TuyChon,
                                DonGia = (double)c.Giatien,
                                LyDo = b.GhiChu,
                                ChietKhau = d.ChietKhau,
                                TongTien = (double)(c.SoLuong * c.Giatien),
                                ID_NHANVIEN = data.Table_NHANVIENs.Where(m => m.ID_NHANVIEN == b.ID_NGUOIBAN).Select(m => m.ID_NHANVIEN).Single(),
                                ID_DONHANG = b.ID_DONHANG,
                                NgayDatHang = (DateTime)b.NgayGiaoDich,
                                TongDoanhThu = b.TONGTIEN
                            };
                return model.OrderByDescending(m => m.HoTen).ToList();
            }

        }

        public static List<NhanVien> getTongDH_byID()
        {
            var model = from a in data.Table_NHANVIENs
                        join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOIGIAO
                        where b.NgayGiaoHang == DateTime.Now.Date && b.Damua == true
                        select new NhanVien()
                        {
                            ID_NHANVIEN = a.ID_NHANVIEN,
                            HoTen = a.HoTen,
                            TongDH = (data.Table_DONHANGs.Where(m => m.ID_NGUOIGIAO == a.ID_NHANVIEN && m.NgayGiaoHang == DateTime.Now.Date && b.Damua == true).Count()),
                        };
            return model.ToList();
        }
        public static List<NhanVien> getTongDH_bydate(DateTime date)
        {
            var model = from a in data.Table_NHANVIENs
                        join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOIGIAO
                        where b.NgayGiaoHang == date.Date && b.Damua == true
                        select new NhanVien()
                        {
                            ID_NHANVIEN = a.ID_NHANVIEN,
                            HoTen = a.HoTen,
                            TongDH = (data.Table_DONHANGs.Where(m => m.ID_NGUOIGIAO == a.ID_NHANVIEN && m.NgayGiaoHang == date.Date).Count()),
                        };
            return model.GroupBy(m => m.ID_NHANVIEN).Select(m => m.First()).ToList();
        }

        //---------------------------CTV-------------------




        //success
        public static List<NhanVien> getChietKhau_byDate_CTV(DateTime date, int idnv)
        {
            if (idnv != -1)
            {

                var model = from a in data.Table_NHANVIENs
                            join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOIBAN
                            join c in data.Table_DONHANG_DMs on b.ID_DONHANG equals c.ID_DONHANG
                            join d in data.Table_SANPHAMs on c.ID_SANPHAM equals d.ID_SANPHAM
                            where b.Damua == true && b.NgayGiaoDich == date && a.ID_NHANVIEN == idnv && b.ID_NGUOIBAN != null

                            select new NhanVien()
                            {
                                ID_SANPHAM = d.ID_SANPHAM,
                                ID_NHANVIEN = a.ID_NHANVIEN,
                                HoTen = a.HoTen,
                                ChietKhau = d.ChietKhau,
                                TongDoanhThu = data.Table_DONHANGs.Where(m => m.ID_NGUOIBAN == a.ID_NHANVIEN && m.Damua == true && m.NgayGiaoDich == date).Sum(m => m.TONGTIEN),
                                ChietKhauNgay = d.ChietKhau * c.SoLuong,
                                TongSoDon = (data.Table_DONHANGs.Where(m => m.ID_NGUOIBAN == a.ID_NHANVIEN && m.Damua == true && m.NgayGiaoDich == date).Count()),
                            };
                return model.ToList();


            }
            else
            {
                var model = from a in data.Table_NHANVIENs
                            join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOIBAN
                            join c in data.Table_DONHANG_DMs on b.ID_DONHANG equals c.ID_DONHANG
                            join d in data.Table_SANPHAMs on c.ID_SANPHAM equals d.ID_SANPHAM
                            where b.Damua == true && b.NgayGiaoDich == date && a.ID_LOAINHANVIEN != 0 && b.ID_NGUOIBAN != null

                            select new NhanVien()
                            {
                                ID_SANPHAM = d.ID_SANPHAM,
                                ID_NHANVIEN = a.ID_NHANVIEN,
                                HoTen = a.HoTen,
                                ChietKhau = d.ChietKhau,
                                TongDoanhThu = data.Table_DONHANGs.Where(m => m.ID_NGUOIBAN == a.ID_NHANVIEN && m.Damua == true && m.NgayGiaoDich == date).Sum(m => m.TONGTIEN),
                                ChietKhauNgay = d.ChietKhau * c.SoLuong,
                                TongSoDon = (data.Table_DONHANGs.Where(m => m.ID_NGUOIBAN == a.ID_NHANVIEN && m.Damua == true && m.NgayGiaoDich == date).Count()),
                            };
                return model.ToList();
            }
        }
        //fail
        public static List<NhanVien> getChietKhau_byDate_CTV_Fail(DateTime date, int idnv)
        {
            if (idnv != -1)
            {

                var model = from a in data.Table_NHANVIENs
                            join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOIBAN
                            join c in data.Table_DONHANG_DMs on b.ID_DONHANG equals c.ID_DONHANG
                            join d in data.Table_SANPHAMs on c.ID_SANPHAM equals d.ID_SANPHAM
                            where b.Damua == false && b.NgayGiaoDich == date && a.ID_NHANVIEN == idnv && b.TinhTrang == false

                            select new NhanVien()
                            {
                                ID_SANPHAM = d.ID_SANPHAM,
                                ID_NHANVIEN = a.ID_NHANVIEN,
                                HoTen = a.HoTen,
                                ChietKhau = d.ChietKhau,
                                TongDoanhThu = data.Table_DONHANGs.Where(m => m.ID_NGUOIBAN == a.ID_NHANVIEN && m.Damua == false && m.TinhTrang == false && m.NgayGiaoDich == date).Sum(m => m.TONGTIEN),
                                ChietKhauNgay = d.ChietKhau * c.SoLuong,
                                TongSoDon = (data.Table_DONHANGs.Where(m => m.ID_NGUOIBAN == a.ID_NHANVIEN && m.Damua == false && m.TinhTrang == false && m.NgayGiaoDich == date).Count()),
                            };
                return model.ToList();


            }
            else
            {
                var model = from a in data.Table_NHANVIENs
                            join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOIBAN
                            join c in data.Table_DONHANG_DMs on b.ID_DONHANG equals c.ID_DONHANG
                            join d in data.Table_SANPHAMs on c.ID_SANPHAM equals d.ID_SANPHAM
                            where b.Damua == false && b.NgayGiaoDich == date && a.ID_LOAINHANVIEN != 0 && b.TinhTrang == false

                            select new NhanVien()
                            {
                                ID_SANPHAM = d.ID_SANPHAM,
                                ID_NHANVIEN = a.ID_NHANVIEN,
                                HoTen = a.HoTen,
                                ChietKhau = d.ChietKhau,
                                TongDoanhThu = data.Table_DONHANGs.Where(m => m.ID_NGUOIBAN == a.ID_NHANVIEN && m.Damua == false && m.TinhTrang == false && m.NgayGiaoDich == date).Sum(m => m.TONGTIEN),
                                ChietKhauNgay = d.ChietKhau * c.SoLuong,
                                TongSoDon = (data.Table_DONHANGs.Where(m => m.ID_NGUOIBAN == a.ID_NHANVIEN && m.Damua == false && m.TinhTrang == false && m.NgayGiaoDich == date).Count()),
                            };
                return model.ToList();
            }
        }

        //success
        public static List<NhanVien> getChietKhau_byMonth_CTV(DateTime date, int idnv)
        {
            if (idnv != -1)
            {
                var model = from a in data.Table_NHANVIENs
                            join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOIBAN
                            join c in data.Table_DONHANG_DMs on b.ID_DONHANG equals c.ID_DONHANG
                            join d in data.Table_SANPHAMs on c.ID_SANPHAM equals d.ID_SANPHAM
                            where b.Damua == true && b.NgayGiaoDich.ToString().Contains(date.ToString("yyyy-MM")) && a.ID_NHANVIEN == idnv && b.ID_NGUOIBAN != null

                            select new NhanVien()
                            {
                                ID_SANPHAM = d.ID_SANPHAM,
                                ID_NHANVIEN = a.ID_NHANVIEN,
                                HoTen = a.HoTen,
                                ChietKhau = d.ChietKhau,
                                TongDoanhThu = data.Table_DONHANGs.Where(m => m.ID_NGUOIBAN == a.ID_NHANVIEN && m.Damua == true && m.NgayGiaoDich.ToString().Contains(date.ToString("yyyy-MM"))).Sum(m => m.TONGTIEN),
                                ChietKhauNgay = d.ChietKhau * c.SoLuong,
                                TongSoDon = (data.Table_DONHANGs.Where(m => m.ID_NGUOIBAN == a.ID_NHANVIEN && m.Damua == true && m.NgayGiaoDich.ToString().Contains(date.ToString("yyyy-MM"))).Count()),
                            };
                return model.ToList();


            }
            else
            {
                var model = from a in data.Table_NHANVIENs
                            join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOIBAN
                            join c in data.Table_DONHANG_DMs on b.ID_DONHANG equals c.ID_DONHANG
                            join d in data.Table_SANPHAMs on c.ID_SANPHAM equals d.ID_SANPHAM
                            where b.Damua == true && b.NgayGiaoDich.ToString().Contains(date.ToString("yyyy-MM")) && a.ID_LOAINHANVIEN != 0 && b.ID_NGUOIBAN != null

                            select new NhanVien()
                            {
                                ID_SANPHAM = d.ID_SANPHAM,
                                ID_NHANVIEN = a.ID_NHANVIEN,
                                HoTen = a.HoTen,
                                ChietKhau = d.ChietKhau,
                                TongDoanhThu = data.Table_DONHANGs.Where(m => m.ID_NGUOIBAN == a.ID_NHANVIEN && m.Damua == true && m.NgayGiaoDich.ToString().Contains(date.ToString("yyyy-MM"))).Sum(m => m.TONGTIEN),
                                ChietKhauNgay = d.ChietKhau * c.SoLuong,
                                TongSoDon = (data.Table_DONHANGs.Where(m => m.ID_NGUOIBAN == a.ID_NHANVIEN && m.Damua == true && m.NgayGiaoDich.ToString().Contains(date.ToString("yyyy-MM"))).Count()),
                            };
                return model.ToList();
            }
        }

        //fail
        public static List<NhanVien> getChietKhau_byMonth_CTV_Fail(DateTime date, int idnv)
        {
            if (idnv != -1)
            {
                var model = from a in data.Table_NHANVIENs
                            join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOIBAN
                            join c in data.Table_DONHANG_DMs on b.ID_DONHANG equals c.ID_DONHANG
                            join d in data.Table_SANPHAMs on c.ID_SANPHAM equals d.ID_SANPHAM
                            where b.Damua == false && b.NgayGiaoDich.ToString().Contains(date.ToString("yyyy-MM")) && a.ID_NHANVIEN == idnv && b.TinhTrang == false

                            select new NhanVien()
                            {
                                ID_SANPHAM = d.ID_SANPHAM,
                                ID_NHANVIEN = a.ID_NHANVIEN,
                                HoTen = a.HoTen,
                                ChietKhau = d.ChietKhau,
                                TongDoanhThu = data.Table_DONHANGs.Where(m => m.ID_NGUOIBAN == a.ID_NHANVIEN && m.Damua == false && m.TinhTrang == false && m.NgayGiaoDich.ToString().Contains(date.ToString("yyyy-MM"))).Sum(m => m.TONGTIEN),
                                ChietKhauNgay = d.ChietKhau * c.SoLuong,
                                TongSoDon = (data.Table_DONHANGs.Where(m => m.ID_NGUOIBAN == a.ID_NHANVIEN && m.Damua == false && m.TinhTrang == false && m.NgayGiaoDich.ToString().Contains(date.ToString("yyyy-MM"))).Count()),
                            };
                return model.ToList();


            }
            else
            {
                var model = from a in data.Table_NHANVIENs
                            join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOIBAN
                            join c in data.Table_DONHANG_DMs on b.ID_DONHANG equals c.ID_DONHANG
                            join d in data.Table_SANPHAMs on c.ID_SANPHAM equals d.ID_SANPHAM
                            where b.Damua == false && b.NgayGiaoDich.ToString().Contains(date.ToString("yyyy-MM")) && a.ID_LOAINHANVIEN != 0 && b.TinhTrang == false

                            select new NhanVien()
                            {
                                ID_SANPHAM = d.ID_SANPHAM,
                                ID_NHANVIEN = a.ID_NHANVIEN,
                                HoTen = a.HoTen,
                                ChietKhau = d.ChietKhau,
                                TongDoanhThu = data.Table_DONHANGs.Where(m => m.ID_NGUOIBAN == a.ID_NHANVIEN && m.Damua == false && m.TinhTrang == false && m.NgayGiaoDich.ToString().Contains(date.ToString("yyyy-MM"))).Sum(m => m.TONGTIEN),
                                ChietKhauNgay = d.ChietKhau * c.SoLuong,
                                TongSoDon = (data.Table_DONHANGs.Where(m => m.ID_NGUOIBAN == a.ID_NHANVIEN && m.Damua == false && m.TinhTrang == false && m.NgayGiaoDich.ToString().Contains(date.ToString("yyyy-MM"))).Count()),
                            };
                return model.ToList();
            }
        }

        //success
        public static List<NhanVien> getChietKhau_byYear_CTV(string date, int idnv)
        {
            if (idnv != -1)
            {
                var model = from a in data.Table_NHANVIENs
                            join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOIBAN
                            join c in data.Table_DONHANG_DMs on b.ID_DONHANG equals c.ID_DONHANG
                            join d in data.Table_SANPHAMs on c.ID_SANPHAM equals d.ID_SANPHAM
                            where b.Damua == true && b.NgayGiaoDich.ToString().Contains(date) && a.ID_NHANVIEN == idnv && b.ID_NGUOIBAN != null

                            select new NhanVien()
                            {
                                ID_SANPHAM = d.ID_SANPHAM,
                                ID_NHANVIEN = a.ID_NHANVIEN,
                                HoTen = a.HoTen,
                                ChietKhau = d.ChietKhau,
                                TongDoanhThu = data.Table_DONHANGs.Where(m => m.ID_NGUOIBAN == a.ID_NHANVIEN && m.Damua == true && m.NgayGiaoDich.ToString().Contains(date)).Sum(m => m.TONGTIEN),
                                ChietKhauNgay = d.ChietKhau * c.SoLuong,
                                TongSoDon = (data.Table_DONHANGs.Where(m => m.ID_NGUOIBAN == a.ID_NHANVIEN && m.Damua == true && m.NgayGiaoDich.ToString().Contains(date)).Count()),
                            };
                return model.ToList();
            }
            else
            {
                var model = from a in data.Table_NHANVIENs
                            join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOIBAN
                            join c in data.Table_DONHANG_DMs on b.ID_DONHANG equals c.ID_DONHANG
                            join d in data.Table_SANPHAMs on c.ID_SANPHAM equals d.ID_SANPHAM
                            where b.Damua == true && b.NgayGiaoDich.ToString().Contains(date) && a.ID_LOAINHANVIEN != 0 && b.ID_NGUOIBAN != null

                            select new NhanVien()
                            {
                                ID_SANPHAM = d.ID_SANPHAM,
                                ID_NHANVIEN = a.ID_NHANVIEN,
                                HoTen = a.HoTen,
                                ChietKhau = d.ChietKhau,
                                TongDoanhThu = data.Table_DONHANGs.Where(m => m.ID_NGUOIBAN == a.ID_NHANVIEN && m.Damua == true && m.NgayGiaoDich.ToString().Contains(date)).Sum(m => m.TONGTIEN),
                                ChietKhauNgay = d.ChietKhau * c.SoLuong,
                                TongSoDon = (data.Table_DONHANGs.Where(m => m.ID_NGUOIBAN == a.ID_NHANVIEN && m.Damua == true && m.NgayGiaoDich.ToString().Contains(date)).Count()),
                            };
                return model.ToList();
            }

        }

        //fail
        public static List<NhanVien> getChietKhau_byYear_CTV_Fail(string date, int idnv)
        {
            if (idnv != -1)
            {
                var model = from a in data.Table_NHANVIENs
                            join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOIBAN
                            join c in data.Table_DONHANG_DMs on b.ID_DONHANG equals c.ID_DONHANG
                            join d in data.Table_SANPHAMs on c.ID_SANPHAM equals d.ID_SANPHAM
                            where b.Damua == false && b.NgayGiaoDich.ToString().Contains(date) && a.ID_NHANVIEN == idnv && b.TinhTrang == false

                            select new NhanVien()
                            {
                                ID_SANPHAM = d.ID_SANPHAM,
                                ID_NHANVIEN = a.ID_NHANVIEN,
                                HoTen = a.HoTen,
                                ChietKhau = d.ChietKhau,
                                TongDoanhThu = data.Table_DONHANGs.Where(m => m.ID_NGUOIBAN == a.ID_NHANVIEN && m.Damua == false && m.TinhTrang == false && m.NgayGiaoDich.ToString().Contains(date)).Sum(m => m.TONGTIEN),
                                ChietKhauNgay = d.ChietKhau * c.SoLuong,
                                TongSoDon = (data.Table_DONHANGs.Where(m => m.ID_NGUOIBAN == a.ID_NHANVIEN && m.Damua == false && m.TinhTrang == false && m.NgayGiaoDich.ToString().Contains(date)).Count()),
                            };
                return model.ToList();
            }
            else
            {
                var model = from a in data.Table_NHANVIENs
                            join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOIBAN
                            join c in data.Table_DONHANG_DMs on b.ID_DONHANG equals c.ID_DONHANG
                            join d in data.Table_SANPHAMs on c.ID_SANPHAM equals d.ID_SANPHAM
                            where b.Damua == false && b.NgayGiaoDich.ToString().Contains(date) && a.ID_LOAINHANVIEN != 0 && b.TinhTrang == false

                            select new NhanVien()
                            {
                                ID_SANPHAM = d.ID_SANPHAM,
                                ID_NHANVIEN = a.ID_NHANVIEN,
                                HoTen = a.HoTen,
                                ChietKhau = d.ChietKhau,
                                TongDoanhThu = data.Table_DONHANGs.Where(m => m.ID_NGUOIBAN == a.ID_NHANVIEN && m.Damua == false && m.TinhTrang == false && m.NgayGiaoDich.ToString().Contains(date)).Sum(m => m.TONGTIEN),
                                ChietKhauNgay = d.ChietKhau * c.SoLuong,
                                TongSoDon = (data.Table_DONHANGs.Where(m => m.ID_NGUOIBAN == a.ID_NHANVIEN && m.Damua == false && m.TinhTrang == false && m.NgayGiaoDich.ToString().Contains(date)).Count()),
                            };
                return model.ToList();
            }

        }







        //getChiTietChietKhau
        //success
        public static List<NhanVien> getChiTietChietKhau_CTV(string date, int idnv, string form)
        {
            if (form != "no_date")
            {
                var model = from a in data.Table_NHANVIENs
                            join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOIBAN
                            join c in data.Table_DONHANG_DMs on b.ID_DONHANG equals c.ID_DONHANG
                            join d in data.Table_SANPHAMs on c.ID_SANPHAM equals d.ID_SANPHAM
                            join e in data.Table_KHACHHANGs on b.ID_KHACHHANG equals e.ID_KHACHHANG
                            where b.NgayGiaoDich.ToString().Contains(date) && b.Damua == true && b.ID_NGUOIBAN == idnv
                            select new NhanVien()
                            {
                                ID_SANPHAM = d.ID_SANPHAM,
                                HoTen = data.Table_NHANVIENs.Where(m => m.ID_NHANVIEN == b.ID_NGUOICHOT).Select(m => m.HoTen).Single(),
                                TenKH = data.Table_KHACHHANGs.Where(m => m.ID_KHACHHANG == b.ID_KHACHHANG).Select(m => m.HoTen).Single(),
                                TenSanPham = d.TenSanPham,
                                SoLuong = c.SoLuong,
                                DonGia = (double)c.Giatien,
                                TuyChon = c.TuyChon,
                                ChietKhau = d.ChietKhau,
                                TongTien = (double)(c.SoLuong * c.Giatien),
                                ID_NHANVIEN = data.Table_NHANVIENs.Where(m => m.ID_NHANVIEN == b.ID_NGUOICHOT).Select(m => m.ID_NHANVIEN).Single(),
                                ID_DONHANG = b.ID_DONHANG,
                                NgayDatHang = (DateTime)b.NgayGiaoDich,
                                TongDoanhThu = b.TONGTIEN
                            };
                return model.OrderByDescending(m => m.HoTen).ToList();
            }
            else
            {
                var model = from a in data.Table_NHANVIENs
                            join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOIBAN
                            join c in data.Table_DONHANG_DMs on b.ID_DONHANG equals c.ID_DONHANG
                            join d in data.Table_SANPHAMs on c.ID_SANPHAM equals d.ID_SANPHAM
                            join e in data.Table_KHACHHANGs on b.ID_KHACHHANG equals e.ID_KHACHHANG
                            where b.NgayGiaoDich == DateTime.Now && b.Damua == true && b.ID_NGUOIBAN == idnv
                            select new NhanVien()
                            {
                                ID_SANPHAM = d.ID_SANPHAM,
                                HoTen = data.Table_NHANVIENs.Where(m => m.ID_NHANVIEN == b.ID_NGUOICHOT).Select(m => m.HoTen).Single(),
                                TenKH = data.Table_KHACHHANGs.Where(m => m.ID_KHACHHANG == b.ID_KHACHHANG).Select(m => m.HoTen).Single(),
                                TenSanPham = data.Table_SANPHAMs.Where(m => m.ID_SANPHAM == c.ID_SANPHAM).Select(m => m.TenSanPham).Single(),
                                SoLuong = c.SoLuong,
                                TuyChon = c.TuyChon,
                                DonGia = (double)c.Giatien,
                                ChietKhau = d.ChietKhau,
                                TongTien = (double)(c.SoLuong * c.Giatien),
                                ID_NHANVIEN = data.Table_NHANVIENs.Where(m => m.ID_NHANVIEN == b.ID_NGUOICHOT).Select(m => m.ID_NHANVIEN).Single(),
                                ID_DONHANG = b.ID_DONHANG,
                                NgayDatHang = (DateTime)b.NgayGiaoDich,
                                TongDoanhThu = b.TONGTIEN
                            };
                return model.OrderByDescending(m => m.HoTen).ToList();
            }

        }
        //fail
        public static List<NhanVien> getChiTietChietKhau_CTV_Fail(string date, int idnv, string form)
        {
            if (form != "no_date")
            {
                var model = from a in data.Table_NHANVIENs
                            join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOIBAN
                            join c in data.Table_DONHANG_DMs on b.ID_DONHANG equals c.ID_DONHANG
                            join d in data.Table_SANPHAMs on c.ID_SANPHAM equals d.ID_SANPHAM
                            join e in data.Table_KHACHHANGs on b.ID_KHACHHANG equals e.ID_KHACHHANG
                            where b.NgayGiaoDich.ToString().Contains(date) && b.Damua == false && b.ID_NGUOIBAN == idnv && b.TinhTrang == false
                            select new NhanVien()
                            {
                                ID_SANPHAM = d.ID_SANPHAM,
                                HoTen = data.Table_NHANVIENs.Where(m => m.ID_NHANVIEN == b.ID_NGUOICHOT).Select(m => m.HoTen).Single(),
                                TenKH = data.Table_KHACHHANGs.Where(m => m.ID_KHACHHANG == b.ID_KHACHHANG).Select(m => m.HoTen).Single(),
                                TenSanPham = d.TenSanPham,
                                SoLuong = c.SoLuong,
                                DonGia = (double)c.Giatien,
                                TuyChon = c.TuyChon,
                                ChietKhau = d.ChietKhau,
                                TongTien = (double)(c.SoLuong * c.Giatien),
                                ID_NHANVIEN = data.Table_NHANVIENs.Where(m => m.ID_NHANVIEN == b.ID_NGUOICHOT).Select(m => m.ID_NHANVIEN).Single(),
                                ID_DONHANG = b.ID_DONHANG,
                                NgayDatHang = (DateTime)b.NgayGiaoDich,
                                TongDoanhThu = b.TONGTIEN
                            };
                return model.OrderByDescending(m => m.HoTen).ToList();
            }
            else
            {
                var model = from a in data.Table_NHANVIENs
                            join b in data.Table_DONHANGs on a.ID_NHANVIEN equals b.ID_NGUOIBAN
                            join c in data.Table_DONHANG_DMs on b.ID_DONHANG equals c.ID_DONHANG
                            join d in data.Table_SANPHAMs on c.ID_SANPHAM equals d.ID_SANPHAM
                            join e in data.Table_KHACHHANGs on b.ID_KHACHHANG equals e.ID_KHACHHANG
                            where b.NgayGiaoDich == DateTime.Now && b.Damua == false && b.ID_NGUOIBAN == idnv && b.TinhTrang == false
                            select new NhanVien()
                            {
                                ID_SANPHAM = d.ID_SANPHAM,
                                HoTen = data.Table_NHANVIENs.Where(m => m.ID_NHANVIEN == b.ID_NGUOICHOT).Select(m => m.HoTen).Single(),
                                TenKH = data.Table_KHACHHANGs.Where(m => m.ID_KHACHHANG == b.ID_KHACHHANG).Select(m => m.HoTen).Single(),
                                TenSanPham = data.Table_SANPHAMs.Where(m => m.ID_SANPHAM == c.ID_SANPHAM).Select(m => m.TenSanPham).Single(),
                                SoLuong = c.SoLuong,
                                TuyChon = c.TuyChon,
                                DonGia = (double)c.Giatien,
                                ChietKhau = d.ChietKhau,
                                TongTien = (double)(c.SoLuong * c.Giatien),
                                ID_NHANVIEN = data.Table_NHANVIENs.Where(m => m.ID_NHANVIEN == b.ID_NGUOICHOT).Select(m => m.ID_NHANVIEN).Single(),
                                ID_DONHANG = b.ID_DONHANG,
                                NgayDatHang = (DateTime)b.NgayGiaoDich,
                                TongDoanhThu = b.TONGTIEN
                            };
                return model.OrderByDescending(m => m.HoTen).ToList();
            }

        }
    }
}