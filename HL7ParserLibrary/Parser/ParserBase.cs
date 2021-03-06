﻿
using HL7Parser.Helper;

namespace HL7Parser.Parser
{
    public abstract class ParserBase
    {
        #region Member Variables 
        protected ParserLog _logging = null;
        protected bool _loggingEnabled = false;
        #endregion

        #region Private Methods
        protected void LogErrorMessage(string message)
        {
            _logging.LogMessage(message);
        }
        protected void LogInfoMessage(string message)
        {
            if(_loggingEnabled)
                _logging.LogMessage( message);
        }
        #endregion

        public ParserBase()
        {
            this._logging = new ParserLog();
        }
        
    }
}
