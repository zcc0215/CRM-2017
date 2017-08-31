using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace CRM.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? PageCount = 1,int? PageSize=1)
        {
            IList<Model.Student> lms = new List<Model.Student>();
            //lms = BLL.testBLL.GetStudent();
            //lms = BLL.testBLL.Get<Model.Student>("select * from student");
            IList<KeyValuePair<string, object>> condition = new List<KeyValuePair<string, object>>();

            #region  条件使用说明
            //condition.Add(new KeyValuePair<string, object>("Name", "张三"));//'='不用写
            //condition.Add(new KeyValuePair<string, object>("Name", "%张三%"));//代表 like
            //condition.Add(new KeyValuePair<string, object>("Name", "|李四"));//‘|’代表OR，代表与前一个条件取或
            //condition.Add(new KeyValuePair<string, object>("Age", "22,23"));//代表 in (22,23)
            //condition.Add(new KeyValuePair<string, object>("Age", ">20"));//可做数据间的比较操作 >  <   !=
            //.Add(new KeyValuePair<string, object>("Age", "20'@'25"));//'@'  代表两个数据做Between ... and 
            #endregion

            #region 分页实体
            LIB.PageModel lpm = new LIB.PageModel();
            lpm.fldName = "sid";
            lpm.PageCount = PageCount.Value;
            lpm.PageSize = PageSize.Value;
            #endregion

            lms = LIB.MoreTermSelect.MoreTerm<Model.Student>(condition, "student",ref lpm);//student.sid,class.cid 代表多表联查
            ViewData["lms"] = lms;

            PagedList<Model.Student> pagems = new PagedList<Model.Student>(lms, PageCount.Value, PageSize.Value, lpm.TotalCount);            
            ViewData["pagems"] = pagems;
            return View();
        }
        /// <summary>
        /// 添加学生
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Age"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(Model.Student ms)
        {
            //bool issuccess = BLL.testBLL.addStudent(ms);
            bool issuccess = BLL.CommonBLL.add<Model.Student>(ms);
            var ret = new
            {
                messagecode = issuccess?1:0,
            };

            return Json(ret, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除学生
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(Model.Student ms)
        {
            //bool issuccess = BLL.testBLL.Delete(sid);
            bool issuccess = BLL.CommonBLL.Delete<Model.Student>(ms);
            var ret = new
            {
                messagecode = issuccess ? 1 : 0,
            };
            return Json(ret, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 编辑学生信息
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Model.Student ms)
        {
            //bool issuccess = BLL.testBLL.EditStudent(ms);
            bool issuccess = BLL.CommonBLL.Update<Model.Student>(ms);
            var ret = new
            {
                messagecode = issuccess ? 1 : 0,
            };

            return Json(ret, JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}