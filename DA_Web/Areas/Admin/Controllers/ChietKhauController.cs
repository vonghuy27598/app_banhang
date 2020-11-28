using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DA_Web.Areas.Admin.Models;
using DA_Web.ViewModel;
using DA_Web.Models;

namespace DA_Web.Areas.Admin.Controllers
{
    public class ChietKhauController : BaseController
    {
        //
        // GET: /Admin/ChietKhau/
        dbQL_BanHangDataContext db = new dbQL_BanHangDataContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChietKhauNgay()
        {
            var model = NhanVienDAO.getChietKhau_byIDNV().GroupBy(x => new { x.ID_NHANVIEN, x.HoTen, x.TongSoDon, x.TongDoanhThu }).Select(sl => new DA_Web.ViewModel.NhanVien { ID_NHANVIEN = sl.Key.ID_NHANVIEN, HoTen = sl.Key.HoTen, ChietKhauNgay = sl.Sum(m => m.ChietKhauNgay), TongSoDon = sl.Key.TongSoDon, TongDoanhThu = sl.Key.TongDoanhThu });
            setDDlistNhanVien();
            return View(model);
        }

        public ActionResult ChietKhauNgay_KhongThanhCong()
        {
            var model = NhanVienDAO.getChietKhau_byIDNV_Fail().GroupBy(x => new { x.ID_NHANVIEN, x.HoTen, x.TongSoDon, x.TongDoanhThu }).Select(sl => new DA_Web.ViewModel.NhanVien { ID_NHANVIEN = sl.Key.ID_NHANVIEN, HoTen = sl.Key.HoTen, ChietKhauNgay = sl.Sum(m => m.ChietKhauNgay), TongSoDon = sl.Key.TongSoDon, TongDoanhThu = sl.Key.TongDoanhThu });
            setDDlistNhanVien();
            return View(model);
        }


        //Select by day
        //success
        [HttpPost]
        public JsonResult ChietKhauNgay_select(DateTime date, int idnv)
        {

            var result = NhanVienDAO.getChietKhau_byDate(date, idnv).GroupBy(x => new { x.ID_NHANVIEN, x.HoTen, x.TongSoDon, x.TongDoanhThu }).Select(sl => new DA_Web.ViewModel.NhanVien { ID_NHANVIEN = sl.Key.ID_NHANVIEN, HoTen = sl.Key.HoTen, ChietKhauNgay = sl.Sum(m => m.ChietKhauNgay), TongSoDon = sl.Key.TongSoDon, TongDoanhThu = sl.Key.TongDoanhThu });
            var count = result.Count();
            if (idnv == 0)
            {
                result = NhanVienDAO.getChietKhau_byDate(date, -1).GroupBy(x => new { x.ID_NHANVIEN, x.HoTen, x.TongSoDon, x.TongDoanhThu }).Select(sl => new DA_Web.ViewModel.NhanVien { ID_NHANVIEN = sl.Key.ID_NHANVIEN, HoTen = sl.Key.HoTen, ChietKhauNgay = sl.Sum(m => m.ChietKhauNgay), TongSoDon = sl.Key.TongSoDon, TongDoanhThu = sl.Key.TongDoanhThu });
                count = result.Count();
            }
            return Json(new
            {
                status = result,
                count = count
            }, JsonRequestBehavior.AllowGet);
        }

