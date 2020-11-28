using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DA_Web.Models;
using System.Globalization;
using System.Text;
using System.Security.Cryptography;
using DA_Web.XuLy;
using DA_Web.Areas.Admin.Models;
using DA_Web.Areas.Admin.Controllers;
using System.Net.Mail;
using System.Web.Services.Description;
using System.Net;
using DA_Web.ViewModel;

namespace DA_Web.Controllers
{
    public class NhanVienController : Controller
    {
        //
        // GET: /NhanVien/
        dbQL_BanHangDataContext db = new dbQL_BanHangDataContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var tendn = collection["TenDN"];
            string tdn = tendn;
            var matkhau = collection["MatKhau"];
            var width = collection["BrowserWidth"];
            Session["width"] = int.Parse(width);
            if (String.IsNullOrEmpty(tendn))
            {

                ViewBag.Mess = string.Format("Tên đăng nhập không được rỗng");

            }
            else if (String.IsNullOrEmpty(matkhau))
            {

                ViewBag.Mess = "Mật khẩu không được rỗng";

            }
            else
            {
                DA_Web.Models.Table_NHANVIEN nv = db.Table_NHANVIENs.SingleOrDefault(m => m.Username == tendn && m.Password == Str_Encoder(matkhau));
                if (nv != null)
                {

                    ViewBag.Mess = "Đăng nhập thành công";
                    Session["User1"] = nv;

                    //Tạo cookie
                    HttpCookie UserCookie = new HttpCookie("user", (nv.ID_NHANVIEN).ToString());
                    UserCookie.HttpOnly = true;
                    HttpCookie WidthCookie = new HttpCookie("width", width);
                    WidthCookie.HttpOnly = true;
                    //Đặt thời hạn cho cookie                   
                    UserCookie.Expires = DateTime.Now.AddDays(365);
                    WidthCookie.Expires = DateTime.Now.AddDays(365);
                    //Lưu thông tin vào cookie                 
                    HttpContext.Response.SetCookie(UserCookie);
                    HttpContext.Response.SetCookie(WidthCookie);

                    if (int.Parse(width) < 800)
                    {
                        return RedirectToAction("Me", "NhanVien");
                    }
                    else if (int.Parse(width) >= 800)
                    {
                        return RedirectToAction("TrangChu", "Display");
                    }
                }
                else
                {
                    ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
                }
            }
            return View();
        }

        public ActionResult Me()
        {
            Session["Check"] = "ok";
            var model = (Table_NHANVIEN)Session["User1"];

            //get Cookie          
            HttpCookie User = Request.Cookies["user"];
            HttpCookie Width = Request.Cookies["width"];
            if (User != null && Width != null)
            {
                model = db.Table_NHANVIENs.SingleOrDefault(m => m.ID_NHANVIEN == int.Parse(User.Value));
                Session["User1"] = model;
                Session["width"] = int.Parse(Width.Value);
            }
            return View(model);
        }

        public ActionResult DoiMK()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoiMK(FormCollection collection)
        {
            Table_NHANVIEN nv = (Table_NHANVIEN)Session["User1"];
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
                    return RedirectToAction("Me", "Display");
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
            return this.DoiMK();
        }

        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(FormCollection collection, DA_Web.Models.Table_NHANVIEN nv)
        {
            var hoten = collection["TenKhach"];
            var tendn = collection["TenDN"];
            var matkhau = collection["MatKhau"];
            var nlmatkhau = collection["NhapLaiMatKhau"];
            var diachi = collection["DiaChi"];
            var email = collection["Email"];
            var dienthoai = collection["SoDT"];
            string gioitinh = collection["rdGioiTinh"];
            bool gt;
            if (gioitinh.Equals("Nam"))
            {
                gt = true;

            }
            else
            {
                gt = false;

            }
            if (matkhau == nlmatkhau)
            {
                bool tontaitk = db.Table_NHANVIENs.Any(m => tendn == m.Username);
                if (tontaitk)
                {
                    ViewData["LoiUS"] = "Tài khoản đã được sử dụng";
                }
                else
                {
                    nv.HoTen = hoten;
                    nv.Username = tendn;
                    nv.Password = Str_Encoder(matkhau);
                    nv.Email = email;
                    nv.Diachi = diachi;
                    nv.GioiTinh = gt;
                    nv.SDT = dienthoai;
                    nv.ID_LOAINHANVIEN = 1;
                    db.Table_NHANVIENs.InsertOnSubmit(nv);
                    db.SubmitChanges();
                    Response.Write("<script>alert('Đăng ký thành công')</script>");
                    return RedirectToAction("DangNhap");
                }
            }
            else { ViewData["LoiMK"] = "Xác Nhận Mật Khẩu KHÔNG Trùng Khớp"; }

            return this.DangKy();
        }

