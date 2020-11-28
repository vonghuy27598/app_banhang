using DA_Web.EF;
using DA_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA_Web.Areas.Admin.Models
{
    public class XuLyDAO
    {
       
        QuanLyBanHangDataContext db = null;
        public XuLyDAO()
        {
            db = new QuanLyBanHangDataContext();
        }
        public bool DeleteSanPham(int id)
        {
            try
            {
                var sanpham = db.Table_SANPHAM.Find(id);

                foreach (var item in db.Table_NHAPKHO.Where(m=>m.ID_SANPHAM == id))
                {
                    db.Table_NHAPKHO.Remove(item);
                }
                foreach (var item in db.Table_TUYCHON.Where(m => m.ID_TUYCHON == id))
                {
                    db.Table_TUYCHON.Remove(item);
                }    
                foreach (var item in db.Table_DONHANG_DM.Where(m => m.ID_SANPHAM == id))
                {
                    db.Table_DONHANG_DM.Remove(item);
                }
                db.Table_SANPHAM.Remove(sanpham);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool DeleteLoaiSanPham(int id)
        {
            try
            {
                var loaisanpham = db.Table_LOAISANPHAM.Find(id);
                db.Table_LOAISANPHAM.Remove(loaisanpham);
                db.SaveChanges();
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteNhanVien(int id)
        {
            try
            {
                var nhanvien = db.Table_NHANVIEN.Find(id);
                db.Table_NHANVIEN.Remove(nhanvien);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool DeleteChucVu(int id_loainv)
        {
            try
            {
                var chucvu = db.Table_LOAINHANVIEN.Find(id_loainv);
                db.Table_LOAINHANVIEN.Remove(chucvu);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool DeleteNSX(int id_nsx)
        {
            try
            {
                var nsx = db.Table_NhaSX.Find(id_nsx);
                db.Table_NhaSX.Remove(nsx);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteLichSuNhap(int id_NHAPKHO)
        {
            try
            {
                var lichsu = db.Table_NHAPKHO.Find(id_NHAPKHO);
                db.Table_NHAPKHO.Remove(lichsu);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteTC(int id_TUYCHON)
        {
            try
            {
                var tuychon = db.Table_TUYCHON.Find(id_TUYCHON);
                db.Table_TUYCHON.Remove(tuychon);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}