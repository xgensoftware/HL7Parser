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
    public class GenericDBRepository : BaseRepository
    {
        #region Member Variables 
        #endregion

        #region Properties

        #endregion

        #region Constructor 
        public GenericDBRepository(string dbProvider, string strConn)
        {
            DatabaseProvider_Type dbType = (DatabaseProvider_Type)Enum.Parse(typeof(DatabaseProvider_Type), dbProvider);
            _dbProvider = DALFactory.CreateSqlProvider(dbType, strConn);
        }
        #endregion

        #region Public Methods 

        public DBTableCollection GetDatabaseTables(string segmentString)
        {
            DBTableCollection collection = new DBTableCollection();

            _tableSelectMSSQL = string.Format(_tableSelectMSSQL,segmentString);


            DataTable tableData = _dbProvider.ExecuteDataSetQuery(_tableSelectMSSQL, null).Tables[0];
            Parallel.ForEach(tableData.AsEnumerable(), (dt) => {
                collection.Add(new DBTable(dt["TableId"].Parse<long>(), dt["TableName"].ToString()));
            });

            return collection;
        }

        #endregion
    }
}
