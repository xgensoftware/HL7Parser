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
        protected ParserLog _logging = null;
        #endregion

        #region Private Methods
        protected void LogErrorMessage(string message)
        {
            _logging.LogMessage(message);
        }
        protected void LogInfoMessage(string message)
        {
            _logging.LogMessage( message);
        }
        #endregion

        public ParserBase()
        {
            this._logging = new ParserLog();
        }
        
    }
}
