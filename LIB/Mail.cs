﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LIB
{
    public static class Mail
    {
        public static void MailSend(string toAddress, string title, string body)
        {
            string EmailUsername = System.Configuration.ConfigurationManager.AppSettings["EmailUsername"];
            string EmailPassword = System.Configuration.ConfigurationManager.AppSettings["EmailPassword"];
            MailMessage mailObj = new MailMessage();
            mailObj.From = new MailAddress(EmailUsername); //发送人邮箱地址
            IList<MailAddress> toAddresses = new List<MailAddress>();
            string[] toAddressSplits = toAddress.Split(';');
            foreach (string toAddressSplit in toAddressSplits)
            {
                toAddresses.Add(new MailAddress(toAddressSplit));
            }
            mailObj.To.Add(toAddresses);   //收件人邮箱地址
            mailObj.Subject = title;    //主题
            mailObj.Body = body;    //正文

            SmtpClient smtp = new SmtpClient("smtp.qq.com");//smtp服务器名称
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(EmailUsername, EmailPassword);  //发送人的登录名和密码
            try
            {
                smtp.Send(mailObj);
            }
            catch
            {

            }
        }
        public static IList<T> Add<T>(this IList<T> list, IList<T> resourceList)
        {
            for (int i = 0; i < resourceList.Count; i++)
            {
                list.Add(resourceList[i]);
            }
            return list;
        }
    }
}