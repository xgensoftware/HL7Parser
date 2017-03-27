using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7Core.Helper
{
    public class DBLogger : ILogger
    {
        public DBLogger(string conn)
        {

        }
        public void LogMessage(LogMessageType logType, string message)
        {
            //Not implemented
        }
    }
}