        //fail
        [HttpPost]
        public JsonResult ChietKhauNgay_select_Fail(DateTime date, int idnv)
        {

            var result = NhanVienDAO.getChietKhau_byDate_Fail(date, idnv).GroupBy(x => new { x.ID_NHANVIEN, x.HoTen, x.TongSoDon, x.TongDoanhThu }).Select(sl => new DA_Web.ViewModel.NhanVien { ID_NHANVIEN = sl.Key.ID_NHANVIEN, HoTen = sl.Key.HoTen, ChietKhauNgay = sl.Sum(m => m.ChietKhauNgay), TongSoDon = sl.Key.TongSoDon, TongDoanhThu = sl.Key.TongDoanhThu });
            var count = result.Count();
            if (idnv == 0)
            {
                result = NhanVienDAO.getChietKhau_byDate_Fail(date, -1).GroupBy(x => new { x.ID_NHANVIEN, x.HoTen, x.TongSoDon, x.TongDoanhThu }).Select(sl => new DA_Web.ViewModel.NhanVien { ID_NHANVIEN = sl.Key.ID_NHANVIEN, HoTen = sl.Key.HoTen, ChietKhauNgay = sl.Sum(m => m.ChietKhauNgay), TongSoDon = sl.Key.TongSoDon, TongDoanhThu = sl.Key.TongDoanhThu });
                count = result.Count();
            }
            return Json(new
            {
                status = result,
                count = count
            }, JsonRequestBehavior.AllowGet);
        }

        //Select by month
        //sucess
        [HttpPost]
        public JsonResult ChietKhauNgay_select_Month(DateTime date, int idnv)
        {

            var result = NhanVienDAO.getChietKhau_byMonth(date, idnv).GroupBy(x => new { x.ID_NHANVIEN, x.HoTen, x.TongSoDon, x.TongDoanhThu }).Select(sl => new DA_Web.ViewModel.NhanVien { ID_NHANVIEN = sl.Key.ID_NHANVIEN, HoTen = sl.Key.HoTen, ChietKhauNgay = sl.Sum(m => m.ChietKhauNgay), TongSoDon = sl.Key.TongSoDon, TongDoanhThu = sl.Key.TongDoanhThu });
            var count = result.Count();
            if (idnv == 0)
            {
                result = NhanVienDAO.getChietKhau_byMonth(date, -1).GroupBy(x => new { x.ID_NHANVIEN, x.HoTen, x.TongSoDon, x.TongDoanhThu }).Select(sl => new DA_Web.ViewModel.NhanVien { ID_NHANVIEN = sl.Key.ID_NHANVIEN, HoTen = sl.Key.HoTen, ChietKhauNgay = sl.Sum(m => m.ChietKhauNgay), TongSoDon = sl.Key.TongSoDon, TongDoanhThu = sl.Key.TongDoanhThu });
                count = result.Count();
            }
            return Json(new
            {
                status = result,
                count = count
            }, JsonRequestBehavior.AllowGet);
        }
        //fail
        [HttpPost]
        public JsonResult ChietKhauNgay_select_Month_Fail(DateTime date, int idnv)
        {

            var result = NhanVienDAO.getChietKhau_byMonth_Fail(date, idnv).GroupBy(x => new { x.ID_NHANVIEN, x.HoTen, x.TongSoDon, x.TongDoanhThu }).Select(sl => new DA_Web.ViewModel.NhanVien { ID_NHANVIEN = sl.Key.ID_NHANVIEN, HoTen = sl.Key.HoTen, ChietKhauNgay = sl.Sum(m => m.ChietKhauNgay), TongSoDon = sl.Key.TongSoDon, TongDoanhThu = sl.Key.TongDoanhThu });
            var count = result.Count();
            if (idnv == 0)
            {
                result = NhanVienDAO.getChietKhau_byMonth_Fail(date, -1).GroupBy(x => new { x.ID_NHANVIEN, x.HoTen, x.TongSoDon, x.TongDoanhThu }).Select(sl => new DA_Web.ViewModel.NhanVien { ID_NHANVIEN = sl.Key.ID_NHANVIEN, HoTen = sl.Key.HoTen, ChietKhauNgay = sl.Sum(m => m.ChietKhauNgay), TongSoDon = sl.Key.TongSoDon, TongDoanhThu = sl.Key.TongDoanhThu });
                count = result.Count();
            }
            return Json(new
            {
                status = result,
                count = count
            }, JsonRequestBehavior.AllowGet);
        }

