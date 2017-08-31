using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class DepartController : BaseController
    {
        // GET: Depart
        public ActionResult Index()
        {
            IList<Model.Depart> lmd = new List<Model.Depart>();
            IList<KeyValuePair<string, object>> condition = new List<KeyValuePair<string, object>>();
            LIB.PageModel lpm = new LIB.PageModel();
            lmd = LIB.MoreTermSelect.MoreTerm<Model.Depart>(condition, "Depart", ref lpm);
            ViewData["lmd"] = lmd;
            return View();
        }
        /// <summary>
        /// 添加部门
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(Model.Depart md)
        {
            bool issuccess = BLL.CommonBLL.add<Model.Depart>(md);
            var ret = new
            {
                messagecode = issuccess ? 1 : 0,
            };
            return Json(ret, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除部门
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(Model.Depart md)
        {
            int flag = -1;

            #region 判断部门下是否存在员工
            IList<Model.CRMUser> lmcu = new List<Model.CRMUser>();
            IList<KeyValuePair<string, object>> condition = new List<KeyValuePair<string, object>>();
            condition.Add(new KeyValuePair<string, object>("ufkDepart", md.hrdId));
            LIB.PageModel lpm = new LIB.PageModel();
            lmcu = LIB.MoreTermSelect.MoreTerm<Model.CRMUser>(condition, "CRMUser", ref lpm);
            #endregion

            if(lmcu.Count==0)
            {
                bool issuccess = BLL.CommonBLL.Delete<Model.Depart>(md);
                flag = issuccess ? 1 : 0;
            }
            
            var ret = new
            {
                messagecode = flag
            };
            return Json(ret, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 编辑部门
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update(Model.Depart md)
        {
            bool issuccess = BLL.CommonBLL.Update<Model.Depart>(md);
            var ret = new
            {
                messagecode = issuccess ? 1 : 0,
            };
            return Json(ret, JsonRequestBehavior.AllowGet);
        }
    }
}