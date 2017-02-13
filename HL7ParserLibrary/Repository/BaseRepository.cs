using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL7Parser;

namespace HL7Parser.Repository
{
    public abstract class BaseRepository : Object
    {
        #region Member Variables 
        protected HL7DataEntities _dbCTX = null;
        #endregion

        #region Properties

        #endregion

        #region Constructor 
        public BaseRepository()
        {

        }
        #endregion
    }
}
