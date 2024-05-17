using log4net;
using log4net.Config;
using System;
using System.IO;
using System.Linq;

namespace SafetyTesting.Tool
{
    public class LogHelper
    {
        public static string logpath = string.Empty;
        public static void Info(string message) 
        {
            NLog.Logger _loggerin = NLog.LogManager.GetLogger("Info");
            _loggerin.Info(message);

            //ILog log = LogManager.GetLogger("Info");
            //if (log.IsInfoEnabled)
            //{
            //    log.Info(message);
            //}
        }
        public static void CANInfo(string vin,string message)
        {

            NLog.Logger _loggercaninfo = NLog.LogManager.GetLogger(vin);
            _loggercaninfo.Trace(message);


        }
        public static void warning(string message)
        {

            NLog.Logger _loggerwarn = NLog.LogManager.GetLogger("warning");
            _loggerwarn.Warn(message);

           
        }

        public static void Error(string message)
        {
            NLog.Logger _loggererro = NLog.LogManager.GetLogger("Error");
            _loggererro.Error(message);
        }
    }
}
