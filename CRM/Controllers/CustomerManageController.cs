using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace CRM.Controllers
{
    public class CustomerManageController : Controller
    {
        // GET: CustomerManage
        public ActionResult Index(int? PageCount = 1, int? PageSize = 5)
        {
            IList<Model.TargetCustomers> lmtc = new List<Model.TargetCustomers>();
            IList<KeyValuePair<string, object>> condition = new List<KeyValuePair<string, object>>();

            LIB.PageModel lpm = new LIB.PageModel();
            lpm.fldName = "tcId";
            lpm.PageCount = PageCount.Value;
            lpm.PageSize = PageSize.Value;
            lmtc = LIB.MoreTermSelect.MoreTerm<Model.TargetCustomers>(condition, "TargetCustomers", ref lpm);
            List<string> SendMail = lmtc.Select(a => a.tcEmail).ToList();//筛选出所有客户邮箱

            PagedList<Model.TargetCustomers> pagems = new PagedList<Model.TargetCustomers>(lmtc, PageCount.Value, PageSize.Value, lpm.TotalCount);
            ViewData["pagems"] = pagems;

            ViewBag.SendMail = Newtonsoft.Json.JsonConvert.SerializeObject(SendMail);
            return View();
        }
        [HttpPost]
        public ActionResult SendEmail(List<string> SendMail)
        {
            var Id = Hangfire.BackgroundJob.Enqueue(()=>LIB.Mail.BackgroundSendMail(SendMail));
            Hangfire.BackgroundJob.ContinueWith(Id, () => LIB.Hubs.PushHub.PushToClientBySendEmailFinish());
            var ret = new
            {
                messagecode = SendMail.Count>0 ? 1 : 0,//标识请求是否发送成功,非邮件成功
            };

            return Json(ret, JsonRequestBehavior.AllowGet);
        }
    }
}