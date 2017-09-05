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
    public class BaseController : Controller
    {
        /// <summary>
        /// 登陆用户信息
        /// </summary>
        public Model.CRMUser LoginUserInfo { get; set; }
        /// <summary>
        /// excel导入的模板
        /// </summary>
        protected string ImportModleFile { get; set; }
        /// <summary>
        /// 导入外键标记
        /// </summary>
        public int ImportFlag { get; set; }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["UserInfo"] == null)
                filterContext.Result = RedirectToAction("Index", "Login");
            else
                LoginUserInfo = filterContext.HttpContext.Session["UserInfo"] as Model.CRMUser;

            base.OnActionExecuting(filterContext);
        }
        /// <summary>
        /// 转换DataTable 标题
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="cols"></param>
        protected void ChangeDtTitle(DataTable dt, NameValueCollection cols)
        {
            foreach (DataColumn dc in dt.Columns)
            {
                string name = cols[dc.ColumnName];
                if (name != null)
                    dc.ColumnName = name;
            }
        }
        /// <summary>
        /// 处理上传过来的excel数据
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        protected virtual string DoExcelData(DataTable dt) { return null; }
        /// <summary>
        /// 导入
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UploadExcelFile(int Flag=0)
        {
            DataTable dt = null, dtModel = null;
            string msg = ""; int errorNum = 0;

            HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;            
            string modePath = Server.MapPath("~/ExcelModel/") + ImportModleFile;//原始文件
            try
            {
                if (hfc.Count > 0 && hfc[0].ContentLength > 0)
                {
                    string fileFullName = Path.GetFileName(hfc[0].FileName);
                    string fileExt = fileFullName.Substring(fileFullName.IndexOf(".") + 1);
                    if (fileExt != "xls" && fileExt != "xlsx")
                    {
                        msg = "请选择Excel文件类型导入!";
                    }
                    else
                    {
                        HttpPostedFileBase file = Request.Files["file"];
                        if (file != null)
                        {
                            string filePath = Server.MapPath("~/Uploads/") + ImportModleFile;
                            file.SaveAs(filePath);
                        }
                        if (fileExt == "xls")
                        {
                            dt = LIB.ExcelHelper.RenderDataTableFromExcel(hfc[0].InputStream);
                        }

                        else
                        {
                            dt = LIB.ExcelHelper.RenderDataTableFromExcel2007(hfc[0].InputStream);
                        }

                        dtModel = LIB.ExcelHelper.ExcelToDataTable(modePath);

                        if (dt.Columns.Count != dtModel.Columns.Count)
                        {
                            msg = "抱歉，您选择的导入文件不正确，当前系统检测到您的导入文件的列数与服务器提供的模板列数不相符！请您仔细检查当前导入文件是否正确！";
                            errorNum++;
                        }
                        else if (dt.Columns.Count > 0)
                        {
                            int columnNum = 0;
                            columnNum = dt.Columns.Count;
                            string[] strColumns = new string[columnNum];
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                if (dtModel.Columns[i].ColumnName != dt.Columns[i].ColumnName)
                                {
                                    msg = "抱歉，您选择的导入文件不正确，当前系统检测到您的导入文件中的列名：“" + dtModel.Columns[i].ColumnName + "”，与服务器提供的模板字段不相符！请您仔细检查当前导入文件是否正确！";
                                    errorNum++;
                                }
                            }
                        }

                        if (errorNum == 0)
                        {
                            dtModel.Clear();
                            dtModel.Merge(dt, true, MissingSchemaAction.Ignore);
                            if(Flag!=0)
                            {
                                ImportFlag = Flag;
                            }
                            if(dtModel.Rows.Count==0)
                            {
                                msg = "excel中无数据";
                            }
                            dtModel.TableName = RouteData.Values["controller"].ToString();

                            string Typename = "Model." + dtModel.TableName;
                            dynamic obj = System.Reflection.Assembly.Load("Model").CreateInstance(Typename, false);

                            #region 对应数据库字段
                            IList<Model.TableInfo> lmti = BLL.CommonBLL.GetTableInfo(dtModel.TableName);
                            NameValueCollection cols = new NameValueCollection();
                            foreach (DataColumn dc in dtModel.Columns)
                            {
                                cols.Add(dc.ColumnName, lmti.Where(n => n.tiCommentary == dc.ColumnName).FirstOrDefault().tiName);
                                lmti.Remove(lmti.Where(n => n.tiCommentary == dc.ColumnName).FirstOrDefault());
                            }
                            ChangeDtTitle(dtModel, cols);
                            #endregion

                            #region 对不在于报表中数据库项进行赋值
                            foreach (Model.TableInfo ti in lmti)
                            {
                                if(ti.tiCommentary.Contains("关联"))
                                {
                                    dtModel.Columns.Add(ti.tiName, typeof(int));
                                    foreach (DataRow dr in dtModel.Rows)
                                        dr[ti.tiName] = this.ImportFlag;

                                    #region 构造外键列
                                    System.Reflection.PropertyInfo[] fields = obj.GetType().GetProperties();//获取指定对象的所有公共属性
                                    foreach (System.Reflection.PropertyInfo t in fields)
                                    {
                                        if (t.Name==ti.tiName)
                                        {
                                            t.SetValue(obj, this.ImportFlag, null);//给对象赋值
                                            break;
                                        }
                                    }
                                    #endregion

                                }
                            }
                            #endregion

                            msg = DoExcelData(dtModel);//执行个性化操作

                            #region 执行批量插入                                                       
                            BLL.CommonBLL.Delete(obj);
                            bool Success = BLL.CommonBLL.BulkAdd(dtModel);
                            msg= Success ? "1" : "0";
                            #endregion

                        }

                    }

                }
                else
                {
                    msg = "请选择要导入的文件";
                }
            }
            catch
            {
                msg = "导入失败";
            }
            var ret = new
            {
                messagecode = msg
            };
            return Json(ret, JsonRequestBehavior.AllowGet);
        }
    }
}