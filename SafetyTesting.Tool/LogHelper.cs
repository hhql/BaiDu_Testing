using log4net;
using System;

namespace SafetyTesting.Tool
{
    public class LogHelper
    {
        public static string logpath = string.Empty;
        public static void Info(string message) 
        {
            ILog log = LogManager.GetLogger("Info");
            if (log.IsInfoEnabled)
            {
                log.Info(message);
            }
        }
        public static void CANInfo(string message)
        {
            ILog log = LogManager.GetLogger("CANInfo");
            if (log.IsInfoEnabled)
            {
                log.Info(message);
            }
        }
        public static void warning(string message)
        {
            ILog log = LogManager.GetLogger("Warning");
            if (log.IsWarnEnabled)
            {
                log.Warn(message);
            }
        }

        public static void Error(string message)
        {
            ILog log = LogManager.GetLogger("Error");
            if (log.IsErrorEnabled)
            {
                log.Error(message);
            }
        }
    }
}
