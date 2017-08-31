using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace CRM.Controllers
{
    public class CRMUserController : BaseController
    {
        // GET: CRMUser
        public ActionResult Index(int? PageCount = 1, int? PageSize = 5,string Username ="",int? ufkDepart =-1,int? ufkRole=-1)
        {
            IList<Model.CRMUser> lmcu = new List<Model.CRMUser>();
            IList<KeyValuePair<string, object>> condition = new List<KeyValuePair<string, object>>();

            #region 查询条件
            if(!string.IsNullOrWhiteSpace(Username))
            {
                condition.Add(new KeyValuePair<string, object>("Username", Username));
            }
            if (ufkDepart != null && ufkDepart != -1)
            {
                condition.Add(new KeyValuePair<string, object>("ufkDepart", ufkDepart));
            }
            if (ufkRole != null && ufkRole != -1)
            {
                condition.Add(new KeyValuePair<string, object>("ufkRole", ufkRole));
            }
            #endregion

            LIB.PageModel lpm = new LIB.PageModel();
            lpm.fldName = "uid";
            lpm.PageCount = PageCount.Value;
            lpm.PageSize = PageSize.Value;
            lmcu = LIB.MoreTermSelect.MoreTerm<Model.CRMUser>(condition, "CRMUser.ufkDepart,Depart.hrdId,CRMUser.ufkRole,Role.rId", ref lpm);
            condition.Clear();

            PagedList<Model.CRMUser> pagems = new PagedList<Model.CRMUser>(lmcu, PageCount.Value, PageSize.Value, lpm.TotalCount);
            ViewData["pagems"] = pagems;
            
            #region 获取部门
            IList<Model.Depart> lmd = new List<Model.Depart>();
            LIB.PageModel lpmDepart = new LIB.PageModel();
            lmd = LIB.MoreTermSelect.MoreTerm<Model.Depart>(condition, "Depart", ref lpmDepart);
            ViewData["lmd"] = lmd;
            #endregion

            #region 获取角色
            IList<Model.Role> lmr = new List<Model.Role>();
            LIB.PageModel lpmRole = new LIB.PageModel();
            lmr = LIB.MoreTermSelect.MoreTerm<Model.Role>(condition, "Role", ref lpmRole);
            ViewData["lmr"] = lmr;
            #endregion

            #region 搜索字段在页面中显示
            ViewBag.Username = Username;
            ViewBag.ufkDepart = ufkDepart;
            ViewBag.ufkRole = ufkRole;
            #endregion

            return View();
        }
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Age"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(Model.CRMUser mc)
        {
            int flag = -1;

            #region 检查是否已有重名员工
            IList<Model.CRMUser> lmcu = new List<Model.CRMUser>();
            IList<KeyValuePair<string, object>> condition = new List<KeyValuePair<string, object>>();
            condition.Add(new KeyValuePair<string, object>("Username", mc.Username));
            LIB.PageModel lpm = new LIB.PageModel();
            lmcu = LIB.MoreTermSelect.MoreTerm<Model.CRMUser>(condition, "CRMUser", ref lpm);
            #endregion

            #region 保存密码MD5
            mc.Password = LIB.MD5.GetMD5(mc.Password);
            #endregion

            if (lmcu.Count==0)
            {
                bool issuccess = BLL.CommonBLL.add<Model.CRMUser>(mc);
                flag = issuccess ? 1 : 0;
            }
            
            var ret = new
            {
                messagecode = flag
            };

            return Json(ret, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(Model.CRMUser mc)
        {
            bool issuccess = BLL.CommonBLL.Delete<Model.CRMUser>(mc);
            var ret = new
            {
                messagecode = issuccess ? 1 : 0,
            };
            return Json(ret, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 编辑员工信息
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Model.CRMUser mc)
        {
            #region 保存密码MD5
            mc.Password = LIB.MD5.GetMD5(mc.Password);
            #endregion

            bool issuccess = BLL.CommonBLL.Update<Model.CRMUser>(mc);
            var ret = new
            {
                messagecode = issuccess ? 1 : 0,
            };

            return Json(ret, JsonRequestBehavior.AllowGet);
        }
    }
}