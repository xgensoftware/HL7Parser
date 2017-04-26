using System;
using HL7Parser.Helper;

namespace HL7Parser.Models
{
    public class ModelBase
    {
        #region Member Variables 
        protected ParserLog _logging = null;
        #endregion

        #region Private Methods
        protected void LogErrorMessage(string message)
        {
            _logging.LogMessage(message);
        }
        protected void LogInfoMessage(string message)
        {
            _logging.LogMessage(message);
        }
        #endregion

        public ModelBase()
        {
            this._logging = new ParserLog();
        }

    }
}
