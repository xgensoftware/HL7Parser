using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7ExplorerBL.Entities
{
    public class DBColumn : Object
    {
        #region Member Variables 
        string _columnName = string.Empty;
        #endregion

        #region Properties
        public string ColumnName
        {
            get { return _columnName; }
        }
        #endregion

        #region Constructor 
        public DBColumn(string name)
        {
            this._columnName = name;
        }
        #endregion
    }
}