        //Partial view trạng thái đăng nhập
        public ActionResult DangXuat()
        {
            Session["User1"] = null;
            if (Request.Cookies["user"] != null)
            {
                var user = new HttpCookie("user")
                {
                    Expires = DateTime.Now.AddDays(-1),
                    Value = null
                };
                Response.SetCookie(user);
            }
            if (int.Parse(Session["width"].ToString()) < 800)
            {
                return RedirectToAction("Me", "NhanVien");
            }
            else if (int.Parse(Session["width"].ToString()) >= 800)
            {
                return RedirectToAction("TrangChu", "Display");
            }
            return View();
        }

        public ActionResult ttDangNhappart()
        {
            Table_NHANVIEN nv = (Table_NHANVIEN)Session["User1"];
            if (nv != null)
            {
                ViewBag.Count = (int)DonHang.getCount_HoaDonChuaGiao(nv.ID_NHANVIEN);
            }

            return PartialView(nv);
        }

        public ActionResult LichSuDatHang(int ID_NHANVIEN)
        {
            var model = DonHang.getHoaDon_byIDNHANVIEN(ID_NHANVIEN);
            return View(model);
        }

        [HttpPost]
        public JsonResult ChitietDonHang(int ID_DONHANG)
        {
            var result = DonHang.getChiTietHoaDon_byIDDONHANG(ID_DONHANG);
            return Json(new
            {
                status = result
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult openLyDo(int ID_DONHANG)
        {
            string result = db.Table_DONHANGs.Where(m => m.ID_DONHANG == ID_DONHANG).Select(m => m.GhiChu).Single();
            return Json(new
            {
                status = result
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult openNote(int ID_DONHANG_DM)
        {
            string result = db.Table_DONHANG_DMs.Where(m => m.ID_DONHANG_DM == ID_DONHANG_DM).Select(m => m.GHICHU).Single();
            return Json(new
            {
                status = result
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult openNote_DH(int ID_DONHANG)
        {
            string result = db.Table_DONHANGs.Where(m => m.ID_DONHANG == ID_DONHANG).Select(m => m.PhanHoi).Single();
            return Json(new
            {
                status = result
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult openNote_GC(int ID_DONHANG)
        {
            string result = db.Table_DONHANGs.Where(m => m.ID_DONHANG == ID_DONHANG).Select(m => m.GhiChu).Single();
            return Json(new
            {
                status = result
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult change_select_donhang(int form)
        {

            Table_NHANVIEN nv = (Table_NHANVIEN)Session["User1"];
            var result = DonHang.getDonHang_bySelect(form, nv.ID_NHANVIEN);
            return Json(new
            {
                status = result
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult change_select_donhang_bydate(int form, string date)
        {

            Table_NHANVIEN nv = (Table_NHANVIEN)Session["User1"];
            var result = DonHang.getDonHang_bySelect_bydate(form, nv.ID_NHANVIEN, date);
            return Json(new
            {
                status = result
            }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult DonGiaoHang()
        {

            var model = DonHang.getHoaDonGiaoHang();
            var model2 = DonHang.getHoaDonGiaoHang_DaHuy();
            ViewBag.Count = model2.Count();
            return View(model);
        }
        public ActionResult DonGiaoHang_DaHuy()
        {

            var model = DonHang.getHoaDonGiaoHang_DaHuy();
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(int id)
        {
            var model = db.Table_DONHANGs.First(m => m.ID_DONHANG == id);
            model.ID_NGUOIGIAO = null;
            UpdateModel(model);
            db.SubmitChanges();
            return RedirectToAction("DonGiaoHang", "NhanVien", new { ID_NHANVIEN = 12 });
        }

        [HttpPost]
        public ActionResult DaGiao(int id)
        {
            var model = db.Table_DONHANGs.First(m => m.ID_DONHANG == id);
            var hoanthanh = db.Table_DONHANG_DMs.Where(m => m.ID_DONHANG == id && m.TinhTrang == true);
            var donhanghientai = db.Table_DONHANG_DMs.Where(m => m.ID_DONHANG == id);
            if (hoanthanh.Count() == donhanghientai.Count())
            {
                model.Damua = true;
                model.NgayGiaoHang = DateTime.Now.Date;
                UpdateModel(model);
                db.SubmitChanges();
                return JavaScript("OnSuccess();");
            }
            else
            {
                return JavaScript("OnFailure();");
            }

        }

        public ActionResult QuanLyDonDatHang()
        {
            Table_NHANVIEN nv = (Table_NHANVIEN)Session["User1"];
            var model = DonHang.getHoaDonGiaoHang_ChuaMua(nv.ID_NHANVIEN);
            ViewData["getTenNV"] = from a in db.Table_NHANVIENs where a.ID_LOAINHANVIEN == 1 select a;
            return View(model);
        }



        [HttpPost]
        public JsonResult QuanLyDonDatHang_select(string date)
        {
            var result = DonHang.getHoaDonGiaoHang_ChuaMua_ByDate(date);

            return Json(new
            {
                status = result,
            }, JsonRequestBehavior.AllowGet);




        }

        [HttpPost]
        public JsonResult getInfoNv(int ID_NHANVIEN)
        {
            var result = DonHang.getNhanVien_byID(ID_NHANVIEN);
            return Json(new
            {
                status = result
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult setNV_giaohang(int ID_DONHANG)
        {
            var model = db.Table_DONHANGs.First(m => m.ID_DONHANG == ID_DONHANG);
            bool check = false;
            if (model.ID_NGUOIGIAO == null)
            {

                int id_best = db.Table_NHANVIENs.Where(m => m.ID_LOAINHANVIEN == 2).Select(m => m.ID_NHANVIEN).Single();
                model.ID_NGUOIGIAO = id_best;
                Table_NHANVIEN nv = (Table_NHANVIEN)Session["User1"];
                model.ID_NGUOICHOT = nv.ID_NHANVIEN;
                UpdateModel(model);
                db.SubmitChanges();
                check = true;
            }


            return Json(new
            {
                status = check
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult setTinhTrang(int ID_DONHANG_DM)
        {
            var model = db.Table_DONHANG_DMs.First(m => m.ID_DONHANG_DM == ID_DONHANG_DM);
            var check = db.Table_DONHANGs.First(m => m.ID_DONHANG == model.ID_DONHANG);

            if (check.Damua == false)
            {
                if ((bool)model.TinhTrang)
                {
                    model.TinhTrang = false;
                }
                else
                {
                    model.TinhTrang = true;
                }
            }

            UpdateModel(model);
            db.SubmitChanges();
            var result = DonHang.getChiTietHoaDon_byIDDONHANG_DM(ID_DONHANG_DM);
            return Json(new
            {
                status = result,

            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult sendReport(int ID_DONHANG, string message)
        {
            var model = db.Table_DONHANGs.First(m => m.ID_DONHANG == ID_DONHANG);
            model.TinhTrang = false;
            model.GhiChu = message;
            UpdateModel(model);
            db.SubmitChanges();

            return Json(new
            {
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Boss_DaHuy()
        {
            var model = DonHang.getHoaDonGiaoHang_DaHuy();
            return View(model);
        }

        public void setDDlistNhanVien(int? selectedId = null)
        {
            ViewBag.NhanVien = new SelectList(NhanVienDAO.getNhanVIen_ChotDon(), "ID_NHANVIEN", "HoTen", selectedId);
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