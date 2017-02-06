using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7Parser.Models
{
    public class HL7Message
    {
        #region Member Variables 
        Token _token = null;
        string _rawMessage = string.Empty;

        #endregion

        #region Properties    
        public MSH MSH { get; set; }

        #endregion

        #region Constructor
        public HL7Message(Token t, string rawMessage)
        {
            this._token = t;
            this._rawMessage = rawMessage;
        }

        #endregion
    }
}
