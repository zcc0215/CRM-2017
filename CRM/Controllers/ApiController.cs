using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class ApiController : Controller
    {
        // GET: Api
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Export(int Begin,int End,int Type = 0)
        {
            DataTable dt = BLL.ExportBLL.BusiAnalysis(Begin,End,Type);
            var data = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            return Content(data);
        }
    }
}