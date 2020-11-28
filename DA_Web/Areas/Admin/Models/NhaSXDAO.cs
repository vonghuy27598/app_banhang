using System;
using System.Collections.Generic;
using System.Linq;
using DA_Web.Models;
using System.Web;
using DA_Web.ViewModel;

namespace DA_Web.Areas.Admin.Models
{
    public class NhaSXDAO
    {
        public static dbQL_BanHangDataContext db = new dbQL_BanHangDataContext();

        public static List<NhaSX> getNhaSX(){
            var model = from a in db.Table_NhaSXes
                        select new NhaSX(){
                            ID_NSX = a.ID_NSX,
                            NHASX = a.NhaSX,
                            NoiSX = a.NoiSX
            };
            return model.OrderBy(m=>m.ID_NSX).ToList();
        }
    }
}