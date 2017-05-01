using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;

namespace HL7Parser.Helper
{
    public class ParserLog : Object
    {
        private static ReaderWriterLockSlim _readWriteLock;
        static ParserLog()
        {

            ParserLog._readWriteLock = new ReaderWriterLockSlim();
        }

        public ParserLog()
        {
        }

        public void LogMessage(string message)
        {
            ParserLog._readWriteLock.EnterWriteLock();
            try
            {
                string logFile = string.Format("{0}_{1}.log", "HL7ParserLog", DateTime.Now.ToString("yyyyMMdd"));
                using (StreamWriter streamWriter = File.AppendText(logFile))
                {
                    DateTime now = DateTime.Now;
                    string logMessage = string.Format("{0}  {1}", now.ToString("yyyyMMdd HH:mm:ss"),message);
                    streamWriter.WriteLine(logMessage);
                    streamWriter.Close();

                    Console.WriteLine(logMessage);
                }
            }
            finally
            {
                ParserLog._readWriteLock.ExitWriteLock();
            }
        }
    }
}
