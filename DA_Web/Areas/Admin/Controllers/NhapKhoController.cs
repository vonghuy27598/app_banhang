using DA_Web.Areas.Admin.Models;
using DA_Web.Models;
using DA_Web.ViewModel;
using DA_Web.XuLy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DA_Web.Areas.Admin.Controllers
{
    public class NhapKhoController : BaseController
    {
        //
        // GET: /Admin/NhapKho/
        dbQL_BanHangDataContext data = new dbQL_BanHangDataContext();
        public ActionResult QuanLyTuyChon(int id)
        {
            var model = DanhMucCon.getTuyChon_byIDSP(id);
            ViewBag.ID_SANPHAM = id;
            return View(model);
        }
        public ActionResult NhapKho(int id)
        {
            var getSP = SanPham.Product_Full_byID(id);
            return View(getSP.Single());
        }

        [HttpPost]
        public ActionResult NhapKho(int id, Product_Full pdl)
        {
            var tb_sp = data.Table_SANPHAMs.First(m => m.ID_SANPHAM == id);

            if (pdl.SoLuong <= 0)
            {
                ViewData["SoLuong"] = "Số lượng nhập vào phải từ 1 trở lên";
            }
            else
            {
                if (pdl.DonGia <= 1000)
                {
                    ViewData["DonGia"] = "Đơn giá phải lớn hơn 1000 VNĐ";
                }
                else
                {
                    //ViewData["LoiTT"] = "Đã có tùy chọn tương tự trong kho";
                    DateTime date = DateTime.Now;
                    var d = date.Date;
                    var model = (Table_NHANVIEN)Session["TaiKhoanAdmin"];
                    Table_TUYCHON tb_tc = new Table_TUYCHON();
                    Table_NHAPKHO tb_nhapkho = new Table_NHAPKHO();
                    tb_nhapkho.ID_NHANVIEN = model.ID_NHANVIEN;
                    tb_nhapkho.ID_SANPHAM = id;
                    tb_nhapkho.NgayNhap = d;
                    tb_nhapkho.SoLuong = pdl.SoLuong;
                    tb_tc.ID_SANPHAM = id;
                    tb_tc.TuyChon = pdl.TuyChon;
                    tb_tc.SoLuong = pdl.SoLuong;
                    tb_tc.DonGia = pdl.DonGia;
                    data.Table_TUYCHONs.InsertOnSubmit(tb_tc);
                    data.Table_NHAPKHOs.InsertOnSubmit(tb_nhapkho);
                    data.SubmitChanges();
                    var danhmuc = data.Table_LOAISANPHAMs.First(m => m.ID_LOAISANPHAM == tb_sp.ID_LOAISANPHAM);
                    return RedirectToAction("Index", "SanPham", new { ID_LOAISANPHAM = danhmuc.Root });
                }
            }
            return View();
        }

        public ActionResult LichSuNhapKho()
        {
            var getNhapKho = NhapKhoDAO.getLichSuNhap();
            return View(getNhapKho);
        }

        public ActionResult EditTC(int id)
        {
            var getSP = DanhMucCon.getTuyChon_byIDTC(id);
            return View(getSP.Single());
        }

        [HttpPost]
        public ActionResult EditTC(int id, Product_Full pdl)
        {
            var model = data.Table_TUYCHONs.First(m => m.ID_TUYCHON == id);
            //var danhmuc = data.Table_SANPHAMs.First(m => m.ID_SANPHAM == model.ID_SANPHAM);

            if (pdl.SoLuong <= 0)
            {
                ViewData["SoLuong"] = "Số lượng nhập vào phải từ 1 trở lên";
            }
            else
            {
                if (pdl.DonGia <= 1000)
                {
                    ViewData["DonGia"] = "Đơn giá phải lớn hơn 1000 VNĐ";
                }
                else
                {
                    //ViewData["LoiTT"] = "Đã có tùy chọn tương tự trong kho";
                    var tb_tc = data.Table_TUYCHONs.First(m => m.ID_TUYCHON == id);
                    tb_tc.TuyChon = pdl.TuyChon;
                    tb_tc.SoLuong = pdl.SoLuong;
                    tb_tc.DonGia = pdl.DonGia;
                    tb_tc.ID_SANPHAM = (int)pdl.ID_SANPHAM;
                    data.SubmitChanges();
                    return RedirectToAction("QuanLyTuyChon", "NhapKho", new { id = tb_tc.ID_SANPHAM });
                }
            }
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new XuLyDAO().DeleteLichSuNhap(id);
            return RedirectToAction("Index", "SanPham");
        }

        [HttpDelete]
        public ActionResult DeleteTC(int id)
        {
            new XuLyDAO().DeleteTC(id);
            return RedirectToAction("Index", "SanPham");
        }
    }
}