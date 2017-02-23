using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL7Core;

namespace HL7Parser.Parser
{
    public abstract class ParserBase
    {
        #region Member Variables 
        protected ILogger _logging = null;
        #endregion

        #region Private Methods
        protected void LogErrorMessage(string message)
        {
            _logging.LogMessage(LogMessageType.ERROR, message);
        }
        protected void LogInfoMessage(string message)
        {
            _logging.LogMessage(LogMessageType.INFO, message);
        }
        #endregion

        public ParserBase()
        {
            LogType type = (LogType)Enum.Parse(typeof(LogType), AppConfiguration.LoggingType);
            this._logging = LogFactory.CreateLogger(type);
        }
        
    }
}
