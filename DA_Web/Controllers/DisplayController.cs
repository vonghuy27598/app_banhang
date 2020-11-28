using DA_Web.Models;
using DA_Web.XuLy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using DA_Web.ViewModel;
using DA_Web.Areas.Admin.Controllers;

namespace DA_Web.Controllers
{
    public class DisplayController : AKMLController
    {
        //
        dbQL_BanHangDataContext db = new dbQL_BanHangDataContext();
        // GET: /Display/
        public ActionResult TrangChu()
        {
            //get Cookie          
            HttpCookie User = Request.Cookies["user"];
            HttpCookie Width = Request.Cookies["width"];
            if (User != null && Width != null)
            {
                var getNV = db.Table_NHANVIENs.SingleOrDefault(m => m.ID_NHANVIEN == int.Parse(User.Value));
                Session["User1"] = getNV;
                Session["width"] = int.Parse(Width.Value);
            }
            var model = SanPham.Product_Full().Distinct();
            ViewData["spTruyCap"] = from a in db.Table_SANPHAMs select a;
            ViewData["spBanChay"] = SanPham.getSanPhamBanChay();
            ViewData["spHot"] = from a in db.Table_SANPHAMs select a;
            return View(model);

        }


        public ActionResult ChiTietSanPham(int id)
        {

            var model = SanPham.Product_Full_byID(id);
            var sp = db.Table_SANPHAMs.First(m => m.ID_SANPHAM == id);
            sp.VIEWER += 1;

            UpdateModel(sp);
            db.SubmitChanges();
            ViewData["mutiple-img"] = from a in db.Table_MUCHINHANHs where a.ID_SANPHAM == id select a;
            ViewBag.tongHinh = (from a in db.Table_MUCHINHANHs where a.ID_SANPHAM == id select a).Count() + 1;
            //ViewData["getSP_lienquan"] = from a in db.Table_SANPHAMs where a.ID_LOAISANPHAM == sp.ID_LOAISANPHAM  && a.Ngung ==false select a;
            ViewData["getSP_lienquan"] = SanPham.getSanPhamLienQuan(sp.ID_LOAISANPHAM, id);
            var tuychon = from a in db.Table_TUYCHONs where a.ID_SANPHAM == id select a;
            ViewData["tuychon"] = tuychon;
            var countTong = 0;
            foreach (var item in tuychon)
            {
                countTong += (int)item.SoLuong;
            }
            ViewBag.SoLuong = countTong;
            return View(model.Single());
        }

        public JsonResult ListName(string a)
        {
            var data = new XuLy.SanPham().ListName(a);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TimKiem(string keyword)
        {


            ViewBag.keyword = keyword;
            var model = SanPham.Search(keyword);
            ViewBag.soluongtimthay = model.Count();
            return View(model.ToList());
        }

        //-------PartialView-----//

        public PartialViewResult Header()
        {

            var model = Menu.getMenuParent();
            return PartialView(model);
        }

        public PartialViewResult Header_me()
        {
            return PartialView();
        }

        public PartialViewResult MenuChild(int root)
        {

            var model = Menu.getMenuChild(root);
            ViewBag.Count = model.Count();
            return PartialView("MenuChild", model);
        }

        public PartialViewResult MenuChildMobile(int root)
        {

            var model = Menu.getMenuChild(root);
            ViewBag.Count = model.Count();
            return PartialView("MenuChildMobile", model);
        }

        public ActionResult BanChay()
        {
            var model = from a in db.Table_SANPHAMs select a;
            return PartialView(model);
        }

        public ActionResult pdLienQuan()
        {
            var model = from a in db.Table_SANPHAMs select a;
            return PartialView(model);
        }

        public ActionResult Me()
        {
            var model = (Table_NHANVIEN)Session["User1"];

            return View(model);
        }

        public ActionResult SettingMe()
        {
            var model = (Table_NHANVIEN)Session["User1"];

            return View(model);
        }

        [HttpPost]
        public ActionResult ChangeImage(FormCollection form)
        {
            var img = form["picture2"];
            var model = (Table_NHANVIEN)Session["User1"];
            var nv = db.Table_NHANVIENs.First(m => m.ID_NHANVIEN == model.ID_NHANVIEN);
            if (img.Length == 0)
            {
                nv.ANHDAIDIEN = null;

            }
            else
            {
                nv.ANHDAIDIEN = img;
            }

            db.SubmitChanges();
            Session["User1"] = nv;

            return RedirectToAction("Me", "Display");
        }

        public string ProcessUpload(HttpPostedFileBase file)
        {
            file.SaveAs(Server.MapPath("/Content/image/" + file.FileName));
            return "/Content/image/" + file.FileName;
        }
    }
}