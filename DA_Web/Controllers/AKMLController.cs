using DA_Web.Models;
using DA_Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DA_Web.Areas.Admin.Controllers
{
    public class AKMLController : Controller
    {
        //
        // GET: /Admin/Base/
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = Session["Check"];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index", Area = "Admin" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}