using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HL7ExplorerBL.QueryParser
{
    public class QueryParser
    {
        #region Member Variables
        const string _commandPattern = @" ^\w+";
        
        QueryToken _token = null;
        #endregion

        #region Public Properties 

        public QueryToken Token
        {
            get { return _token; }
        }
        #endregion

        #region Constructor 
        public QueryParser()
        {
            
        }
        #endregion

        #region Public Methods 
        public void TokenizeQuery(string queryToParse)
        {
            _token = new QueryToken();

            _token.Command = Regex.Match(queryToParse.ToLower(), _commandPattern).Value;
        }
        #endregion
    }
}
