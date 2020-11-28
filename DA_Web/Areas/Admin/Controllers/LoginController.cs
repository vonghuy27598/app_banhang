using DA_Web.Models;
using DA_Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DA_Web.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Admin/Login/
       
        dbQL_BanHangDataContext data = new dbQL_BanHangDataContext();
        
        public ActionResult Index()
        {
              
            return View();
        }

        public ActionResult Url(string url)
        {

            if (url.Equals("CDCAMT"))
            {
                Session["Check"] = "ok";
                return RedirectToAction("TrangChu", "Display", new { Area = "" });
            }
            return View("Index");
        }
       
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(FormCollection formcollect)
        {
            var tendn = formcollect["username"];
            var mk = formcollect["password"];
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "*";
            }
            else if (String.IsNullOrEmpty(mk))
            {
                ViewData["Loi2"] = "*";
            }
            else
            {
                Table_NHANVIEN ad = data.Table_NHANVIENs.SingleOrDefault(m => m.Username == tendn && m.Password == Str_Encoder(mk));
                if (ad != null)
                {
                    if (ad.ID_LOAINHANVIEN != 0)
                    {
                        ViewBag.ThongBao = "Chỉ có tài khoản quản lý mới có thể đăng nhập hệ thống này !";
                    }
                    else
                    {
                        Session["TaiKhoanAdmin"] = ad;
                       
                        return RedirectToAction("Index", "Home");
                    }
                   
                }
                else
                {
                    ViewBag.ThongBao = "Sai tên đăng nhập hoặc mật khẩu !";
                }

            }
            return View();
        }

        //Đăng ký tài khoản quản trị viên
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(FormCollection form)
        {
            bool status = false;
            string mess= "";
            var hoten = form["hoten"];
            var sdt = form["sdt"];
            string gioitinh = form["rdGioiTinh"];
            var nganhang = form["nganhang"];
            var diachi = form["diachi"];
            var email = form["email"];
            var skype = form["skype"];
            var username = form["username"];
            var password = form["password"];
            var confirmpass = form["confirm_password"];

            if (ModelState.IsValid)
            {
                bool gt =false;
                if(gioitinh =="True"){
                    gt=true;
                }
                bool tontaitk = data.Table_NHANVIENs.Any(m => username == m.Username);
                if(tontaitk)
                {
                    ViewData["LoiUS"] = "Tài khoản đã được sử dụng";
                }
                Table_NHANVIEN nv = new Table_NHANVIEN();
                nv.HoTen = hoten;
                nv.SDT=sdt;
                nv.GioiTinh=gt;
                nv.TKBank = nganhang;
                nv.Diachi=diachi;
                nv.Email=email;
                nv.Skype=skype;
                nv.Username=username;
                nv.Password= Str_Encoder(password);
                nv.ID_LOAINHANVIEN = 0;
                data.Table_NHANVIENs.InsertOnSubmit(nv);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();

            }
            
        }
        [HttpPost]
        public JsonResult DoiMK_ql(string pass,string passmoi)
        {
            Table_NHANVIEN admin = (Table_NHANVIEN)Session["TaiKhoanAdmin"];
            var changePass = data.Table_NHANVIENs.First(m => m.ID_NHANVIEN == admin.ID_NHANVIEN);        
            bool status = false;
            if (changePass.Password == Str_Encoder(pass))
            {
                changePass.Password = Str_Encoder(passmoi);
                UpdateModel(changePass);
                data.SubmitChanges();
                status = true;
            }                                
                return Json(new
                {
                    status = status             
                }, JsonRequestBehavior.AllowGet);
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