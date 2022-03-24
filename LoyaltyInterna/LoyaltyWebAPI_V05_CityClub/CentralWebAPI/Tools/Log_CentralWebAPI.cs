using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Tools
{
    public class Log_CentralWebAPI
    {
        private string bitacoraLogin = System.Configuration.ConfigurationManager.AppSettings["bitacoraLogin"];
        private string ActivaLog = System.Configuration.ConfigurationManager.AppSettings["flagActivedLog"];

        public void LogWebAPi(string txtLog)
        {
            if (ActivaLog == "Y")
                FmkTools.Log.WriteToLogFile(bitacoraLogin, txtLog);
        }
    }
}