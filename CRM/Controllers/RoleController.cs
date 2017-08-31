using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class RoleController : BaseController
    {
        // GET: Role
        public ActionResult Index()
        {
            IList<Model.Role> lmr = new List<Model.Role>();
            IList<Model.RoleButton> lmrb = new List<Model.RoleButton>();
            IList<KeyValuePair<string, object>> condition = new List<KeyValuePair<string, object>>();
            LIB.PageModel lpm = new LIB.PageModel();
            lmr = LIB.MoreTermSelect.MoreTerm<Model.Role>(condition, "Role", ref lpm);
            lmrb = LIB.MoreTermSelect.MoreTerm<Model.RoleButton>(condition, "RoleButton", ref lpm);
            ViewData["lmr"] = lmr;
            ViewData["lmrb"] = lmrb;
            return View();
        }
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(Model.Role mr)
        {
            bool issuccess = BLL.CommonBLL.add<Model.Role>(mr);
            var ret = new
            {
                messagecode = issuccess ? 1 : 0,
            };
            return Json(ret, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(Model.Role mr)
        {
            int flag = -1;

            #region 判断角色下是否存在员工
            IList<Model.CRMUser> lmcu = new List<Model.CRMUser>();
            IList<KeyValuePair<string, object>> condition = new List<KeyValuePair<string, object>>();
            condition.Add(new KeyValuePair<string, object>("ufkRole", mr.rId));
            LIB.PageModel lpm = new LIB.PageModel();
            lmcu = LIB.MoreTermSelect.MoreTerm<Model.CRMUser>(condition, "CRMUser", ref lpm);
            #endregion

            if (lmcu.Count == 0)
            {
                bool issuccess = BLL.CommonBLL.Delete<Model.Role>(mr);
                flag = issuccess ? 1 : 0;
            }
            var ret = new
            {
                messagecode = flag
            };
            return Json(ret, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 编辑角色
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update(Model.Role mr)
        {
            bool issuccess = BLL.CommonBLL.Update<Model.Role>(mr);
            var ret = new
            {
                messagecode = issuccess ? 1 : 0,
            };
            return Json(ret, JsonRequestBehavior.AllowGet);
        }
    }
}