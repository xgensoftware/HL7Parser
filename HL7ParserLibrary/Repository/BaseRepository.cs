using System;
using HL7Core;
namespace HL7Parser.Repository
{
    public abstract class BaseRepository : Object
    {
        #region Member Variables 
        protected HL7DataEntities _dbCTX = null;
        private ILogger _logging = null;
        #endregion

        #region Properties

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

        #region Constructor 
        public BaseRepository()
        {
            LogType type = (LogType)Enum.Parse(typeof(LogType), AppConfiguration.LoggingType);
            this._logging = LogFactory.CreateLogger(type);
        }
        #endregion
    }
}
