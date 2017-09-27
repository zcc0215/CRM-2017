using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class SaleProjectController : Controller
    {
        // GET: SaleProject
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(List<Model.SaleProject> lsp)
        {
            int FailCount = 0;//失败行数
            IList<Model.SaleProject> lAllsp = LIB.MoreTermSelect.GetListDate<Model.SaleProject>();
            IList<Model.SaleProject> lDeletesp = lAllsp;//删除用

            #region 新增
            for(int i=0;i<lsp.Count;i++)
            {
                if (lsp[i].spId == null)
                {
                    bool success = BLL.CommonBLL.add<Model.SaleProject>(lsp[i]);
                    if (!success)
                    {
                        FailCount++;
                    }
                }
            }
            #endregion

            #region 修改
            for (int i = 0; i < lsp.Count; i++)
            {
                for (int j = 0; j < lAllsp.Count; j++)
                {
                    if(lAllsp[j].spId== lsp[i].spId)
                    {
                        bool success = BLL.CommonBLL.Update<Model.SaleProject>(lsp[i]);
                        if (!success)
                        {
                            FailCount++;
                        }
                        lDeletesp.Remove(lAllsp[j]);
                    }
                }
            }
            #endregion

            #region 删除
            for (int i = 0; i < lDeletesp.Count; i++)
            {
                bool success = BLL.CommonBLL.Delete<Model.SaleProject>(lDeletesp[i]);
                if (!success)
                {
                    FailCount++;
                }
            }
            #endregion

            var ret = new
            {
                messagecode = FailCount,
            };

            return Json(ret, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GetSaleProject(string Id)
        {
            var date = Newtonsoft.Json.JsonConvert.SerializeObject(LIB.MoreTermSelect.GetListDate<Model.SaleProject>(tablename: "SaleProject.spId,BusiChance.bcfkspId"));//获取销售计划

            var Role = Newtonsoft.Json.JsonConvert.SerializeObject(LIB.MoreTermSelect.GetListDate<Model.Role>());//获取角色

            var Activity = Newtonsoft.Json.JsonConvert.SerializeObject(LIB.MoreTermSelect.GetListDate<Model.ActivityManage>());//获取市场计划主表

            var TargetCustomers = Newtonsoft.Json.JsonConvert.SerializeObject(LIB.MoreTermSelect.GetListDate<Model.TargetCustomers>());//获取目标客户

            var ret = new
            {
                date = date,
                role = Role,
                activity= Activity,
                targetCustomers= TargetCustomers
            };

            return Json(ret, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddBusiChance(Model.BusiChance mb)
        {
            bool success = BLL.CommonBLL.ExecByProc<Model.BusiChance>(mb);

            var ret = new
            {
                messagecode = success?1:0
            };

            return Json(ret, JsonRequestBehavior.AllowGet);
        }
    }
}