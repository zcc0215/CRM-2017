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
        public ActionResult Index(int? PageCount = 1, int? PageSize = 5, string cmCustomerName = "", string cmPhone = "",int? cmfkRole = -1)
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
            if(cmfkRole!=-1)
            {
                condition.Add(new KeyValuePair<string, object>("cmfkRole", cmfkRole));
            }
            #endregion

            LIB.PageModel lpm = new LIB.PageModel();
            lpm.fldName = "cmId";
            lpm.PageCount = PageCount.Value;
            lpm.PageSize = PageSize.Value;
            lmcm = LIB.MoreTermSelect.MoreTerm<Model.ClueManage>(condition, "ClueManage.cmfkRole,Role.rId", ref lpm);
            condition.Clear();

            PagedList<Model.ClueManage> pagems = new PagedList<Model.ClueManage>(lmcm, PageCount.Value, PageSize.Value, lpm.TotalCount);
            ViewData["pagems"] = pagems;

            #region 获取角色
            IList<Model.Role> lmr = new List<Model.Role>();
            LIB.PageModel lpmRole = new LIB.PageModel();
            lmr = LIB.MoreTermSelect.MoreTerm<Model.Role>(condition, "Role", ref lpmRole);
            ViewData["lmr"] = lmr;
            #endregion

            #region 搜索字段在页面中显示
            ViewBag.cmCustomerName = cmCustomerName;
            ViewBag.cmPhone = cmPhone;
            ViewBag.excelName = this.ImportModleFile;
            ViewBag.cmfkRole = cmfkRole;
            #endregion
            return View();
        }
        /// <summary>
        /// 编辑线索责任人
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Model.ClueManage cm)
        {
            bool issuccess = BLL.CommonBLL.Update<Model.ClueManage>(cm);
            var ret = new
            {
                messagecode = issuccess ? 1 : 0,
            };

            return Json(ret, JsonRequestBehavior.AllowGet);
        }
    }
}