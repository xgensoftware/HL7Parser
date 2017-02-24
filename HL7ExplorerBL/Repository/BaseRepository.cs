using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.Xgensoftware.Core;
using com.Xgensoftware.DAL;
namespace HL7ExplorerBL.Repository
{
    public abstract class BaseRepository : Object, IDisposable
    {
        #region Member Variables 
        protected IDataProvider _dbProvider = null;        
        private bool disposedValue = false;

        protected string _tableSelectMSSQL = "select object_id[TableId] ,name as [TableName] from sys.tables where substring(name,charindex('_',name) + 1 ,3) in ({0}) order by name asc";
        #endregion


        #region Properties

        #endregion

        #region Constructor 

        #endregion

        #region Methods 

        protected void FillCollection<T>()
        {

        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_dbProvider != null)
                        _dbProvider = null;
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
