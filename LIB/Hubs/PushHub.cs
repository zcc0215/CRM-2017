using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIB.Hubs
{
    public class PushHub:Hub
    {
        public void login(string GroupName, string ClientSiCode)
        {

        }
        /// <summary>
        /// 发送邮件完成后通知
        /// </summary>
        public static void PushToClientBySendEmailFinish()
        {
            IHubContext chat = GlobalHost.ConnectionManager.GetHubContext<PushHub>();
            chat.Clients.All.notice("邮件发送成功");
        }
    }
}
