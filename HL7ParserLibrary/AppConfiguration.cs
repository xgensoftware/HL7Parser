using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HL7Parser
{   

    public static class AppConfiguration
    {
        public static string ApplicationName
        {
            get { return System.Reflection.Assembly.GetExecutingAssembly().GetName().Name.ToString(); }
            
        }

        public static string LogFile
        {
            get { return ConfigurationManager.AppSettings["ApplicationLog"].ToString(); }
        }
    }
}
