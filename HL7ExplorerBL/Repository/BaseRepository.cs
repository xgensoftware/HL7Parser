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
        protected DatabaseProvider_Type _dbType = DatabaseProvider_Type.MSSQLProvider;
        private bool disposedValue = false;

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
