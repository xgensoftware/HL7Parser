using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeEngine.Framework.QueryBuilder;
using CodeEngine.Framework.QueryBuilder.Enums;
namespace HL7ExplorerBL.Helper
{
    /// <summary>
    /// The servers as a wrapper to the CodeEngine Query builder library.
    /// </summary>
    class QueryBuilder : Object
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
        public void SelectFromTable(string table)
        {
            this._sql.SelectFromTable(table);
        }

        public void SelectFromTables(string[] tables)
        {
            this._sql.SelectFromTables(tables);


        }

        public void AddInnerJoin(string toTableName, string toColumnName,string fromTableName, string fromColumnName)
        {
            JoinClause jc = new JoinClause(JoinType.InnerJoin, toTableName, toColumnName, Comparison.Equals, fromTableName, fromColumnName);
            this._sql.AddJoin(jc);
        }

        public void AddOuterJoin(string toTableName, string toColumnName, string fromTableName, string fromColumnName)
        {
            JoinClause jc = new JoinClause(JoinType.OuterJoin, toTableName, toColumnName, Comparison.Equals, fromTableName, fromColumnName);
            this._sql.AddJoin(jc);
        }

        public override string ToString()
        {
            return this._sql.BuildQuery();
        }
        #endregion
    }
}
