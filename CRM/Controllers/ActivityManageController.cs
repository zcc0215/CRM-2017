using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace CRM.Controllers
{
    public class ActivityManageController : Controller
    {
        // GET: ActivityManage
        public ActionResult Index(int? PageCount = 1, int? PageSize = 5,string amName="",int? amResult=-1,int? amfkRole=-1)
        {
            
            IList<Model.ActivityManage> lmam = new List<Model.ActivityManage>();
            IList<KeyValuePair<string, object>> condition = new List<KeyValuePair<string, object>>();

            #region 查询条件
            if (!string.IsNullOrWhiteSpace(amName))
            {
                condition.Add(new KeyValuePair<string, object>("amName", amName));
            }
            if (amResult != null && amResult != -1)
            {
                condition.Add(new KeyValuePair<string, object>("amResult", amResult));
            }
            if (amfkRole != null && amfkRole != -1)
            {
                condition.Add(new KeyValuePair<string, object>("amfkRole", amfkRole));
            }
#           endregion

            LIB.PageModel lpm = new LIB.PageModel();
            lpm.fldName = "amid";
            lpm.PageCount = PageCount.Value;
            lpm.PageSize = PageSize.Value;
            lmam = LIB.MoreTermSelect.MoreTerm<Model.ActivityManage>(condition, "ActivityManage.amfkRole,Role.rId", ref lpm);
            condition.Clear();

            PagedList<Model.ActivityManage> pagems = new PagedList<Model.ActivityManage>(lmam, PageCount.Value, PageSize.Value, lpm.TotalCount);
            ViewData["pagems"] = pagems;

            #region 获取角色
            IList<Model.Role> lmr = new List<Model.Role>();
            LIB.PageModel lpmRole = new LIB.PageModel();
            lmr = LIB.MoreTermSelect.MoreTerm<Model.Role>(condition, "Role", ref lpmRole);
            ViewData["lmr"] = lmr;
            #endregion

            #region 搜索字段在页面中显示
            ViewBag.amName = amName;
            ViewBag.amResult = amResult;
            ViewBag.amfkRole = amfkRole;
            #endregion

            return View();
        }
        /// <summary>
        /// 添加活动
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Age"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(Model.ActivityManage am)
        {
            bool issuccess = BLL.CommonBLL.add<Model.ActivityManage>(am);
            var ret = new
            {
                messagecode = issuccess ? 1 : 0,
            };

            return Json(ret, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除活动
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(Model.ActivityManage am)
        {
            bool issuccess = BLL.CommonBLL.Delete<Model.ActivityManage>(am);
            var ret = new
            {
                messagecode = issuccess ? 1 : 0,
            };
            return Json(ret, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 编辑活动信息
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Model.ActivityManage am)
        {
            bool issuccess = BLL.CommonBLL.Update<Model.ActivityManage>(am);
            var ret = new
            {
                messagecode = issuccess ? 1 : 0,
            };

            return Json(ret, JsonRequestBehavior.AllowGet);
        }
    }
}