using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace CRM.Controllers
{
    public class OrderManageController : BaseController
    {
        // GET: OrderManage
        public ActionResult Index(int? PageCount = 1, int? PageSize = 1)
        {
            IList<Model.OrderManage> lmo = new List<Model.OrderManage>();

            IList<KeyValuePair<string, object>> condition = new List<KeyValuePair<string, object>>();

            LIB.PageModel lpm = new LIB.PageModel();
            lpm.fldName = "omId";
            lpm.PageCount = PageCount.Value;
            lpm.PageSize = PageSize.Value;

            lmo = LIB.MoreTermSelect.MoreTerm<Model.OrderManage>(condition, "OrderManage.omId,ContractManage.cmfkomId", ref lpm);

            PagedList<Model.OrderManage> pagems = new PagedList<Model.OrderManage>(lmo, PageCount.Value, PageSize.Value, lpm.TotalCount);

            ViewData["pagems"] = pagems;
            return View();
        }
    }
}