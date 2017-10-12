using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace CRM.Controllers
{
    public class BusiChanceController : Controller
    {
        // GET: BusiChance
        public ActionResult Index(int? PageCount = 1, int? PageSize = 1)
        {
            IList<Model.BusiChance> lmb = new List<Model.BusiChance>();

            IList<KeyValuePair<string, object>> condition = new List<KeyValuePair<string, object>>();

            LIB.PageModel lpm = new LIB.PageModel();
            lpm.fldName = "bcId";
            lpm.PageCount = PageCount.Value;
            lpm.PageSize = PageSize.Value;

            lmb = LIB.MoreTermSelect.MoreTerm<Model.BusiChance>(condition, "BusiChance.bcId,OrderManage.omfkbcId", ref lpm);

            PagedList<Model.BusiChance> pagems = new PagedList<Model.BusiChance>(lmb, PageCount.Value, PageSize.Value, lpm.TotalCount);

            ViewData["pagems"] = pagems;
            return View();
        }
        [HttpPost]
        public ActionResult UpdateBusiChance(Model.BusiChance mb)
        {
            bool success = BLL.CommonBLL.ExecByProc<Model.BusiChance>(mb);

            var ret = new
            {
                messagecode = success ? 1 : 0
            };

            return Json(ret, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddOrder(Model.OrderManage mo)
        {
            bool success = BLL.CommonBLL.add<Model.OrderManage>(mo);
            var ret = new
            {
                messagecode = success ? 1 : 0
            };

            return Json(ret, JsonRequestBehavior.AllowGet);
        }
    }
}