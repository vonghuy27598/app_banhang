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
    public class NSXController : BaseController
    {
        //
        // GET: /Admin/NSX/
      
        dbQL_BanHangDataContext data = new dbQL_BanHangDataContext();

        public ActionResult Index()
        {
            var model = NhaSXDAO.getNhaSX();
            return View(model);
        }

        public ActionResult CreateNSX()
        {
            return View();
            }

        [HttpPost]
        public ActionResult CreateNSX(NhaSX nsx)
        {
            bool tontaiNSX = data.Table_NhaSXes.Any(m => m.NhaSX== nsx.NHASX);
            if (tontaiNSX)
            {
                ModelState.AddModelError("NhaSX", "Nhà sản xuất này đã tồn tại");
            }
           
            if (ModelState.IsValid)
            {
                DA_Web.Models.Table_NhaSX tb_nsx = new Table_NhaSX();
                tb_nsx.NhaSX = nsx.NHASX;
                tb_nsx.NoiSX = nsx.NoiSX;               
                data.Table_NhaSXes.InsertOnSubmit(tb_nsx);
                data.SubmitChanges();

                return RedirectToAction("Index", "NSX");

            }
            return View(nsx);
        }

        //Sửa
        [HttpGet]
        public ActionResult EditNSX(int id)
        {
            
            var model = data.Table_NhaSXes.First(m => m.ID_NSX == id);
            return View(model);

        }

        [HttpPost]
        public ActionResult EditNSX(int id,Table_NhaSX nsx)
        {
            var getRoot = data.Table_NhaSXes.First(m => m.ID_NSX == id);
            
            if (String.IsNullOrEmpty(nsx.NhaSX))
            {
                ViewBag.Loi1 = "*";
                ViewBag.MessError = "Vui lòng nhập tên nhà sản xuất";
            }
            if (String.IsNullOrEmpty(nsx.NoiSX))
            {
                ViewBag.Loi1 = "*";
                ViewBag.MessError = "Vui lòng nhập tên nơi sản xuất";
            }    
            else
            {

                var model = data.Table_NhaSXes.First(m => m.ID_NSX == id);
                model.NhaSX = nsx.NhaSX;
                model.NoiSX = nsx.NoiSX;
                data.SubmitChanges();
                return RedirectToAction("Index", "NSX");

            }
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new XuLyDAO().DeleteNSX(id);      
            return View("Index");
            
        }

        public string ProcessUpload(HttpPostedFileBase file)
        {
            file.SaveAs(Server.MapPath("~/Content/image/" + file.FileName));
            return file.FileName;
        } 
    }
}