        //Select by year
        //success
        [HttpPost]
        public JsonResult ChietKhauNgay_select_Year(string date, int idnv)
        {
            var result = NhanVienDAO.getChietKhau_byYear(date, idnv).GroupBy(x => new { x.ID_NHANVIEN, x.HoTen, x.TongSoDon, x.TongDoanhThu }).Select(sl => new DA_Web.ViewModel.NhanVien { ID_NHANVIEN = sl.Key.ID_NHANVIEN, HoTen = sl.Key.HoTen, ChietKhauNgay = sl.Sum(m => m.ChietKhauNgay), TongSoDon = sl.Key.TongSoDon, TongDoanhThu = sl.Key.TongDoanhThu });
            var count = result.Count();
            if(idnv==0)
            {
                result = NhanVienDAO.getChietKhau_byYear(date, -1).GroupBy(x => new { x.ID_NHANVIEN, x.HoTen, x.TongSoDon, x.TongDoanhThu }).Select(sl => new DA_Web.ViewModel.NhanVien { ID_NHANVIEN = sl.Key.ID_NHANVIEN, HoTen = sl.Key.HoTen, ChietKhauNgay = sl.Sum(m => m.ChietKhauNgay), TongSoDon = sl.Key.TongSoDon, TongDoanhThu = sl.Key.TongDoanhThu });
                count = result.Count();
            }
           
          
            return Json(new
            {
                status = result,
                count = count
            }, JsonRequestBehavior.AllowGet);
        }

        //fail
        [HttpPost]
        public JsonResult ChietKhauNgay_select_Year_Fail(string date, int idnv)
        {
            var result = NhanVienDAO.getChietKhau_byYear_Fail(date, idnv).GroupBy(x => new { x.ID_NHANVIEN, x.HoTen, x.TongSoDon, x.TongDoanhThu }).Select(sl => new DA_Web.ViewModel.NhanVien { ID_NHANVIEN = sl.Key.ID_NHANVIEN, HoTen = sl.Key.HoTen, ChietKhauNgay = sl.Sum(m => m.ChietKhauNgay), TongSoDon = sl.Key.TongSoDon, TongDoanhThu = sl.Key.TongDoanhThu });
            var count = result.Count();
            if (idnv == 0)
            {
                result = NhanVienDAO.getChietKhau_byYear_Fail(date, -1).GroupBy(x => new { x.ID_NHANVIEN, x.HoTen, x.TongSoDon, x.TongDoanhThu }).Select(sl => new DA_Web.ViewModel.NhanVien { ID_NHANVIEN = sl.Key.ID_NHANVIEN, HoTen = sl.Key.HoTen, ChietKhauNgay = sl.Sum(m => m.ChietKhauNgay), TongSoDon = sl.Key.TongSoDon, TongDoanhThu = sl.Key.TongDoanhThu });
                count = result.Count();
            }


            return Json(new
            {
                status = result,
                count = count
            }, JsonRequestBehavior.AllowGet);
        }


        //Chitietsodon
        //success
        [HttpPost]
        public JsonResult ChiTietSoDon(string date, int idnv,string form)
        {
            var result = NhanVienDAO.getChiTietChietKhau(date, idnv,form);          
            return Json(new
            {
                status = result
               
            }, JsonRequestBehavior.AllowGet);
        }
        //fail
        [HttpPost]
        public JsonResult ChiTietSoDon_Fail(string date, int idnv, string form)
        {
            var result = NhanVienDAO.getChiTietChietKhau_Fail(date, idnv, form);
            return Json(new
            {
                status = result

            }, JsonRequestBehavior.AllowGet);
        }

        //dropdown nhân viên chốt đơn
        public void setDDlistNhanVien(int? selectedId = null)
        {
            ViewBag.NhanVien = new SelectList(NhanVienDAO.getNhanVIen_ChotDon(), "ID_NHANVIEN", "HoTen", selectedId);
        }



