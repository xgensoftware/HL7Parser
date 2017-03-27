using System;
using HL7Parser.Helper;
namespace HL7Parser.Repository
{
    public abstract class BaseRepository : Object
    {
        #region Member Variables 
        protected HL7DataEntities _dbCTX = null;
        private ParserLog _logging = null;
        #endregion

        #region Properties

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

        #region Constructor 
        public BaseRepository()
        {
            this._logging = new ParserLog();
        }
        #endregion
    }
}
