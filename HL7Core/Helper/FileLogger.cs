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
        private static string _logFileName;
        static FileLogger()
        {

            FileLogger._readWriteLock = new ReaderWriterLockSlim();
        }

        public FileLogger(string logFile)
        {
            _logFileName = logFile;
        }

        public void LogMessage(LogMessageType logType, string message)
        {
            FileLogger._readWriteLock.EnterWriteLock();
            try
            {
                using (StreamWriter streamWriter = File.AppendText(_logFileName))
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
