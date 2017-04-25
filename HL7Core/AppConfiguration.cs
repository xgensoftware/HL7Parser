using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace HL7Core
{
    public class AppConfiguration
    {
        public static string ApplicationName
        {
            get { return System.Reflection.Assembly.GetExecutingAssembly().GetName().Name.ToString(); }

        }
        public static string LoggingType
        {
            get {
                return ConfigurationManager.AppSettings["LogType"].ToString();
            }
        }

        public static string LogConnectionString
        {
            get
            {
                return ConfigurationManager.AppSettings["LogConnectionString"].ToString();
            }
        }

        public static string DBConnection
        {
            get
            {
                string conn = string.Empty;

                try
                {
                    conn = ConfigurationManager.AppSettings["DBConnection"].ToString();
                }
                catch { }
                return conn;
            }
        }

        public static string DBProvider
        {
            get { return ConfigurationManager.AppSettings["DBProvider"].ToString(); }
        }
        
    }
}
