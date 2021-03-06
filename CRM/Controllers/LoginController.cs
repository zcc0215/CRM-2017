﻿using LIB.Hubs;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Check(Model.CRMUser mcu)
        {
            IList<Model.CRMUser> lmcu = new List<Model.CRMUser>();
            IList<KeyValuePair<string, object>> condition = new List<KeyValuePair<string, object>>();
            condition.Add(new KeyValuePair<string, object>("Username", mcu.Username));
            condition.Add(new KeyValuePair<string, object>("Password", LIB.MD5.GetMD5(mcu.Password)));
            LIB.PageModel lpm = new LIB.PageModel();
            lmcu = LIB.MoreTermSelect.MoreTerm<Model.CRMUser>(condition, "CRMUser.ufkRole,Role.rId", ref lpm);
            if (lmcu.Count > 0) { 
                Session["UserInfo"] = lmcu[0];
                //Hangfire.BackgroundJob.Enqueue(() => LIB.Mail.MailSend("zcc0215@hotmail.com;zcc0215@hotmail.com", "测试", "成功"));
                //LIB.LogHelper.Default.Fatal("测试");
                //var jobId=  Hangfire.BackgroundJob.Enqueue(() => LIB.Mail.BackgroundSendMail());
               // Hangfire.BackgroundJob.ContinueWith(jobId, () => LIB.Hubs.PushHub.PushToClientBySendEmailFinish());
                //IHubContext chat = GlobalHost.ConnectionManager.GetHubContext<PushHub>();
                //chat.Clients.All.notice("发送成功");
                return RedirectToAction("Index", "Home");
            }
            else
                return RedirectToAction("Index", "Login");
        }
    }
}