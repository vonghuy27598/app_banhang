using DA_Web.Models;
using DA_Web.XuLy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DA_Web.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Admin/Home/
        dbQL_BanHangDataContext db = new dbQL_BanHangDataContext();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult HeaderAdmin()
        {
            var model = Menu.getMenuParent();
            return PartialView(model);
        }

        public PartialViewResult ttQuanTri()
        {
            var model = (Table_NHANVIEN)Session["TaiKhoanAdmin"];
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult ChangeImage(FormCollection form)
        {
            var img = form["picture2"];
            var model = (Table_NHANVIEN)Session["TaiKhoanAdmin"];
            var nv = db.Table_NHANVIENs.First(m => m.ID_NHANVIEN == model.ID_NHANVIEN);
            if (img.Length==0)
            {
                nv.ANHDAIDIEN = null;
             
            }
            else
            {
                nv.ANHDAIDIEN = img;
            }
           
           
            db.SubmitChanges();
            Session["TaiKhoanAdmin"] = nv;

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ChangeInfo(FormCollection form)
        {
            var hoten = form["hoten"];
            var sdt = form["sdt"];
            string gioitinh = form["gioitinh"];
            var nganhang = form["tkbank"];
            var diachi = form["diachi"];
            var email = form["email"];
            var model = (Table_NHANVIEN)Session["TaiKhoanAdmin"];
            var nv = db.Table_NHANVIENs.First(m => m.ID_NHANVIEN == model.ID_NHANVIEN);
            nv.HoTen = hoten;
            nv.SDT = sdt;
            nv.TKBank = nganhang;
            nv.Diachi = diachi;
            nv.Email = email;
            nv.Skype = model.Skype;
            nv.ANHDAIDIEN = model.ANHDAIDIEN;
            bool gt = false;
            if (gioitinh == "True")
            {
                gt = true;
            }
            nv.GioiTinh = gt;
            db.SubmitChanges();
            Session["TaiKhoanAdmin"] = nv;

            return RedirectToAction("Index");
        }

        public string ProcessUpload(HttpPostedFileBase file)
        {
            file.SaveAs(Server.MapPath("/Content/image/" + file.FileName));
            return "/Content/image/" + file.FileName;
        }
        [HttpPost]
        public JsonResult ChangeImage_MUCHINH(int id_ha, string src_img)
        {

            var img = db.Table_MUCHINHANHs.First(m => m.ID_HINHANH == id_ha);
            img.HINHANH_N = src_img;
            db.SubmitChanges();
            var result = db.Table_MUCHINHANHs.Where(m => m.ID_HINHANH == id_ha);

            return Json(new
            {
                status = result

            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CreateImg(int id_sp,string src_img)
        {
           
            Table_MUCHINHANH tb_img = new Table_MUCHINHANH();
            tb_img.ID_SANPHAM = id_sp;
            tb_img.HINHANH_N = src_img;
            db.Table_MUCHINHANHs.InsertOnSubmit(tb_img);
            db.SubmitChanges();
           

            return Json(new
            {
               

            }, JsonRequestBehavior.AllowGet);
        }

         [HttpPost]
        public JsonResult Delete_MUCHINH(int id_ha)
        {

            var model = db.Table_MUCHINHANHs.First(m => m.ID_HINHANH == id_ha);
            db.Table_MUCHINHANHs.DeleteOnSubmit(model);
            db.SubmitChanges();          
            return Json(new
            {
               

            }, JsonRequestBehavior.AllowGet);
        }

         [HttpPost]
         public ActionResult DoiMK(FormCollection collection)
         {
             Table_NHANVIEN nv = (Table_NHANVIEN)Session["User1"];
             var mess = "";
             var matkhaucu = collection["MatKhauCu"];
             var matkhau = collection["MatKhau"];
             var nlmatkhau = collection["NhapLaiMatKhau"];
             var upMK = db.Table_NHANVIENs.First(m => m.ID_NHANVIEN == nv.ID_NHANVIEN);
             if (Str_Encoder(matkhaucu) == nv.Password)
             {
                 if (matkhau == nlmatkhau)
                 {
                     upMK.Password = Str_Encoder(matkhau);
                     UpdateModel(upMK);
                     db.SubmitChanges();
                     Response.Write("<script>alert('Đổi mật khẩu thành công')</script>");
                     return RedirectToAction("Index");
                 }
                 else
                 {
                     ViewData["LoiMK"] = "Xác Nhận Mật Khẩu KHÔNG Trùng Khớp";
                 }
             }
             else
             {
                 ViewData["LoiMK1"] = "Mật khẩu cũ không đúng";
             }
             mess = "Đổi mật khẩu không thành công";
             ViewBag.Mesage = mess;
             return RedirectToAction("Index");
         }

         public string Str_Encoder(string str)
         {
             UnicodeEncoding encoding = new UnicodeEncoding();
             Byte[] hashBytes = encoding.GetBytes(str);
             // Compute the SHA-1 hash
             SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
             Byte[] crypt_str = sha1.ComputeHash(hashBytes);
             return BitConverter.ToString(crypt_str);
         }
    }
}