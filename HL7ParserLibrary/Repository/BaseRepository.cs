using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL7Parser;
using HL7Parser.Helper;
namespace HL7Parser.Repository
{
    public abstract class BaseRepository : Object
    {
        #region Member Variables 
        protected HL7DataEntities _dbCTX = null;
        protected LogHelper _logging = null;
        #endregion

        #region Properties

        #endregion

        #region Constructor 
        public BaseRepository()
        {
            this._logging = new LogHelper();
        }
        #endregion
    }
}
