using DA_Web.Models;
using DA_Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA_Web.Areas.Admin.Models
{
    public class NhaCungCapDAO
    {
        dbQL_BanHangDataContext data = new dbQL_BanHangDataContext();
        public List<NhaSX> listNhaCungCap()
        {
            var model = from a in data.Table_NhaSXes
                        select new NhaSX()
                        {
                          ID_NSX = a.ID_NSX,
                          NoiSX = a.NoiSX,
                          NHASX = a.NhaSX,
                        }
                ;
            return model.OrderBy(m => m.ID_NSX).ToList();
        }
      
    }
}