        //-----------------------------------------------------CTV---------------------------------
        public ActionResult ChietKhauNgay_CTV()
        {
            var model = NhanVienDAO.getChietKhau_byIDNV_CTV().GroupBy(x => new { x.ID_NHANVIEN, x.HoTen, x.TongSoDon, x.TongDoanhThu }).Select(sl => new DA_Web.ViewModel.NhanVien { ID_NHANVIEN = sl.Key.ID_NHANVIEN, HoTen = sl.Key.HoTen, ChietKhauNgay = sl.Sum(m => m.ChietKhauNgay), TongSoDon = sl.Key.TongSoDon, TongDoanhThu = sl.Key.TongDoanhThu });
            setDDlistCTV();
            return View(model);
        }

        //-----------------------------------------------------CTV---------------------------------
        public ActionResult ChietKhauNgay_KhongThanhCong_CTV()
        {
            var model = NhanVienDAO.getChietKhau_byIDNV_CTV().GroupBy(x => new { x.ID_NHANVIEN, x.HoTen, x.TongSoDon, x.TongDoanhThu }).Select(sl => new DA_Web.ViewModel.NhanVien { ID_NHANVIEN = sl.Key.ID_NHANVIEN, HoTen = sl.Key.HoTen, ChietKhauNgay = sl.Sum(m => m.ChietKhauNgay), TongSoDon = sl.Key.TongSoDon, TongDoanhThu = sl.Key.TongDoanhThu });
            setDDlistCTV();
            return View(model);
        }

        //Select by day
        //success
        [HttpPost]
        public JsonResult ChietKhauNgay_select_CTV(DateTime date, int idnv)
        {

            var result = NhanVienDAO.getChietKhau_byDate_CTV(date, idnv).GroupBy(x => new { x.ID_NHANVIEN, x.HoTen, x.TongSoDon, x.TongDoanhThu }).Select(sl => new DA_Web.ViewModel.NhanVien { ID_NHANVIEN = sl.Key.ID_NHANVIEN, HoTen = sl.Key.HoTen, ChietKhauNgay = sl.Sum(m => m.ChietKhauNgay), TongSoDon = sl.Key.TongSoDon, TongDoanhThu = sl.Key.TongDoanhThu });
            var count = result.Count();
            if (idnv == 0)
            {
                result = NhanVienDAO.getChietKhau_byDate_CTV(date, -1).GroupBy(x => new { x.ID_NHANVIEN, x.HoTen, x.TongSoDon, x.TongDoanhThu }).Select(sl => new DA_Web.ViewModel.NhanVien { ID_NHANVIEN = sl.Key.ID_NHANVIEN, HoTen = sl.Key.HoTen, ChietKhauNgay = sl.Sum(m => m.ChietKhauNgay), TongSoDon = sl.Key.TongSoDon, TongDoanhThu = sl.Key.TongDoanhThu });
                count = result.Count();
            }
            return Json(new
            {
                status = result,
                count = count
            }, JsonRequestBehavior.AllowGet);
        }

        //fail
        [HttpPost]
        public JsonResult ChietKhauNgay_select_CTV_Fail(DateTime date, int idnv)
        {

            var result = NhanVienDAO.getChietKhau_byDate_CTV_Fail(date, idnv).GroupBy(x => new { x.ID_NHANVIEN, x.HoTen, x.TongSoDon, x.TongDoanhThu }).Select(sl => new DA_Web.ViewModel.NhanVien { ID_NHANVIEN = sl.Key.ID_NHANVIEN, HoTen = sl.Key.HoTen, ChietKhauNgay = sl.Sum(m => m.ChietKhauNgay), TongSoDon = sl.Key.TongSoDon, TongDoanhThu = sl.Key.TongDoanhThu });
            var count = result.Count();
            if (idnv == 0)
            {
                result = NhanVienDAO.getChietKhau_byDate_CTV_Fail(date, -1).GroupBy(x => new { x.ID_NHANVIEN, x.HoTen, x.TongSoDon, x.TongDoanhThu }).Select(sl => new DA_Web.ViewModel.NhanVien { ID_NHANVIEN = sl.Key.ID_NHANVIEN, HoTen = sl.Key.HoTen, ChietKhauNgay = sl.Sum(m => m.ChietKhauNgay), TongSoDon = sl.Key.TongSoDon, TongDoanhThu = sl.Key.TongDoanhThu });
                count = result.Count();
            }
            return Json(new
            {
                status = result,
                count = count
            }, JsonRequestBehavior.AllowGet);
        }

