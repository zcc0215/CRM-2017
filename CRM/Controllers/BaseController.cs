using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 登陆用户信息
        /// </summary>
        public Model.CRMUser LoginUserInfo { get; set; }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["UserInfo"] == null)
                filterContext.Result = RedirectToAction("Index", "Login");
            else
                LoginUserInfo = filterContext.HttpContext.Session["UserInfo"] as Model.CRMUser;

            base.OnActionExecuting(filterContext);
        }
    }
}