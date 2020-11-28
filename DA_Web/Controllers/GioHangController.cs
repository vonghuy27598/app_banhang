using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DA_Web.Models;
using DA_Web.Areas.Admin.Controllers;
using System.Collections;
namespace DA_Web.Controllers
{
    public class GioHangController : AKMLController
    {
        //
        // GET: /GioHang/
        dbQL_BanHangDataContext db = new dbQL_BanHangDataContext();

        public ActionResult Index()
        {
            return View();
        }

        //Lấy giỏ hàng
        public List<GioHang> LayGioHang()
        {
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;

            if (listGioHang == null)
            {
                // Nếu giỏ hàng chưa tồn tại thì khởi tạo listGioHang
                listGioHang = new List<GioHang>();
                Session["GioHang"] = listGioHang;

            }
            return listGioHang;
        }

        [HttpPost]
        public JsonResult Delete_All_Cart()
        {
            Session["GioHang"] = null;
            return Json(new
            {


            }, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public JsonResult AddToCart_fly(int id)
        //{
        //    //Lấy ra session giỏ hàng
        //    List<GioHang> listGioHang = LayGioHang();
        //    //Kiểm tra quạt này tồn tại trong Session["GioHang"] chưa
        //    GioHang giohang = listGioHang.Find(m => m.sID_SANPHAM == id);
        //    bool warning = true;
        //    if (giohang == null)
        //    {
        //        giohang = new GioHang(id);
        //        warning = false;
        //        listGioHang.Add(giohang);
        //    }
        //    else
        //    {

        //        var model = from a in db.Table_SANPHAMs select a;
        //        int soluong = (int)model.Where(m => m.ID_SANPHAM == id).Select(m => m.SoLuong).SingleOrDefault();
        //        if (giohang.sSoLuong != soluong)
        //        {
        //            warning = false;
        //            giohang.sSoLuong++;
        //        }

        //    }

        //        GioHang gh = listGioHang.SingleOrDefault(m => m.sID_SANPHAM == id);
        //        gh.TongTienUD = TongTien();
        //        gh.TongSoLuong = TongSoLuong();
        //        var result = giohang;
        //        if (warning)
        //        {
        //            return Json(new
        //            {
        //                warning=true,
        //                status = result
        //            }, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json(new
        //            {
        //                warning = false,
        //                status = result
        //            }, JsonRequestBehavior.AllowGet);
        //        }

        //}


        public JsonResult List_info_saved(string a)
        {
            var nv = (Table_NHANVIEN)Session["User1"];
            var data = db.Table_KHACHHANGs.Where(m => m.SDT.Contains(a) && m.ID_GIOITHIEU == nv.ID_NHANVIEN).OrderByDescending(m => m.NgayGioiThieu).Select(m => m.SDT).Take(3).ToList();
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult getInfo_byPhone(string SDT)
        {
            Table_NHANVIEN nv = (Table_NHANVIEN)Session["User1"];
            var result = XuLy.SanPham.getInfoKH_byPhone(SDT, nv.ID_NHANVIEN);
            return Json(new
            {
                
                status = result
            }, JsonRequestBehavior.AllowGet);
        }
        

        [HttpPost]
        public JsonResult AddToCart(int id, int idtuychon, int qlty)
        {
            //Lấy ra session giỏ hàng
            List<GioHang> listGioHang = LayGioHang();
            //Kiểm tra quạt này tồn tại trong Session["GioHang"] chưa
            GioHang giohang = listGioHang.Find(m => m.sID_SANPHAM == id && m.sID_TUYCHON == idtuychon);
            var model = from a in db.Table_TUYCHONs select a;
            int soluong = (int)model.Where(m => m.ID_TUYCHON == idtuychon).Select(m => m.SoLuong).SingleOrDefault();
            double dongia = (int)model.Where(m => m.ID_TUYCHON == idtuychon).Select(m => m.DonGia).SingleOrDefault();
            bool warning = true;
            if (giohang == null)
            {
                if (qlty <= soluong)
                {
                    giohang = new GioHang(id, idtuychon, qlty, dongia);
                    warning = false;

                    listGioHang.Add(giohang);
                }
                else
                {
                    var result = giohang;
                    return Json(new
                    {
                        warning = true,
                        status = result
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                if (giohang.sSoLuong != soluong )
                {
                    giohang.sSoLuong = giohang.sSoLuong + qlty;
                    if (giohang.sSoLuong > soluong)
                    {
                        giohang.sSoLuong = giohang.sSoLuong - qlty;
                        var result = giohang;
                        return Json(new
                        {
                            warning = true,
                            status = result
                        }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        warning = false;
                    }
                }
            }
            if (warning)
            {
                GioHang gh = listGioHang.SingleOrDefault(m => m.sID_SANPHAM == id && m.sID_TUYCHON == idtuychon);
                gh.TongTienUD = TongTien();
                gh.TongSoLuong = TongSoLuong();
                var result = giohang;
                return Json(new
                {
                    warning = true,
                    status = result
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                GioHang gh = listGioHang.SingleOrDefault(m => m.sID_SANPHAM == id && m.sID_TUYCHON == idtuychon);

                gh.TongTienUD = TongTien();
                gh.TongSoLuong = TongSoLuong();
                var result = giohang;
                return Json(new
                {
                    warning = false,
                    status = result
                }, JsonRequestBehavior.AllowGet);
            }

        }

        //Tổng số lượng
        private int TongSoLuong()
        {
            int sTongSoLuong = 0;
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if (listGioHang != null)
            {
                sTongSoLuong = listGioHang.Sum(m => m.sSoLuong);
            }
            return sTongSoLuong;

        }

        //Tính tổng tiền
        private double TongTien()
        {
            double sTongTien = 0;
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if (listGioHang != null)
            {
                sTongTien = listGioHang.Sum(m => m.sThanhTien);
            }
            return sTongTien;
        }

        //Xây dựng trang giỏ hàng
        public ActionResult GioHang()
        {
            List<GioHang> listGioHang = LayGioHang();
            //if (listGioHang.Count == 0)
            //{
            //    return RedirectToAction("TrangChu", "Display");
            //}
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return View(listGioHang);
        }

        [HttpPost]
        public JsonResult SaveNote(int id, string note)
        {
            List<GioHang> listgiohang = LayGioHang();
            GioHang giohang = listgiohang.SingleOrDefault(m => m.sID_TUYCHON == id);
            giohang.GHICHU = note;
            //var model = from a in db.Table_SANPHAMs select a;
            //int soluong = (int)model.Where(m => m.ID_SANPHAM == id).Select(m => m.SoLuong).SingleOrDefault();


            return Json(new
            {

            }, JsonRequestBehavior.AllowGet);



        }
        //Partial view hiển thị thông tin giỏ hàng 
        public ActionResult ttGioHangpart()
        {
            List<GioHang> listGioHang = LayGioHang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView(listGioHang);
        }

        public JsonResult XoaGioHang(int id)
        {
            //Lấy giỏ hàng từ Session
            List<GioHang> listGioHang = LayGioHang();
            //Kiểm tra sách có trong Session["GioHang"] chưa
            GioHang giohang = listGioHang.SingleOrDefault(m => m.sID_TUYCHON == id);

            //Nếu tồn tại thì cho xóa soluong
            if (giohang != null)
            {
                listGioHang.RemoveAll(m => m.sID_TUYCHON == id);

            }
            giohang.TongTienUD = TongTien();
            List<GioHang> countGioHang = Session["GioHang"] as List<GioHang>;
            //var count = countGioHang.Count;
            var result = giohang;
            return Json(new
            {
                status = result

            }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult CapNhatGioHang(int sID_SANPHAM, FormCollection collection)
        {
            List<GioHang> listGioHang = LayGioHang();
            //Kiểm tra sách có trong Session["GioHang"] chưa
            GioHang giohang = listGioHang.SingleOrDefault(m => m.sID_SANPHAM == sID_SANPHAM);
            //Nếu tồn tại thì cho xóa soluong
            if (giohang != null)
            {
                try
                {
                    giohang.sSoLuong = int.Parse(collection["qtybutton"].ToString());
                }
                //neu rong
                catch { giohang.sSoLuong = 1; }

            }
            return RedirectToAction("GioHang");
        }

        public ActionResult CheckLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckLogin(FormCollection collection)
        {
            Table_KHACHHANG kh = new Table_KHACHHANG();
            Table_NHANVIEN nv = (Table_NHANVIEN)Session["User1"];
           
            var sdt = collection["SODT"];
            string Sodt = sdt;
            var hoten = collection["HOTEN"];
            var diachi = collection["DIACHI"];
            if (Session["User1"] != null)
            {
                var dchi = collection["DIACHI"];
                if (String.IsNullOrEmpty(sdt))
                {
                    ViewData["Loi1"] = "*";
                    ViewBag.Mess = string.Format("Nhập sô điện thoại");

                }
                else if (String.IsNullOrEmpty(hoten))
                {
                    ViewData["Loi2"] = "*";
                    ViewBag.Mess = "Vui lòng nhập họ & tên";

                }
                else if (String.IsNullOrEmpty(dchi))
                {
                    ViewData["Loi3"] = "*";
                    ViewBag.Mess = "Vui lòng nhập địa chỉ";

                }
                else
                {
                    
                    kh.HoTen = hoten;
                    kh.SDT = sdt;
                    kh.DiaChi = diachi;
                    kh.ID_GIOITHIEU = nv.ID_NHANVIEN;
                    kh.NgayGioiThieu = DateTime.Now;
                    bool check = db.Table_KHACHHANGs.Any(m => m.SDT == sdt && m.ID_GIOITHIEU == nv.ID_NHANVIEN);
                    if (!check)
                    {                       
                        db.Table_KHACHHANGs.InsertOnSubmit(kh);
                        db.SubmitChanges();
                        Session["User"] = kh;
                    }
                    else
                    {
                        Table_KHACHHANG upKH = db.Table_KHACHHANGs.First(m =>m.SDT == sdt && m.ID_GIOITHIEU == nv.ID_NHANVIEN);
                        upKH.HoTen = hoten;
                        upKH.SDT = sdt;
                        upKH.DiaChi = diachi;
                        upKH.NgayGioiThieu = DateTime.Now;
                        UpdateModel(upKH);
                        db.SubmitChanges();
                        Session["User"] = upKH;
                    }
                    
                    
                    return RedirectToAction("DatHang", "GioHang");

                }
            }
            else
            {
                ViewBag.sdt = sdt;
                ViewBag.hoten = hoten;
                ViewBag.diachi = diachi;
                if (String.IsNullOrEmpty(sdt))
                {                 
                    ViewBag.Mess = string.Format("Nhập số điện thoại");
                }
                else if (String.IsNullOrEmpty(hoten))
                {

                    ViewBag.Mess = "Vui lòng nhập họ & tên";                  
                }
                else if(String.IsNullOrEmpty(diachi))
                {
                    ViewBag.Mess = "Vui lòng nhập địa chỉ";
                }
                else
                {
                    HttpCookie Phone_UserCookie = new HttpCookie("phone_user", (sdt).ToString());
                    HttpCookie Name_UserCookie = new HttpCookie("name_user", (hoten).ToString());
                    HttpCookie Address_UserCookie = new HttpCookie("address_user", (diachi).ToString());
                    Phone_UserCookie.HttpOnly = true;
                    Name_UserCookie.HttpOnly = true;
                    Address_UserCookie.HttpOnly = true;
                    Phone_UserCookie.Expires = DateTime.Now.AddDays(365);
                    Name_UserCookie.Expires = DateTime.Now.AddDays(365);
                    Address_UserCookie.Expires = DateTime.Now.AddDays(365);
                    HttpContext.Response.SetCookie(Phone_UserCookie);
                    HttpContext.Response.SetCookie(Name_UserCookie);
                    HttpContext.Response.SetCookie(Address_UserCookie);
                   
                    kh.HoTen = hoten;
                    kh.SDT = sdt;
                    kh.DiaChi = diachi;
                    bool check = db.Table_KHACHHANGs.Any(m => m.SDT == sdt);
                    if (!check)
                    {
                        db.Table_KHACHHANGs.InsertOnSubmit(kh);
                        db.SubmitChanges();
                        Session["User"] = kh;
                    }
                    else
                    {
                        Table_KHACHHANG upKH = db.Table_KHACHHANGs.First(m => m.SDT == sdt);
                        upKH.HoTen = hoten;
                        upKH.SDT = sdt;
                        upKH.DiaChi = diachi;                      
                        UpdateModel(upKH);
                        db.SubmitChanges();
                        Session["User"] = upKH;
                    }
                    
                    
                    return RedirectToAction("DatHang", "GioHang");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult DatHang()
        {

            //Lấy giỏ hàng từ Session
            List<GioHang> listGioHang = LayGioHang();
            if (listGioHang.Count == 0)
            {
                Response.Write("<script LANGUAGE='JavaScript' > alert('Giỏ hàng đang rỗng ! Không thể đặt hàng');  location.href = '/Display/TrangChu';</script>");

            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return View(listGioHang);
        }

        [HttpPost]
        public JsonResult DatHang(FormCollection collection)
        {
            List<GioHang> listGioHang = LayGioHang();
            //Thêm đơn hàng
            Table_DONHANG ddh = new Table_DONHANG();
            Table_KHACHHANG kh = (Table_KHACHHANG)Session["User"];
            Table_NHANVIEN nv = (Table_NHANVIEN)Session["User1"];

            List<GioHang> gh = LayGioHang();
            if (nv != null)
            {
                ddh.ID_NGUOIBAN = nv.ID_NHANVIEN;
            }

            ddh.ID_KHACHHANG = kh.ID_KHACHHANG;
            ddh.NgayGiaoDich = DateTime.Now;
            ddh.TONGTIEN = TongTien();
            ddh.Damua = false;
            db.Table_DONHANGs.InsertOnSubmit(ddh);
            db.SubmitChanges();
            //Thêm chi tiết đơn hàng


            foreach (var item in gh)
            {
                Table_DONHANG_DM ctdh = new Table_DONHANG_DM();
                ctdh.ID_DONHANG = ddh.ID_DONHANG;
                ctdh.TuyChon = item.TuyChon;
                ctdh.ID_SANPHAM = item.sID_SANPHAM;
                ctdh.SoLuong = item.sSoLuong;
                ctdh.Giatien = item.sDonGia;
                ctdh.TinhTrang = false;
                ctdh.GHICHU = item.GHICHU;
                db.Table_DONHANG_DMs.InsertOnSubmit(ctdh);
                var upslSP = db.Table_TUYCHONs.First(m => m.ID_TUYCHON == item.sID_TUYCHON);
                if (upslSP.SoLuong > 0 && upslSP.SoLuong < item.sSoLuong)
                {
                    ViewBag.Error = "Sản phẩm hiện chỉ còn " + upslSP.SoLuong.ToString();
                    break;
                }
                else if (upslSP.SoLuong == 0)
                {
                    ViewBag.Error = "Xin lỗi sản phẩm hiện hết hàng";
                    break;
                }
                else
                {
                    upslSP.SoLuong = upslSP.SoLuong - item.sSoLuong;
                    UpdateModel(upslSP);
                    db.SubmitChanges();
                }
            }
            Session["GioHang"] = null;


            return Json(new
            {

            }, JsonRequestBehavior.AllowGet);


        }

        public ActionResult DatHangThanhCong()
        {

            return View();
        }

        [HttpPost]
        public JsonResult UpdateSL(int sl, int id)
        {
            List<GioHang> listGioHang = LayGioHang();
            //Kiểm tra sách có trong Session["GioHang"] chưa
            GioHang giohang = listGioHang.SingleOrDefault(m => m.sID_TUYCHON == id);
            giohang.sSoLuong = sl;
            //lỗi
            giohang.ThanhTienUD = giohang.sSoLuong * giohang.sDonGia;
            giohang.TongTienUD = TongTien();

            var model = from a in db.Table_TUYCHONs select a;
            int soluong = (int)model.Where(m => m.ID_TUYCHON == id).Select(m => m.SoLuong).SingleOrDefault();
            var result = giohang;
            return Json(new
            {
                count = soluong,
                status = result
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult checkSoLuong(int sl, int id)
        {
            List<GioHang> listGioHang = LayGioHang();
            GioHang giohang = listGioHang.SingleOrDefault(m => m.sID_TUYCHON == id);

            var model = from a in db.Table_TUYCHONs select a;
            int soluong = (int)model.Where(m => m.ID_TUYCHON == id).Select(m => m.SoLuong).SingleOrDefault();
            var result = false;
            if (sl == soluong)
            {
                result = true;
            }

            return Json(new
            {

                status = result
            }, JsonRequestBehavior.AllowGet);
        }
    }
}