using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL7Core;  
namespace HL7ExplorerBL.Services
{
    public class ServiceBase : IDisposable
    {
        #region Member Variables
        
        protected ILogger _fileLogger = null;

        #endregion

        public ServiceBase()
        {
            _fileLogger = LogFactory.CreateLogger(LogType.FILE);
        }

        public void Dispose()
        {
            if(_fileLogger != null)
            {
                _fileLogger = null;
            }
        }
    }
}
