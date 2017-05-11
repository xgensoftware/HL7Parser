using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using HL7ExplorerBL.Models;

namespace HL7ExplorerBL.QueryParser
{
    public enum QUERY_COMMAND
    {
        SELECT,
        UPDATE,
        DELETE,
        INSERT
    }

    public class QueryToken
    {
        #region Member Variables
        QUERY_COMMAND _command = QUERY_COMMAND.SELECT;

        string[] _commandOperator = new string[] { "SELECT", "UPDATE" };
        string[] _comparisonOperators = new string[] { "=" };
        string[] _whereClauseOperators = new string[] { "WHERE", "AND", "OR" };

        string _columns = string.Empty;

        List<string> _tables = new List<string>();
        List<QueryWhereClauseItem> _whereClause = new List<QueryWhereClauseItem>();
        
        #endregion

        #region Properties
        public QUERY_COMMAND Command
        {
            get { return _command; }
        }

        public string[] Tables
        {
            get { return _tables.ToArray(); }
        }

        public List<QueryWhereClauseItem> WhereClause
        {
            get { return _whereClause; }
        }
        #endregion

        #region Constructor
        public QueryToken()
        {

        }
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods 
        public void Tokenize(string query)
        {
            string currentItem = string.Empty;
            string[] splitStatement = query.Split(' ');

            //loop until we reach the end of the query
            for (int idx = 0; idx <= splitStatement.Length - 1; idx++)
            {
                currentItem = splitStatement[idx];
                if (_commandOperator.Contains(currentItem.ToUpper()))
                {
                    // set the command 
                    _command = (QUERY_COMMAND)Enum.Parse(typeof(QUERY_COMMAND), currentItem.ToUpper());

                    // from the command we get the columns
                    _columns = splitStatement[idx + 1];
                }

                if (currentItem.ToUpper() == "FROM")
                {
                    // FROM tables so take the next item
                    _tables.Add(splitStatement[idx + 1]);
                }

                if (_whereClauseOperators.Contains(currentItem.ToUpper()))
                {
                    // take the next three values
                    string col = splitStatement[idx + 1];
                    string op = splitStatement[idx + 2];
                    string val = splitStatement[idx + 3];

                    _whereClause.Add(new QueryWhereClauseItem(col, op, val));
                }
            }
        }
        #endregion
    }
}
