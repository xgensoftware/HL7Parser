using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7Core
{
    public enum LogMessageType
    {
        ERROR,
        INFO
    }

    public enum LogType
    {
        FILE,
        DATABASE
    }

    public interface ILogger
    {
        void LogMessage(LogMessageType type, string message);
    }
}
