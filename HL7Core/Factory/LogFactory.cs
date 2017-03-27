using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL7Core.Helper;
namespace HL7Core
{
    public static class LogFactory
    {
        public static ILogger CreateLogger(LogType type)
        {
            ILogger l = null;
            
            switch(type)
            {
                case LogType.FILE:

                    l = new FileLogger(AppConfiguration.ApplicationName);
                    break;

                case LogType.DATABASE:
                    l = new DBLogger(AppConfiguration.LogConnectionString);
                    break;
            }

            return l;
        }
    }
}
