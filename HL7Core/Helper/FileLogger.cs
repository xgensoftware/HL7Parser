using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace HL7Core.Helper
{
    public class FileLogger : ILogger
    {
        private static ReaderWriterLockSlim _readWriteLock;

        static FileLogger()
        {

            FileLogger._readWriteLock = new ReaderWriterLockSlim();
        }

        public FileLogger()
        {
        }

        public void LogMessage(LogMessageType logType, string message)
        {
            FileLogger._readWriteLock.EnterWriteLock();
            try
            {
                string logFile = string.Format("{0}_{1}.log", AppConfiguration.ApplicationName, DateTime.Now.ToString("yyyyMMdd"));
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
                FileLogger._readWriteLock.ExitWriteLock();
            }
        }
    }
}
