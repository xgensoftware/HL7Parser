using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HL7Parser.Helper
{
    public enum LogType
    {
        ERROR,
        INFO
    }

    public class LogHelper
    {     

        private static ReaderWriterLockSlim _readWriteLock;

        static LogHelper()
        {
            LogHelper._readWriteLock = new ReaderWriterLockSlim();
        }

        public LogHelper()
        {
        }

        public void LogMessage(LogType logType,string message)
        {
            LogHelper._readWriteLock.EnterWriteLock();
            try
            {                
                string logFile = string.Format(AppConfiguration.LogFile,DateTime.Now.ToString("yyyyMMdd"));
                using (StreamWriter streamWriter = File.AppendText(logFile))
                {
                    DateTime now = DateTime.Now;
                    string logMessage = string.Format("{0} {1}: {2}", now.ToString("yyyyMMdd HH:mm:ss"), logType.ToString(), message);
                    streamWriter.WriteLine(logMessage);
                    streamWriter.Close();
                    
                    Console.WriteLine(logMessage);
                }
            }
            finally
            {
                LogHelper._readWriteLock.ExitWriteLock();
            }
        }
    }
    
}
