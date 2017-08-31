using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace CRM.Controllers
{
    public class ActivityAssignManageController : BaseController
    {
        // GET: ActivityAssignManage
        public ActionResult Index(int? PageCount = 1, int? PageSize = 5, string amName = "", int? amResult = -1,string amBeginTime ="",string amEndTime = "")
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

            #region 起止时间
            if (!string.IsNullOrEmpty(amBeginTime) && string.IsNullOrEmpty(amEndTime))
            {
                condition.Add(new KeyValuePair<string, object>("amBeginTime", ">='" + amBeginTime + "'"));
            }
            if (string.IsNullOrEmpty(amBeginTime) && !string.IsNullOrEmpty(amEndTime))
            {
                condition.Add(new KeyValuePair<string, object>("amEndTime", "<='" + amEndTime + "'"));
            }
            if (!string.IsNullOrEmpty(amBeginTime) && !string.IsNullOrEmpty(amEndTime))
            {
                condition.Add(new KeyValuePair<string, object>("amBeginTime", ">='" + amBeginTime + "'"));
                condition.Add(new KeyValuePair<string, object>("amEndTime", "<='" + amEndTime + "'"));
            }
            #endregion

            condition.Add(new KeyValuePair<string, object>("amfkRole", LoginUserInfo.ufkRole.Value));
            #endregion

            LIB.PageModel lpm = new LIB.PageModel();
            lpm.fldName = "amid";
            lpm.PageCount = PageCount.Value;
            lpm.PageSize = PageSize.Value;
            lmam = LIB.MoreTermSelect.MoreTerm<Model.ActivityManage>(condition, "ActivityManage.amfkRole,Role.rId", ref lpm);

            PagedList<Model.ActivityManage> pagems = new PagedList<Model.ActivityManage>(lmam, PageCount.Value, PageSize.Value, lpm.TotalCount);
            ViewData["pagems"] = pagems;

            #region 搜索字段在页面中显示
            ViewBag.amName = amName;
            ViewBag.amResult = amResult;
            ViewBag.amBeginTime = amBeginTime;
            ViewBag.amEndTime = amEndTime;
            #endregion

            return View();
        }
        public ActionResult Assign(int Id,int? PageCount = 1, int? PageSize = 5)
        {
            IList<Model.ActivityAssignManage> lmaa = new List<Model.ActivityAssignManage>();
            IList<KeyValuePair<string, object>> condition = new List<KeyValuePair<string, object>>();
            condition.Add(new KeyValuePair<string, object>("aafkamId", Id));
            LIB.PageModel lpm = new LIB.PageModel();
            lmaa = LIB.MoreTermSelect.MoreTerm<Model.ActivityAssignManage>(condition, "ActivityAssignManage.aafkRole,Role.rId", ref lpm);
            condition.Clear();

            PagedList<Model.ActivityAssignManage> pagems = new PagedList<Model.ActivityAssignManage>(lmaa, PageCount.Value, PageSize.Value, lpm.TotalCount);
            ViewData["pagems"] = pagems;

            #region 获取角色
            IList<Model.Role> lmr = new List<Model.Role>();
            LIB.PageModel lpmRole = new LIB.PageModel();
            lmr = LIB.MoreTermSelect.MoreTerm<Model.Role>(condition, "Role", ref lpmRole);
            ViewData["lmr"] = lmr;
            #endregion

            ViewBag.aafkamId = Id;
            return View();
        }
        /// <summary>
        /// 添加任务
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Age"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(Model.ActivityAssignManage aa)
        {
            bool issuccess = BLL.CommonBLL.add<Model.ActivityAssignManage>(aa);
            var ret = new
            {
                messagecode = issuccess ? 1 : 0,
            };

            return Json(ret, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除任务
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(Model.ActivityAssignManage aa)
        {
            bool issuccess = BLL.CommonBLL.Delete<Model.ActivityAssignManage>(aa);
            var ret = new
            {
                messagecode = issuccess ? 1 : 0,
            };
            return Json(ret, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 编辑任务信息
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Model.ActivityAssignManage aa)
        {
            bool issuccess = BLL.CommonBLL.Update<Model.ActivityAssignManage>(aa);
            var ret = new
            {
                messagecode = issuccess ? 1 : 0,
            };

            return Json(ret, JsonRequestBehavior.AllowGet);
        }
    }
}