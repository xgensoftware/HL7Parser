using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7ExplorerBL.Entities
{
    public class DBTable : Object
    {
        #region Member Variables 
        string _tableName = string.Empty;
        long _tableId = -1;
        #endregion

        #region Properties
        public long TableId
        {
            get { return _tableId; }
        }

        public string TableName
        {
            get { return _tableName; }
        }
        #endregion

        #region Constructor 
        public DBTable(long tableId, string tableName)
        {
            this._tableId = tableId;
            this._tableName = tableName;
        }

        #endregion
    }
}
