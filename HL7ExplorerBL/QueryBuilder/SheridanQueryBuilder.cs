using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7ExplorerBL.QueryBuilder
{
    public class SheridanQueryBuilder : Object, IQueryBuilder
    {
        #region Member Variables 
        StringBuilder _fromClause = new StringBuilder();
        StringBuilder _columns = new StringBuilder();
        StringBuilder whereClause = new StringBuilder();
        #endregion

        #region Properties

        #endregion

        #region Constructor 
        public SheridanQueryBuilder()
        {
        }

        #endregion

        #region Public Methods 
        public void AddColumn()
        {

        }

        public void SelectFromTables(string[] tables)
        {
            _fromClause.Clear();
            _fromClause.Append("FROM ");
            foreach(string table in tables)
            {
                _fromClause.AppendFormat("{0},", table);
            }

            //remove the last comma
            _fromClause.Remove(_fromClause.Length - 1, 1);
        }

        public string BuildQuery()
        {
            //if the column string is empty set it to * for all columns/all tables
            if (_columns.Length == 0)
                _columns.Append("*");


            return string.Format("SELECT {1} {2} {3}", _columns.ToString(), _fromClause.ToString(), _fromClause.ToString());
        }
        #endregion
    }
}
