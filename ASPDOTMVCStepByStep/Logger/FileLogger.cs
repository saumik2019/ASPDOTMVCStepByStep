using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace ASPDOTMVCStepByStep.Logger
{
    public class FileLogger
    {
        public void RuntimeExceptionLog(Exception ex)
        {
            string directoryPath = HttpContext.Current.Server.MapPath(Convert.ToString(ConfigurationManager.AppSettings["ExceptionLogPath"])) + "\\" + DateTime.Now.ToString("dd-MM-yyyy");
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
            File.WriteAllLines(directoryPath + "\\" +  DateTime.Now.ToString("dd-MM-yyyy hh mm ss") + ".txt",
                new string[] {
                "Message : " + ex.Message,
                "StackTrace : " + ex.StackTrace
                });
        }
    }
}