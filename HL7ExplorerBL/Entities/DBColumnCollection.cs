using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7ExplorerBL.Entities
{
    public class DBColumnCollection : Object
    {
        #region Member Variables 
        ConcurrentBag<DBColumn> _collection = null;
        #endregion

        #region Properties
        public List<DBColumn> Collection
        {
            get { return _collection.OrderBy(x => x.ColumnName).ToList(); }
        }
        #endregion

        #region Constructor 
        public DBColumnCollection()
        {
            this._collection = new ConcurrentBag<DBColumn>();
        }
        #endregion
    }
}