        //Select by month
        //sucess
        [HttpPost]
        public JsonResult ChietKhauNgay_select_Month_CTV(DateTime date, int idnv)
        {

            var result = NhanVienDAO.getChietKhau_byMonth_CTV(date, idnv).GroupBy(x => new { x.ID_NHANVIEN, x.HoTen, x.TongSoDon, x.TongDoanhThu }).Select(sl => new DA_Web.ViewModel.NhanVien { ID_NHANVIEN = sl.Key.ID_NHANVIEN, HoTen = sl.Key.HoTen, ChietKhauNgay = sl.Sum(m => m.ChietKhauNgay), TongSoDon = sl.Key.TongSoDon, TongDoanhThu = sl.Key.TongDoanhThu });
            var count = result.Count();
            if (idnv == 0)
            {
                result = NhanVienDAO.getChietKhau_byMonth_CTV(date, -1).GroupBy(x => new { x.ID_NHANVIEN, x.HoTen, x.TongSoDon, x.TongDoanhThu }).Select(sl => new DA_Web.ViewModel.NhanVien { ID_NHANVIEN = sl.Key.ID_NHANVIEN, HoTen = sl.Key.HoTen, ChietKhauNgay = sl.Sum(m => m.ChietKhauNgay), TongSoDon = sl.Key.TongSoDon, TongDoanhThu = sl.Key.TongDoanhThu });
                count = result.Count();
            }
            return Json(new
            {
                status = result,
                count = count
            }, JsonRequestBehavior.AllowGet);
        }
        //fail
        [HttpPost]
        public JsonResult ChietKhauNgay_select_Month_CTV_Fail(DateTime date, int idnv)
        {

            var result = NhanVienDAO.getChietKhau_byMonth_CTV_Fail(date, idnv).GroupBy(x => new { x.ID_NHANVIEN, x.HoTen, x.TongSoDon, x.TongDoanhThu }).Select(sl => new DA_Web.ViewModel.NhanVien { ID_NHANVIEN = sl.Key.ID_NHANVIEN, HoTen = sl.Key.HoTen, ChietKhauNgay = sl.Sum(m => m.ChietKhauNgay), TongSoDon = sl.Key.TongSoDon, TongDoanhThu = sl.Key.TongDoanhThu });
            var count = result.Count();
            if (idnv == 0)
            {
                result = NhanVienDAO.getChietKhau_byMonth_CTV_Fail(date, -1).GroupBy(x => new { x.ID_NHANVIEN, x.HoTen, x.TongSoDon, x.TongDoanhThu }).Select(sl => new DA_Web.ViewModel.NhanVien { ID_NHANVIEN = sl.Key.ID_NHANVIEN, HoTen = sl.Key.HoTen, ChietKhauNgay = sl.Sum(m => m.ChietKhauNgay), TongSoDon = sl.Key.TongSoDon, TongDoanhThu = sl.Key.TongDoanhThu });
                count = result.Count();
            }
            return Json(new
            {
                status = result,
                count = count
            }, JsonRequestBehavior.AllowGet);
        }

