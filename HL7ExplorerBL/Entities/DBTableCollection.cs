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
        Dictionary<int,DBTable> _collection = null;
        #endregion

        #region Properties
        public Dictionary<int, DBTable> Collection
        {
            get { return this._collection; }
        }
        #endregion

        #region Constructor 
        public DBTableCollection()
        {
            _collection = new Dictionary<int, DBTable>();
        }
        #endregion

        #region Public Methods 

        public void Add(DBTable item)
        {
            int key = 1;
            if(_collection.Count > 0)
            {
                key = _collection.Count() + 1;
            }

            _collection.Add(key, item);
        }

        public string[] ToStringArray()
        {
            int count = this._collection.Count();
            string[] s = new string[count];

            for(int idx = 0; idx <= count -1;idx ++)
            {
                s[idx] = this._collection.ElementAt(idx).Value.TableName;
            }


            return s;
        }

        public List<DBTable> ToList()
        {
            List<DBTable> collection = new List<DBTable>();

            foreach(var item in this._collection)
            {
                collection.Add(item.Value);
            }

            return collection;
        }
        #endregion
    }
}
