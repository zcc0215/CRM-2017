using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class ExportController : BaseController
    {
        // GET: Export
        public ActionResult Index()
        {
            DataTable dt = BLL.ExportBLL.BusiAnalysis();
            ViewData["dt"] = dt;
            return View();
        }
        public ActionResult BusiAnalysis()
        {
            DataTable dt = BLL.ExportBLL.BusiAnalysis();

            #region 转化列头
            string TableName = "'SaleProject','BusiChance','OrderManage','ContractManage','Role','ActivityManage','TargetCustomers'";
            IList<Model.TableInfo> lmti = BLL.CommonBLL.GetTableInfo(TableName);
            NameValueCollection cols = new NameValueCollection();
            foreach (DataColumn dc in dt.Columns)
            {
                cols.Add(dc.ColumnName, lmti.Where(n => n.tiName == dc.ColumnName).FirstOrDefault().tiCommentary);
            }
            ChangeDtTitle(dt, cols);
            #endregion

            MemoryStream ms = new MemoryStream();
            ms = LIB.ExcelHelper.ExportExcel(dt);
            string FileName = "业务分析" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            return File(ms, "application/vnd.ms-excel", FileName);
        }
    }
}