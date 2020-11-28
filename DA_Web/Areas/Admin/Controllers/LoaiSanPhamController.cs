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
    public class LoaiSanPhamController : BaseController
    {
        //
        // GET: /Admin/LoaiSanPham/
      
        dbQL_BanHangDataContext data = new dbQL_BanHangDataContext();
        public ActionResult Index()
        {
            setDDlistLoaiSanPhamCha();
            var model = DanhMucCon.getLoai_byRoot(1);
            return View(model);
        }

        public ActionResult Index_Goc()
        {
            var model = DanhMucCon.getLoaiGoc();
            return View(model);
        }

        //Thêm danh mục cha
        [HttpPost]
        public ActionResult CreateLoaiSP_goc(FormCollection form)
        {
            setDDlistLoaiSanPhamCha();
            var tendmcha = form["TenLoaiSanPhamCha"];
            bool tontaiDanhmucCha = data.Table_LOAISANPHAMs.Any(m => m.TenLoaiSanPham == tendmcha);
            if (tontaiDanhmucCha)
            {
                ModelState.AddModelError("TenLoaiSanPhamCha", "Danh mục này đã tồn tại");
              
            }
            else if (String.IsNullOrEmpty(tendmcha))
            {
                ModelState.AddModelError("TenLoaiSanPhamCha", "Tên danh mục không được rỗng");
                
            }
           
            if(ModelState.IsValid)
            {
                DA_Web.Models.Table_LOAISANPHAM tb_loaisp = new Table_LOAISANPHAM();
                tb_loaisp.TenLoaiSanPham = tendmcha;                
                tb_loaisp.Root = 0;
                data.Table_LOAISANPHAMs.InsertOnSubmit(tb_loaisp);
                data.SubmitChanges();

                return RedirectToAction("Index", "LoaiSanPham");

            }



            return View("CreateLoaiSP");

        }

        [HttpPost]
        public JsonResult ChangeLoaiSanPham(int ID_LOAISANPHAM)
        {
            var result = DanhMucCon.getLoai_byRoot(ID_LOAISANPHAM);
            return Json(new
            {
                status = result
            }, JsonRequestBehavior.AllowGet);
        }

        //dropdown danh mục con
        public void setDDlistLoaiSanPhamCha(int? selectedId = null)
        {
            ViewBag.LoaiCha = new SelectList(Menu.getMenuParent(), "ID_LOAISANPHAM", "TenLoaiSanPham", selectedId);
        }

        public ActionResult CreateLoaiSP()
        {
            setDDlistLoaiSanPhamCha();
            return View();
        }

        //Thêm danh mục con
        [HttpPost]
        public ActionResult CreateLoaiSP(LoaiSanPham loai)
        {
            setDDlistLoaiSanPhamCha();
            bool tontaiDanhmucCon = data.Table_LOAISANPHAMs.Any(m => m.TenLoaiSanPham == loai.TenLoaiSanPham);
            if (tontaiDanhmucCon)
            {
                ModelState.AddModelError("TenLoaiSanPham", "Danh mục này đã tồn tại");
            }
           
            if (ModelState.IsValid)
            {
                DA_Web.Models.Table_LOAISANPHAM tb_loaisp = new Table_LOAISANPHAM();
                tb_loaisp.TenLoaiSanPham = loai.TenLoaiSanPham;
                tb_loaisp.Root =(int) loai.Root;
                tb_loaisp.TenThuMuc = loai.TenThuMuc;               
                data.Table_LOAISANPHAMs.InsertOnSubmit(tb_loaisp);
                data.SubmitChanges();

                return RedirectToAction("Index", "LoaiSanPham");

            }
            return View(loai);

        }

        //Sửa
        [HttpGet]
        public ActionResult EditLoaiSP(int id)
        {
            
            var model = data.Table_LOAISANPHAMs.First(m => m.ID_LOAISANPHAM == id);
            setDDlistLoaiSanPhamCha(model.Root);
            return View(model);

        }

        [HttpPost]
        public ActionResult EditLoaiSP(int id,Table_LOAISANPHAM loai)
        {
            var getRoot = data.Table_LOAISANPHAMs.First(m => m.ID_LOAISANPHAM == id);
            setDDlistLoaiSanPhamCha(getRoot.Root);
            
            if (String.IsNullOrEmpty(loai.TenLoaiSanPham))
            {
                ViewBag.Loi1 = "*";
                ViewBag.MessError = "Vui lòng nhập tên danh mục";
            }                      
            else
            {
                bool tontaiten = data.Table_LOAISANPHAMs.Any(m => loai.TenLoaiSanPham == m.TenLoaiSanPham);
                if (tontaiten)
                {
                    ViewBag.Loi2 = "*";
                    ViewBag.MessError = "Danh mục này đã tồn tại";
                }
                else
                {
                    var model = data.Table_LOAISANPHAMs.First(m => m.ID_LOAISANPHAM == id);
                    model.TenLoaiSanPham = loai.TenLoaiSanPham;
                    model.Root = loai.Root;
                    data.SubmitChanges();
                    return RedirectToAction("Index", "LoaiSanPham");
                }
            }
            return View();
        }


        [HttpGet]
        public ActionResult EditLoaiSP_Goc(int id)
        {

            var model = data.Table_LOAISANPHAMs.First(m => m.ID_LOAISANPHAM == id);
            setDDlistLoaiSanPhamCha(model.Root);
            return View(model);

        }

        [HttpPost]
        public ActionResult EditLoaiSP_Goc(int id,Table_LOAISANPHAM loai)
        {
            if (String.IsNullOrEmpty(loai.TenLoaiSanPham))
            {
                ViewBag.Loi1 = "*";
                ViewBag.MessError = "Vui lòng nhập tên danh mục";
            }
            else
            {
                bool tontaiten = data.Table_LOAISANPHAMs.Any(m => loai.TenLoaiSanPham == m.TenLoaiSanPham);
                if (tontaiten)
                {
                    ViewBag.Loi3 = "*";
                    ViewBag.MessError = "Danh mục này đã tồn tại";
                }
                else
                {
                    var model = data.Table_LOAISANPHAMs.First(m => m.ID_LOAISANPHAM == id);
                    model.TenLoaiSanPham = loai.TenLoaiSanPham;

                    data.SubmitChanges();
                    return RedirectToAction("Index_Goc", "LoaiSanPham");
                }
            }
            return View();
        }


        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new XuLyDAO().DeleteLoaiSanPham(id);      
            return View("Index");
            
        }

        public string ProcessUpload(HttpPostedFileBase file)
        {
            file.SaveAs(Server.MapPath("~/Content/image/" + file.FileName));
            return file.FileName;
        }
      
    }
}