        //Select by year
        //success
        [HttpPost]
        public JsonResult ChietKhauNgay_select_Year_CTV(string date, int idnv)
        {
            var result = NhanVienDAO.getChietKhau_byYear_CTV(date, idnv).GroupBy(x => new { x.ID_NHANVIEN, x.HoTen, x.TongSoDon, x.TongDoanhThu }).Select(sl => new DA_Web.ViewModel.NhanVien { ID_NHANVIEN = sl.Key.ID_NHANVIEN, HoTen = sl.Key.HoTen, ChietKhauNgay = sl.Sum(m => m.ChietKhauNgay), TongSoDon = sl.Key.TongSoDon, TongDoanhThu = sl.Key.TongDoanhThu });
            var count = result.Count();
            if (idnv == 0)
            {
                result = NhanVienDAO.getChietKhau_byYear_CTV(date, -1).GroupBy(x => new { x.ID_NHANVIEN, x.HoTen, x.TongSoDon, x.TongDoanhThu }).Select(sl => new DA_Web.ViewModel.NhanVien { ID_NHANVIEN = sl.Key.ID_NHANVIEN, HoTen = sl.Key.HoTen, ChietKhauNgay = sl.Sum(m => m.ChietKhauNgay), TongSoDon = sl.Key.TongSoDon, TongDoanhThu = sl.Key.TongDoanhThu });
                count = result.Count();
            }


            return Json(new
            {
                status = result,
                count = count
            }, JsonRequestBehavior.AllowGet);
        }

        //fail
        [HttpPost]
        public JsonResult ChietKhauNgay_select_Year_CTV_Fail(string date, int idnv)
        {
            var result = NhanVienDAO.getChietKhau_byYear_CTV_Fail(date, idnv).GroupBy(x => new { x.ID_NHANVIEN, x.HoTen, x.TongSoDon, x.TongDoanhThu }).Select(sl => new DA_Web.ViewModel.NhanVien { ID_NHANVIEN = sl.Key.ID_NHANVIEN, HoTen = sl.Key.HoTen, ChietKhauNgay = sl.Sum(m => m.ChietKhauNgay), TongSoDon = sl.Key.TongSoDon, TongDoanhThu = sl.Key.TongDoanhThu });
            var count = result.Count();
            if (idnv == 0)
            {
                result = NhanVienDAO.getChietKhau_byYear_CTV_Fail(date, -1).GroupBy(x => new { x.ID_NHANVIEN, x.HoTen, x.TongSoDon, x.TongDoanhThu }).Select(sl => new DA_Web.ViewModel.NhanVien { ID_NHANVIEN = sl.Key.ID_NHANVIEN, HoTen = sl.Key.HoTen, ChietKhauNgay = sl.Sum(m => m.ChietKhauNgay), TongSoDon = sl.Key.TongSoDon, TongDoanhThu = sl.Key.TongDoanhThu });
                count = result.Count();
            }
            return Json(new
            {
                status = result,
                count = count
            }, JsonRequestBehavior.AllowGet);
        }




        //Chitietsodon
        //success
        [HttpPost]
        public JsonResult ChiTietSoDon_CTV(string date, int idnv, string form)
        {
            var result = NhanVienDAO.getChiTietChietKhau_CTV(date, idnv, form);
            return Json(new
            {
                status = result

            }, JsonRequestBehavior.AllowGet);
        }

        //fail
        [HttpPost]
        public JsonResult ChiTietSoDon_CTV_Fail(string date, int idnv, string form)
        {
            var result = NhanVienDAO.getChiTietChietKhau_CTV_Fail(date, idnv, form);
            return Json(new
            {
                status = result

            }, JsonRequestBehavior.AllowGet);
        }
        


        //dropdown cộng tác viên
        public void setDDlistCTV(int? selectedId = null)
        {
            ViewBag.NhanVien = new SelectList(NhanVienDAO.getNhanVIen_CTV(), "ID_NHANVIEN", "HoTen", selectedId);
        }

	}
}