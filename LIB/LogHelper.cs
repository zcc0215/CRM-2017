using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIB
{
    public class LogHelper
    {
        NLog.Logger logger;

        private LogHelper(NLog.Logger logger)
        {
            this.logger = logger;
        }

        public static LogHelper Default { get; private set; }
        static LogHelper()
        {
            Default = new LogHelper(NLog.LogManager.GetCurrentClassLogger());
        }

        public void Debug(string msg)
        {
            logger.Debug(msg);
        }


        public void Info(string msg)
        {
            logger.Info(msg);
        }

        public void Trace(string msg)
        {
            logger.Trace(msg);
        }

        public void Error(string msg)
        {
            logger.Error(msg);
        }

        public void Fatal(string msg)
        {
            logger.Fatal(msg);
        }
    }
}
