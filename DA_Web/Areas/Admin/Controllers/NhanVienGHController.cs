using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DA_Web.Areas.Admin.Models;
using DA_Web.ViewModel;

namespace DA_Web.Areas.Admin.Controllers
{
    public class NhanVienGHController : BaseController
    {
        //
        // GET: /Admin/NhanVienGH/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GiaoHang()
        {
            var model = NhanVienDAO.getTongDH_byID();
            return View(model);
        }

        [HttpPost]
        public JsonResult GiaoHang_select(DateTime date)
        {

            var result = NhanVienDAO.getTongDH_bydate(date);

            return Json(new
            {
                status = result
            }, JsonRequestBehavior.AllowGet);
        }
	}
}