using DA_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using DA_Web.Areas.Admin.Models;
using DA_Web.ViewModel;
using System.Text;
using System.Security.Cryptography;
namespace DA_Web.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        //
        // GET: /Admin/User/

        DA_Web.Models.dbQL_BanHangDataContext data = new DA_Web.Models.dbQL_BanHangDataContext();
        public ActionResult DanhSach(int id_loainv, int? page)
        {
            int pageSize = 10;
            //Tạo biến số trang
            int pageNum = (page ?? 1);
            if (id_loainv == 0)
            {
                ViewBag.LoaiNV = "Nhân viên";
            }
            else if(id_loainv ==1)
            {
                ViewBag.LoaiNV = "Cộng tác viên";
            }
            setDDlistLoaiNhanVien();
            var model = NhanVienDAO.getNhanVien_byLoai(id_loainv);
            return View(model.ToPagedList(pageNum, pageSize));
        }

        public void setDDlistLoaiNhanVien_All(int? selectedId = null)
        {
            var model = from a in data.Table_LOAINHANVIENs where a.ID_LOAINHANVIEN >= 1 select a;
            ViewBag.getLoaiNV = new SelectList(model, "ID_LOAINHANVIEN", "Tenloainhanvien", selectedId);

        }

        public void setDDlistLoaiNhanVien(int? selectedId = null)
        {
            var model = from a in data.Table_LOAINHANVIENs where a.ID_LOAINHANVIEN > 1 select a;
            ViewBag.getLoaiNV = new SelectList(model, "ID_LOAINHANVIEN", "Tenloainhanvien", selectedId);

        }

        [HttpPost]
        public JsonResult ChangeLoaiNV(int ID_LOAINV)
        {
            var result = NhanVienDAO.getNhanVien_byIDLOAINV(ID_LOAINV);
            return Json(new
            {
                status = result
            }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult ThongTinNhanVien(int id_nv)
        {

            var model = NhanVienDAO.getNhanVien_byNV(id_nv);
            return View(model.Single());
        }

        public ActionResult EditNhanVien(int id_nv)
        {
            var model = NhanVienDAO.getNhanVien_byNV(id_nv);

            setDDlistLoaiNhanVien_All();
            return View(model.Single());

        }

        [HttpPost]
        public ActionResult EditNhanVien(int id_nv, NhanVien nv)
        {
            var model = NhanVienDAO.getNhanVien_byNV(id_nv);
            if (ModelState.IsValid)
            {
                var tb_nv = data.Table_NHANVIENs.Where(m => m.ID_NHANVIEN == id_nv).FirstOrDefault();
                if ((int)model.Select(m => m.ID_LOAINHANVIEN).SingleOrDefault() > 1)
                {
                   
                    ViewBag.LoaiNV = "Nhân viên";
                    setDDlistLoaiNhanVien_All();
                    if (tb_nv != null)
                    {
                        tb_nv.HoTen = nv.HoTen;
                        tb_nv.GioiTinh = nv.GioiTinh;
                        tb_nv.SDT = nv.SDT;
                        tb_nv.Skype = nv.Skype;
                        tb_nv.TKBank = nv.TKBank;
                        tb_nv.Diachi = nv.Diachi;
                        tb_nv.Email = nv.Email;
                        tb_nv.ANHDAIDIEN = nv.ANHDAIDIEN;
                        tb_nv.ID_LOAINHANVIEN = nv.ID_LOAINHANVIEN;
                        data.SubmitChanges();
                    }
                   
                    
                    return RedirectToAction("DanhSach", "User", new { id_loainv = 0 });
                }
                else if ((int)model.Select(m => m.ID_LOAINHANVIEN).SingleOrDefault() == 1)
                {                  
                    ViewBag.LoaiNV = "Cộng tác viên";
                    if (tb_nv != null)
                    {
                        tb_nv.HoTen = nv.HoTen;
                        tb_nv.GioiTinh = nv.GioiTinh;
                        tb_nv.SDT = nv.SDT;
                        tb_nv.Skype = nv.Skype;
                        tb_nv.TKBank = nv.TKBank;
                        tb_nv.Diachi = nv.Diachi;
                        tb_nv.Email = nv.Email;
                        tb_nv.ANHDAIDIEN = nv.ANHDAIDIEN;
                        tb_nv.ID_LOAINHANVIEN = nv.ID_LOAINHANVIEN;
                        data.SubmitChanges();
                    }
                    return RedirectToAction("DanhSach", "User", new { id_loainv = 1 });
                }
            }

            if ((int)model.Select(m => m.ID_LOAINHANVIEN).SingleOrDefault() != 0)
            {
                ViewBag.LoaiNV = "Nhân viên";              
            }
            else
            {
                ViewBag.LoaiNV = "Cộng tác viên";              
            }
            setDDlistLoaiNhanVien_All();
            return View(nv);
            

        }

        public ActionResult CreateNhanVien(int id_loainv)
        {
            if (id_loainv == 0)
            {
                ViewBag.LoaiNV = "Nhân viên";
            }
            else
            {
                ViewBag.LoaiNV = "Cộng tác viên";
            }
            setDDlistLoaiNhanVien();
            return View();
               
        }

        [HttpPost]      
        public ActionResult CreateNhanVien(int id_loainv,NhanVien nv)
        {
           
            DA_Web.Models.Table_NHANVIEN tb_nv = new DA_Web.Models.Table_NHANVIEN();
            tb_nv.HoTen = nv.HoTen;
            tb_nv.GioiTinh = nv.GioiTinh;
            tb_nv.SDT = nv.SDT;
            tb_nv.Username = nv.Username;
            tb_nv.Password = Str_Encoder(nv.Password);
            tb_nv.Skype = nv.Skype;
            tb_nv.TKBank = nv.TKBank;
            tb_nv.Diachi = nv.Diachi;
            tb_nv.Email = nv.Email;
            tb_nv.ANHDAIDIEN = nv.ANHDAIDIEN;
            tb_nv.ID_LOAINHANVIEN = nv.ID_LOAINHANVIEN;
            if (ModelState.IsValid)
            {
                if (id_loainv == 0)
                {
                    ViewBag.LoaiNV = "Nhân viên";
                    setDDlistLoaiNhanVien_All();
                    data.Table_NHANVIENs.InsertOnSubmit(tb_nv);
                    data.SubmitChanges();
                    return RedirectToAction("DanhSach", "User", new { id_loainv = 0 });
                }
                else
                {
                    ViewBag.LoaiNV = "Cộng tác viên";
                    tb_nv.ID_LOAINHANVIEN = 0;
                    data.Table_NHANVIENs.InsertOnSubmit(tb_nv);
                    data.SubmitChanges();
                    return RedirectToAction("DanhSach", "User", new { id_loainv = 1 });
                }
            }
          
                if (id_loainv == 0)
                {
                    ViewBag.LoaiNV = "Nhân viên";
                }
                else
                {
                    ViewBag.LoaiNV = "Cộng tác viên";
                }
                setDDlistLoaiNhanVien_All();
                return View(nv);
            
        }

        public string ProcessUpload(HttpPostedFileBase file)
        {
            file.SaveAs(Server.MapPath("/Content/image/" + file.FileName));
            return "/Content/image/" + file.FileName;
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new XuLyDAO().DeleteNhanVien(id);
            int model = (int)(from a in data.Table_NHANVIENs where a.ID_NHANVIEN == id select a.ID_LOAINHANVIEN).SingleOrDefault();
            if (model != 0)
            {
                return RedirectToAction("DanhSach", "User", new { id_loainv = 0 });
            }
            else
            {
                return RedirectToAction("DanhSach", "User", new { id_loainv = 1 });
            }

        }

        //Chức vụ
        public ActionResult ChucVu()
        {
            var model = NhanVienDAO.getChucVu();
            return View(model);
        }

        [HttpDelete]
        public ActionResult DeleteLoaiNV(int id_loainv)
        {
            new XuLyDAO().DeleteChucVu(id_loainv);
            return View();

        }

        public ActionResult CreateChucVu()
        {         
            return View();
        }
        [HttpPost]
        public ActionResult CreateChucVu(LoaiNV loai_nv)
        {
            bool tontaiChucvu = data.Table_LOAINHANVIENs.Any(m => m.Tenloainhanvien == loai_nv.Tenloainhanvien);
            if (tontaiChucvu)
            {
                ModelState.AddModelError("Tenloainhanvien", "Chức vụ này đã tồn tại");
            }
            if (ModelState.IsValid)
            {
                DA_Web.Models.Table_LOAINHANVIEN tb_loai = new Table_LOAINHANVIEN();
                tb_loai.Tenloainhanvien = loai_nv.Tenloainhanvien;
                data.Table_LOAINHANVIENs.InsertOnSubmit(tb_loai);
                data.SubmitChanges();
                return RedirectToAction("ChucVu");
            }         
            return View();
        }

        public ActionResult EditChucVu(int id_loainv)
        {
            var model = NhanVienDAO.getChucVu_byID_loai(id_loainv);
            return View(model.Single());
        }

        [HttpPost]
        public ActionResult EditChucVu(int id_loainv,LoaiNV loai_nv)
        {
            bool tontaiChucvu = data.Table_LOAINHANVIENs.Any(m => m.Tenloainhanvien == loai_nv.Tenloainhanvien && m.ID_LOAINHANVIEN != id_loainv);
            if (tontaiChucvu)
            {
                ModelState.AddModelError("Tenloainhanvien", "Chức vụ này đã tồn tại");
            }
            if (ModelState.IsValid)
            {
                var model = data.Table_LOAINHANVIENs.First(m => m.ID_LOAINHANVIEN == id_loainv);
                model.Tenloainhanvien = loai_nv.Tenloainhanvien;
                data.SubmitChanges();
                return RedirectToAction("ChucVu");
            }         
            return View();
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