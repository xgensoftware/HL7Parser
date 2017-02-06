using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL7Parser.Helper;

namespace HL7Parser.Parser
{
    public abstract class ParserBase
    {
        #region Member Variables 
        LogHelper _logger;
        #endregion

        #region Private Methods
        protected void LogErrorMessage(string message)
        {
            _logger.LogMessage(LogType.ERROR, message);
        }
        protected void LogInfoMessage(string message)
        {
            _logger.LogMessage(LogType.INFO, message);
        }
        #endregion

        public ParserBase()
        {
            _logger = new LogHelper();
        }
    }
}
