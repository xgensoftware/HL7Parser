using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeEngine.Framework.QueryBuilder;
namespace HL7ExplorerBL.Helper
{
    /// <summary>
    /// The servers as a wrapper to the CodeEngine Query builder library.
    /// </summary>
    public class QueryBuilder : Object
    {
        #region Member Variables 
        SelectQueryBuilder _sql = null;
        #endregion

        #region Properties

        #endregion

        #region Constructor 
        public QueryBuilder()
        {
            this._sql = new SelectQueryBuilder();
        }
        #endregion

        #region Public Methods
        public void AddTables(string[] tables)
        {
            this._sql.SelectFromTables(tables);
            this._sql.SelectColumns();
        }

        public override string ToString()
        {
            return this._sql.BuildQuery();
        }
        #endregion
    }
}
