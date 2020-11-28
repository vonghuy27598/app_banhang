using DA_Web.Models;
using DA_Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA_Web.XuLy
{
    public class Menu
    {
        //public static dbQL_BanHangDataContext db = new dbQL_BanHangDataContext();
        public static List<MenuView> getMenuParent()
        {
            dbQL_BanHangDataContext db = new dbQL_BanHangDataContext();
            var model = from a in db.Table_LOAISANPHAMs
                        select new MenuView()
                        {
                           ID_LOAISANPHAM = a.ID_LOAISANPHAM,
                           TENLOAISANPHAM = a.TenLoaiSanPham,
                           ROOT = a.Root
                        };
            return model.Where(m=>m.ROOT==0).ToList();
        }
        public static List<MenuView> getMenuChild(int root)
        {
            dbQL_BanHangDataContext db = new dbQL_BanHangDataContext();
            var model = from a in db.Table_LOAISANPHAMs
                        select new MenuView()
                        {
                            ID_LOAISANPHAM = a.ID_LOAISANPHAM,
                            TENLOAISANPHAM = a.TenLoaiSanPham,
                            ROOT = a.Root
                        };
            return model.Where(m => m.ROOT == root).ToList();
        }   
    }
}