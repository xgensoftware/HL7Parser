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
        enum DB_Schema_Query
        {
            TABLE,
            ALL_TABLES,
            COLUMN                
        }
        #endregion

        #region Properties

        #endregion

        #region Constructor 
        public GenericDBRepository(string dbProvider, string strConn)
        {
            this._dbType = (DatabaseProvider_Type)Enum.Parse(typeof(DatabaseProvider_Type), dbProvider);
            _dbProvider = DALFactory.CreateSqlProvider(_dbType, strConn);
        }
        #endregion

        #region Private Methods 
        string GetDBSpecificQuery(DB_Schema_Query query)
        {
            string sql = string.Empty;


            if (this._dbType == DatabaseProvider_Type.MSSQLProvider)
            {
                switch(query)
                {
                    case DB_Schema_Query.ALL_TABLES:
                        sql = "select object_id[TableId] ,name as [TableName] from sys.tables where CHARINDEX('_',name) <> 0 order by name asc";
                        break;

                    case DB_Schema_Query.TABLE:
                        sql = "select object_id[TableId] ,name as [TableName] from sys.tables where substring(name,charindex('_',name) + 1 ,3) in ({0}) order by name asc";
                        break;

                    case DB_Schema_Query.COLUMN:
                        sql = "SELECT c.name FROM sys.columns c  where c.object_id = {0}";
                        break;
                }
            }

            return sql;
        }

        #endregion

        #region Public Methods 
        /// <summary>
        /// Get list of DB tables based on the segment name.
        /// </summary>
        /// <param name="segmentString">String of formated segments ('MSH','EVN')</param>
        /// <returns></returns>
        public DBTableCollection GetDatabaseTables(string segmentString)
        {
            // retrieve the table names and add them to the collection 
            // in the correct order.
            DBTableCollection collection = new DBTableCollection();
            
            string sql = string.Empty;

            if (string.IsNullOrEmpty(segmentString))
            {
                sql = this.GetDBSpecificQuery(DB_Schema_Query.ALL_TABLES);
            }
            else
            {
                sql = this.GetDBSpecificQuery(DB_Schema_Query.TABLE);
            }
            
            if(!string.IsNullOrEmpty(sql))
            {
                string[] orderList;
                if (!string.IsNullOrEmpty(segmentString))
                    orderList = segmentString.Split(',');

                sql = string.Format(sql, segmentString);

                DataTable dt = _dbProvider.ExecuteDataSetQuery(sql, null).Tables[0];

                foreach (DataRow dr in dt.Rows)
                {
                    collection.Add(new DBTable(dr["TableId"].Parse<long>(), dr["TableName"].ToString()));
                }
            }

            return collection;
        }

        /// <summary>
        /// Will retrieve a list of DB columns based on table
        /// </summary>
        /// <param name="dbt">DBTable object</param>
        /// <returns></returns>
        public DBColumnCollection GetDatabaseColumnsBy(DBTable dbt)
        {           
            DBColumnCollection collection = new DBColumnCollection();

            string sql = this.GetDBSpecificQuery(DB_Schema_Query.COLUMN);
            if(!string.IsNullOrEmpty(sql))
            {
                sql = string.Format(sql, dbt.TableId.ToString());

                DataTable dtColumns = _dbProvider.ExecuteDataSetQuery(sql, null).Tables[0];
                foreach (DataRow row in dtColumns.Rows)
                {
                    collection.Add(new DBColumn(row["name"].ToString()));
                }
            }

            return collection;
        }


        #endregion
    }
}
