using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace CRM.Controllers
{
    public class ClueManageController : BaseController
    {
        public ClueManageController()
        {
            this.ImportModleFile = "市场部-销售线索.xlsx";
        }
        // GET: ClueManage
        public ActionResult Index(int? PageCount = 1, int? PageSize = 5, string cmCustomerName = "", string cmPhone = "")
        {
            IList<Model.ClueManage> lmcm = new List<Model.ClueManage>();
            IList<KeyValuePair<string, object>> condition = new List<KeyValuePair<string, object>>();

            #region  查询条件
            if (!string.IsNullOrWhiteSpace(cmCustomerName))
            {
                condition.Add(new KeyValuePair<string, object>("cmCustomerName", cmCustomerName));
            }
            if (!string.IsNullOrWhiteSpace(cmPhone))
            {
                condition.Add(new KeyValuePair<string, object>("cmPhone", cmPhone));
            }
            #endregion

            LIB.PageModel lpm = new LIB.PageModel();
            lpm.fldName = "cmId";
            lpm.PageCount = PageCount.Value;
            lpm.PageSize = PageSize.Value;
            lmcm = LIB.MoreTermSelect.MoreTerm<Model.ClueManage>(condition, "ClueManage", ref lpm);

            PagedList<Model.ClueManage> pagems = new PagedList<Model.ClueManage>(lmcm, PageCount.Value, PageSize.Value, lpm.TotalCount);
            ViewData["pagems"] = pagems;

            #region 搜索字段在页面中显示
            ViewBag.cmCustomerName = cmCustomerName;
            ViewBag.cmPhone = cmPhone;
            ViewBag.excelName = this.ImportModleFile;
            #endregion
            return View();
        }
    }
}