using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Hangfire;
using Hangfire.MemoryStorage;
using Hangfire.Common;
using Hangfire.States;
using Hangfire.Logging;
using Hangfire.Storage;

[assembly: OwinStartup(typeof(CRM.Startup))]

namespace CRM
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888


            //指定Hangfire使用sql server存储后台任务信息
            //string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            //GlobalConfiguration.Configuration.UseSqlServerStorage(connectionString);
            //指定Hangfire使用内存存储后台任务信息
            GlobalConfiguration.Configuration.UseMemoryStorage();
            GlobalJobFilters.Filters.Add(new LogFailureAttribute());
            //启用HangfireServer这个中间件（它会自动释放）
            app.UseHangfireServer();
            //启用Hangfire的仪表盘（可以看到任务的状态，进度等信息）
            app.UseHangfireDashboard();

            app.MapSignalR();
        }
        /// <summary>
        /// 超过默认重试次数(10次),记录日志
        /// </summary>
        public class LogFailureAttribute : JobFilterAttribute, IApplyStateFilter
        {
            private static readonly ILog Logger = LogProvider.GetCurrentClassLogger();

            public void OnStateApplied(ApplyStateContext context, IWriteOnlyTransaction transaction)
            {
                var failedState = context.NewState as FailedState;
                if (failedState != null)
                {
                    Logger.ErrorException(
                        String.Format("Background job #{0} was failed with an exception.", context.BackgroundJob.Id),
                        failedState.Exception);
                }
            }
            public void OnStateUnapplied(ApplyStateContext context, IWriteOnlyTransaction transaction)
            {
            }
        }
    }
}
