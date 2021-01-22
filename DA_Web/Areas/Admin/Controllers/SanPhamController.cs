using DA_Web.Areas.Admin.Models;
using DA_Web.EF;
using DA_Web.Models;
using DA_Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using DA_Web.XuLy;
using Newtonsoft.Json;

namespace DA_Web.Areas.Admin.Controllers
{
    public class SanPhamController : BaseController
    {
        //
        // GET: /Admin/SanPham/

        dbQL_BanHangDataContext data = new dbQL_BanHangDataContext();

        public ActionResult Index(int ID_LOAISANPHAM)
        {
            setDDlistLoaiSanPhamCon(ID_LOAISANPHAM);
            ViewBag.ID_LoaiSP = ID_LOAISANPHAM;
            var model = DanhMucCon.full_sanpham_byIDLOAISP_parent(ID_LOAISANPHAM);
            return View(model);

        }

        [HttpPost]
        public JsonResult ChangeSanPham(int ID_LOAISANPHAM)
        {
            var result = DanhMucCon.full_sanpham_byIDLOAISP_child(ID_LOAISANPHAM);
            return Json(new
            {
                status = result
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult EditSP(int id)
        {
            SanPhamDAO sanpham = new SanPhamDAO();
            var getSP = sanpham.getSP_byid(id);
            var model = data.Table_SANPHAMs.First(m => m.ID_SANPHAM == id);
            var danhmuc = data.Table_LOAISANPHAMs.First(m => m.ID_LOAISANPHAM == (int)getSP.Select(n => n.ID_LOAISANPHAM).SingleOrDefault());
            setDDlistLoaiSanPhamCon((int)danhmuc.Root);
            setDDlistNhaSX();

            return View(getSP.Single());
        }

        [HttpPost]
        public ActionResult EditSP(int id, Product_Full sp)
        {

            var model2 = data.Table_SANPHAMs.First(m => m.ID_SANPHAM == id);
            var danhmuc = data.Table_LOAISANPHAMs.First(m => m.ID_LOAISANPHAM == model2.ID_LOAISANPHAM);
            setDDlistLoaiSanPhamCon((int)danhmuc.Root);
            setDDlistNhaSX();

            bool tontaiSp = data.Table_SANPHAMs.Any(m => m.TenSanPham == sp.TenSanPham && m.ID_SANPHAM != id);
            if (sp.DonGia < 1000)
            {
                ModelState.AddModelError("DonGia", "Đơn giá phải từ 1000đ trở lên");
            }
            else if (tontaiSp)
            {
                ModelState.AddModelError("TenSanPham", "Tên sản phẩm này đã tồn tại");
            }
            if (ModelState.IsValid)
            {
                var model = data.Table_SANPHAMs.First(m => m.ID_SANPHAM == id);
                model.TenSanPham = sp.TenSanPham;
                model.ChiTiet = sp.ChiTiet;
                model.DonGia = (double)sp.DonGia;
                model.Ngung = sp.Ngung;
                model.UuTien = sp.UuTien;
                model.ChietKhau = sp.ChietKhau;
                model.MAUSAC = sp.MauSac;
                model.CHATLIEU = sp.CHATLIEU;
                model.SIZE = sp.Size;
                model.ID_LOAISANPHAM = (int)sp.ID_LOAISANPHAM;
                model.ID_NSX = sp.ID_NSX;
                model.HINHANH = sp.HINHANH;
                data.SubmitChanges();
                return RedirectToAction("Index", "SanPham", new { ID_LOAISANPHAM = danhmuc.Root });

            }
            SanPhamDAO sanpham = new SanPhamDAO();
            var getSP = sanpham.getSP_byid(id);

            return View(getSP.Single());
        }

        [HttpGet]
        public ActionResult CreateSP(int ID_LOAISANPHAM)
        {
            setDDlistNhaSX();
            setDDlistLoaiSanPhamCon(ID_LOAISANPHAM);
            return View();
        }

        [HttpPost]
        public ActionResult CreateSP(int ID_LOAISANPHAM, Product_Full sp)
        {
            string id_loaisanpham = Request.QueryString["ID_LOAISANPHAM"];
            setDDlistNhaSX();
            setDDlistLoaiSanPhamCon(int.Parse(id_loaisanpham));
            bool tontaiSp = data.Table_SANPHAMs.Any(m => m.TenSanPham == sp.TenSanPham);
            if (sp.DonGia < 1000)
            {
                ModelState.AddModelError("DonGia", "Đơn giá phải từ 1000đ trở lên");
            }
            else if (tontaiSp)
            {
                ModelState.AddModelError("TenSanPham", "Tên sản phẩm này đã tồn tại");
            }
            if (ModelState.IsValid)
            {
                DA_Web.Models.Table_SANPHAM tb_sp = new DA_Web.Models.Table_SANPHAM();
                tb_sp.TenSanPham = sp.TenSanPham;
                tb_sp.ChiTiet = sp.ChiTiet;
                tb_sp.ID_LOAISANPHAM = (int)sp.ID_LOAISANPHAM;
                tb_sp.Ngung = sp.Ngung;
                tb_sp.UuTien = sp.UuTien;
              
                tb_sp.DonGia = (double)sp.DonGia;
                tb_sp.ChietKhau = sp.ChietKhau;
                tb_sp.ID_NSX = sp.ID_NSX;
                tb_sp.SIZE = sp.Size;
                tb_sp.MAUSAC = sp.MauSac;
                tb_sp.CHATLIEU = sp.CHATLIEU;
                tb_sp.HINHANH = sp.HINHANH;              
                tb_sp.SoLuong = 0;
                tb_sp.VIEWER = 0;
                data.Table_SANPHAMs.InsertOnSubmit(tb_sp);
                data.SubmitChanges();
                var danhmuc = data.Table_LOAISANPHAMs.First(m => m.ID_LOAISANPHAM == ID_LOAISANPHAM);
                return RedirectToAction("Index", "SanPham", new { ID_LOAISANPHAM = danhmuc.Root });
            }

            return View();

        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var model2 = data.Table_SANPHAMs.First(m => m.ID_SANPHAM == id);
            var danhmuc = data.Table_LOAISANPHAMs.First(m => m.ID_LOAISANPHAM == model2.ID_LOAISANPHAM);
            new XuLyDAO().DeleteSanPham(id);
            return RedirectToAction("Index", "SanPham", new { ID_LOAISANPHAM = danhmuc.Root });
        }


        public string ProcessUpload(HttpPostedFileBase file)
        {
            file.SaveAs(Server.MapPath("/Content/image/" + file.FileName));
            return "/Content/image/" + file.FileName;
        }

        //dropdown danh mục con
        public void setDDlistLoaiSanPhamCon(int id, int? selectedId = null)
        {

            ViewBag.LoaiCon = new SelectList(Menu.getMenuChild(id), "ID_LOAISANPHAM", "TenLoaiSanPham", selectedId);

        }

        //dropdown nhà sản xuất
        public void setDDlistNhaSX(int? selectedId = null)
        {

            ViewBag.NhaSX = new SelectList(NhaSXDAO.getNhaSX(), "ID_NSX", "NhaSX", selectedId);
        }

        public ActionResult QuanLyHinhAnh(int ID_SANPHAM)
        {
            var model = DanhMucCon.getImg_byIDSP(ID_SANPHAM);
            return View(model);
        }

        [HttpPost]
        public JsonResult HinhAnhChange(int ID_HINHANH)
        {
            var result = DanhMucCon.getImg_byID(ID_HINHANH).SingleOrDefault();
            return Json(new
            {
                status = result
            }, JsonRequestBehavior.AllowGet);
        }


    }
}