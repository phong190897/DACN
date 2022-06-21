using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThiTracNghiem.Areas.Admin.Code;

namespace WebThiTracNghiem.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (UserSession)Session[Constance.Constance.USER_SESSION];

            if(session == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(new { controller = "Login", action = "Index", Area = "Admin" }));
            }    

            base.OnActionExecuting(filterContext);
        }
    }
}