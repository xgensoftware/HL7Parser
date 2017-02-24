using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7ExplorerBL.Entities
{
    public class DBTableCollection : Object
    {
        #region Member Variables 
        ConcurrentBag<DBTable> _collection = null;
        #endregion

        #region Properties
        public List<DBTable> Collection
        {
            get { return this._collection.OrderBy(x => x.TableName).ToList(); }
        }
        #endregion

        #region Constructor 
        public DBTableCollection()
        {
            _collection = new ConcurrentBag<DBTable>();
        }
        #endregion

        #region Public Methods 

        public void Add(DBTable item)
        {
            _collection.Add(item);
        }

        #endregion
    }
}
