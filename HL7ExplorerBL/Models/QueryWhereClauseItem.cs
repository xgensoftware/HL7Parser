using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7ExplorerBL.Models
{
    public class QueryWhereClauseItem
    {
        #region Public Properties

        public string Column { get; set; }

        public string Operator { get; set;}

        public string Value { get; set; }
        #endregion

        #region Constructor 
        public QueryWhereClauseItem(string column, string op, string value)
        {
            Column = column;
            Operator = op;
            Value = value;
        }
        #endregion
    }
}
