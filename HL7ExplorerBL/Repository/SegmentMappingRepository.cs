using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL7Core;
using com.Xgensoftware.Core;
using com.Xgensoftware.DAL;
using HL7ExplorerBL.Entities;

namespace HL7ExplorerBL.Repository
{
    public class SegmentMappingRepository : BaseRepository
    {
        #region Member Variables 

        #endregion

        #region Properties

        #endregion

        #region Constructor 
        public SegmentMappingRepository(string dbProvider, string strConn)
        {
            this._dbType = (DatabaseProvider_Type)Enum.Parse(typeof(DatabaseProvider_Type), dbProvider);
            _dbProvider = DALFactory.CreateSqlProvider(_dbType, strConn);
        }
        #endregion

        #region Public Methods 

        public DataTable GetSegmentTableData(int messageHeaderId, string columns, string tableName)
        {
            string sql = string.Format("select {0} from {1} (nolock) where MessageHeaderId = {2} ", columns, tableName, messageHeaderId);
            return this._dbProvider.ExecuteDataSetQuery(sql, null).Tables[0];
        }

        public DataTable GetMessageData(string sql)
        {
            return this._dbProvider.ExecuteDataSetQuery(sql, null).Tables[0];
        }

        public int GetMessageHeaderIdBy(string messageControlId)
        {
            string sql = string.Format("select MessageHeaderId from MessageHeader_MSH (nolock) where MessageControlId = '{0}'", messageControlId);
            return this._dbProvider.ExecuteDataSetQuery(sql, null).Tables[0].Rows[0]["MessageHeaderId"].Parse<int>();
        }

        #endregion
    }
}
