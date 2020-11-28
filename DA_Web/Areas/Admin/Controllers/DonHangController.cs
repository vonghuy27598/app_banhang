using DA_Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DA_Web.Areas.Admin.Controllers
{
    public class DonHangController : Controller
    {
        //
        // GET: /Admin/DonHang/
        public ActionResult DanhSachDonHang()
        {
            var model = DonHangDAO.getHoaDon();
            ViewBag.TongHD = model.Count();
            return View(model);
        }

        public ActionResult ChiTietDonHang(int ID_DONHANG)
        {
            var model = DonHangDAO.getHoaDon_Full(ID_DONHANG);
            ViewData["chitiet"] = DonHangDAO.getChiTietHoaDon_byID(ID_DONHANG);
            return View(model.Single());
        }

        [HttpPost]
        public JsonResult DanhSachDonHang_select(DateTime date)
        {
            var result = DonHangDAO.getHoaDon_ByDate(date);
            ViewBag.TongHD = result.Count();
            return Json(new
            {
                status = result
            }, JsonRequestBehavior.AllowGet);
        }
	}
}