using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace CRM.Controllers
{
    public class TargetCustomersController : BaseController
    {
        // GET: TargetCustomers
        public ActionResult Index(int? PageCount = 1, int? PageSize = 5,string tcName ="",string tcPhone="")
        {
            IList<Model.TargetCustomers> lmtc = new List<Model.TargetCustomers>();
            IList<KeyValuePair<string, object>> condition = new List<KeyValuePair<string, object>>();

            #region  查询条件
            if (!string.IsNullOrWhiteSpace(tcName))
            {
                condition.Add(new KeyValuePair<string, object>("tcName", tcName));
            }
            if (!string.IsNullOrWhiteSpace(tcPhone))
            {
                condition.Add(new KeyValuePair<string, object>("tcPhone", tcPhone));
            }
            #endregion

            LIB.PageModel lpm = new LIB.PageModel();
            lpm.fldName = "tcId";
            lpm.PageCount = PageCount.Value;
            lpm.PageSize = PageSize.Value;
            lmtc = LIB.MoreTermSelect.MoreTerm<Model.TargetCustomers>(condition, "TargetCustomers", ref lpm);

            PagedList<Model.TargetCustomers> pagems = new PagedList<Model.TargetCustomers>(lmtc, PageCount.Value, PageSize.Value, lpm.TotalCount);
            ViewData["pagems"] = pagems;

            #region 搜索字段在页面中显示
            ViewBag.tcName = tcName;
            ViewBag.tcPhone = tcPhone;
            #endregion

            return View();
        }
    }
}