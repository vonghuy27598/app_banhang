using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA_Web.Models
{
    public class GioHang
    {
        dbQL_BanHangDataContext db = new dbQL_BanHangDataContext();
        public int sID_SANPHAM { get; set; }
        public string sTenSanPham { get; set; }
        public Double sDonGia { get; set; }
        public string sHinhAnh { get; set; }
        public int sSoLuong { get; set; }
        public string sTenLoaiSanPham { get; set; }
        public int sID_LOAI { get; set; }
        public Double sThanhTien { get { return sSoLuong * sDonGia; } }
        public bool sDamua { get; set; }
        public string GHICHU { get; set; }
        public int TongSoLuong { get; set; }
        public double ThanhTienUD{ get; set; }
        public double TongTienUD{ get; set; }
        public int sID_TUYCHON { get; set; }
        public string TuyChon { get; set; }
        public int SoLuongUD { get; set; }
        public GioHang(int ID_SANPHAM,int ID_TUYCHON, int SoLuong, double DonGia)
        {
            sID_SANPHAM = ID_SANPHAM;
            sID_TUYCHON = ID_TUYCHON;
            Table_SANPHAM sp = db.Table_SANPHAMs.Single(m => m.ID_SANPHAM == sID_SANPHAM);
            Table_TUYCHON tc = db.Table_TUYCHONs.Single(m => m.ID_TUYCHON == sID_TUYCHON);
            Table_LOAISANPHAM lq = db.Table_LOAISANPHAMs.Single(m => m.ID_LOAISANPHAM == sp.ID_LOAISANPHAM);
            sTenSanPham = sp.TenSanPham;
            TuyChon = tc.TuyChon;
            sTenLoaiSanPham = lq.TenLoaiSanPham;
            sDonGia = (double)DonGia;
            sHinhAnh = sp.HINHANH;
            sSoLuong = SoLuong;
            ThanhTienUD = sSoLuong * sDonGia;
            TongTienUD = this.TongTienUD;
            GHICHU = this.GHICHU;
        }
    }
}