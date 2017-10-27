using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class RoleButtonController : BaseController
    {
        // GET: RoleButton
        public ActionResult Index()
        {
            IList<Model.RoleButton> lmrb = new List<Model.RoleButton>();
            IList<KeyValuePair<string, object>> condition = new List<KeyValuePair<string, object>>();
            condition.Add(new KeyValuePair<string, object>("rbId", LoginUserInfo.RoleButtons));

            LIB.PageModel lpm = new LIB.PageModel();

            lmrb = LIB.MoreTermSelect.MoreTerm<Model.RoleButton>(condition, "RoleButton", ref lpm);


            ViewData["lmrb"] = lmrb;
            return View();
        }
    }
}