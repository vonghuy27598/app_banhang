using DA_Web.XuLy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using DA_Web.Models;
using DA_Web.Areas.Admin.Controllers;

namespace DA_Web.Controllers
{
    public class ThuongHieuController : AKMLController
    {
        //
        // GET: /ThuongHieu/
        public ActionResult Hunter(string id, int? page)
        {
            int pageSize = 6;
            //Tạo biến số trang
            int pageNum = (page ?? 1);
            string sort = Request.QueryString["sort"];
            dbQL_BanHangDataContext db = new dbQL_BanHangDataContext();
            int getID_loaiParent = (from a in db.Table_LOAISANPHAMs where a.TenLoaiSanPham == id select a.ID_LOAISANPHAM).SingleOrDefault();
            var model2 = SanPham.Product_Full_byNAMEGROUP_child(id);
            var getSanPham_byIDLOAI_PARENT = SanPham.Product_Full_byNAMEGROUP_parent(getID_loaiParent);
            ViewBag.thuonghieu = id;
            if (SanPham.getParent(id))
            {
                switch (sort)
                {
                    case "0":
                        ViewBag.soluong = getSanPham_byIDLOAI_PARENT.Count();
                        List<SelectListItem> list_sort = new List<SelectListItem>();
                        list_sort.Add(new SelectListItem { Text = "Giá từ thấp đến cao", Value = "0", Selected = true });
                        list_sort.Add(new SelectListItem { Text = "Giá từ cao đến thấp", Value = "1" });
                        list_sort.Add(new SelectListItem { Text = "Xếp theo chữ cái từ A - Z", Value = "2" });
                        list_sort.Add(new SelectListItem { Text = "Xếp theo chữ cái từ Z - A", Value = "3" });
                        ViewBag.listsort = list_sort;

                        return View(getSanPham_byIDLOAI_PARENT.OrderBy(m => m.DonGia).ToList().ToPagedList(pageNum, pageSize));
                        break;
                    case "1":
                        ViewBag.soluong = getSanPham_byIDLOAI_PARENT.Count();
                        List<SelectListItem> list_sort1 = new List<SelectListItem>();
                        list_sort1.Add(new SelectListItem { Text = "Giá từ thấp đến cao", Value = "0" });
                        list_sort1.Add(new SelectListItem { Text = "Giá từ cao đến thấp", Value = "1", Selected = true });
                        list_sort1.Add(new SelectListItem { Text = "Xếp theo chữ cái từ A - Z", Value = "2" });
                        list_sort1.Add(new SelectListItem { Text = "Xếp theo chữ cái từ Z - A", Value = "3" });
                        ViewBag.listsort = list_sort1;
                        return View(getSanPham_byIDLOAI_PARENT.OrderByDescending(m => m.DonGia).ToList().ToPagedList(pageNum, pageSize));
                        break;
                    case "2":
                        ViewBag.soluong = getSanPham_byIDLOAI_PARENT.Count();
                        List<SelectListItem> list_sort2 = new List<SelectListItem>();
                        list_sort2.Add(new SelectListItem { Text = "Giá từ thấp đến cao", Value = "0" });
                        list_sort2.Add(new SelectListItem { Text = "Giá từ cao đến thấp", Value = "1" });
                        list_sort2.Add(new SelectListItem { Text = "Xếp theo chữ cái từ A - Z", Value = "2", Selected = true });
                        list_sort2.Add(new SelectListItem { Text = "Xếp theo chữ cái từ Z - A", Value = "3" });
                        ViewBag.listsort = list_sort2;
                        return View(getSanPham_byIDLOAI_PARENT.OrderBy(m => m.TenSanPham).ToList().ToPagedList(pageNum, pageSize));
                        break;
                    case "3":
                        ViewBag.soluong = getSanPham_byIDLOAI_PARENT.Count();
                        List<SelectListItem> list_sort3 = new List<SelectListItem>();
                        list_sort3.Add(new SelectListItem { Text = "Giá từ thấp đến cao", Value = "0" });
                        list_sort3.Add(new SelectListItem { Text = "Giá từ cao đến thấp", Value = "1" });
                        list_sort3.Add(new SelectListItem { Text = "Xếp theo chữ cái từ A - Z", Value = "2" });
                        list_sort3.Add(new SelectListItem { Text = "Xếp theo chữ cái từ Z - A", Value = "3", Selected = true });
                        ViewBag.listsort = list_sort3;
                        return View(getSanPham_byIDLOAI_PARENT.OrderByDescending(m => m.TenSanPham).ToList().ToPagedList(pageNum, pageSize));
                        break;
                    default:

                        ViewBag.soluong = getSanPham_byIDLOAI_PARENT.Count();
                        List<SelectListItem> list_sort5 = new List<SelectListItem>();
                        list_sort5.Add(new SelectListItem { Text = "Giá từ thấp đến cao", Value = "0" });
                        list_sort5.Add(new SelectListItem { Text = "Giá từ cao đến thấp", Value = "1" });
                        list_sort5.Add(new SelectListItem { Text = "Xếp theo chữ cái từ A - Z", Value = "2" });
                        list_sort5.Add(new SelectListItem { Text = "Xếp theo chữ cái từ Z - A", Value = "3" });
                        ViewBag.listsort = list_sort5;
                        return View(getSanPham_byIDLOAI_PARENT.ToList().ToPagedList(pageNum, pageSize));
                        break;
                }
            }
            else
            {
                switch (sort)
                {
                    case "0":
                        ViewBag.soluong = getSanPham_byIDLOAI_PARENT.Count();
                        List<SelectListItem> list_sort = new List<SelectListItem>();
                        list_sort.Add(new SelectListItem { Text = "Giá từ thấp đến cao", Value = "0", Selected = true });
                        list_sort.Add(new SelectListItem { Text = "Giá từ cao đến thấp", Value = "1" });
                        list_sort.Add(new SelectListItem { Text = "Xếp theo chữ cái từ A - Z", Value = "2" });
                        list_sort.Add(new SelectListItem { Text = "Xếp theo chữ cái từ Z - A", Value = "3" });
                        ViewBag.listsort = list_sort;

                        return View(model2.OrderBy(m => m.DonGia).ToList().ToPagedList(pageNum, pageSize));
                        break;
                    case "1":
                        ViewBag.soluong = getSanPham_byIDLOAI_PARENT.Count();
                        List<SelectListItem> list_sort1 = new List<SelectListItem>();
                        list_sort1.Add(new SelectListItem { Text = "Giá từ thấp đến cao", Value = "0" });
                        list_sort1.Add(new SelectListItem { Text = "Giá từ cao đến thấp", Value = "1", Selected = true });
                        list_sort1.Add(new SelectListItem { Text = "Xếp theo chữ cái từ A - Z", Value = "2" });
                        list_sort1.Add(new SelectListItem { Text = "Xếp theo chữ cái từ Z - A", Value = "3" });
                        ViewBag.listsort = list_sort1;
                        return View(model2.OrderByDescending(m => m.DonGia).ToList().ToPagedList(pageNum, pageSize));
                        break;
                    case "2":
                        ViewBag.soluong = getSanPham_byIDLOAI_PARENT.Count();
                        List<SelectListItem> list_sort2 = new List<SelectListItem>();
                        list_sort2.Add(new SelectListItem { Text = "Giá từ thấp đến cao", Value = "0" });
                        list_sort2.Add(new SelectListItem { Text = "Giá từ cao đến thấp", Value = "1" });
                        list_sort2.Add(new SelectListItem { Text = "Xếp theo chữ cái từ A - Z", Value = "2", Selected = true });
                        list_sort2.Add(new SelectListItem { Text = "Xếp theo chữ cái từ Z - A", Value = "3" });
                        ViewBag.listsort = list_sort2;
                        return View(model2.OrderBy(m => m.TenSanPham).ToList().ToPagedList(pageNum, pageSize));
                        break;
                    case "3":
                        ViewBag.soluong = getSanPham_byIDLOAI_PARENT.Count();
                        List<SelectListItem> list_sort3 = new List<SelectListItem>();
                        list_sort3.Add(new SelectListItem { Text = "Giá từ thấp đến cao", Value = "0" });
                        list_sort3.Add(new SelectListItem { Text = "Giá từ cao đến thấp", Value = "1" });
                        list_sort3.Add(new SelectListItem { Text = "Xếp theo chữ cái từ A - Z", Value = "2" });
                        list_sort3.Add(new SelectListItem { Text = "Xếp theo chữ cái từ Z - A", Value = "3", Selected = true });
                        ViewBag.listsort = list_sort3;
                        return View(model2.OrderByDescending(m => m.TenSanPham).ToList().ToPagedList(pageNum, pageSize));
                        break;
                    default:

                        ViewBag.soluong = getSanPham_byIDLOAI_PARENT.Count();
                        List<SelectListItem> list_sort5 = new List<SelectListItem>();
                        list_sort5.Add(new SelectListItem { Text = "Giá từ thấp đến cao", Value = "0" });
                        list_sort5.Add(new SelectListItem { Text = "Giá từ cao đến thấp", Value = "1" });
                        list_sort5.Add(new SelectListItem { Text = "Xếp theo chữ cái từ A - Z", Value = "2" });
                        list_sort5.Add(new SelectListItem { Text = "Xếp theo chữ cái từ Z - A", Value = "3" });
                        ViewBag.listsort = list_sort5;
                        return View(model2.ToList().ToPagedList(pageNum, pageSize));
                        break;
                }
            }




        }
    }
}