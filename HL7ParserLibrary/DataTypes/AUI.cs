using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7Parser.DataTypes
{
    /// <summary>
    /// Authorization Information
    /// </summary>
    public class AUI : BaseDataType, IDataType
    {
        #region Member Variables
        string _authorizationNumber = string.Empty;
        string _date = string.Empty;
        string _source = string.Empty;
        #endregion

        #region Properties

        public string AuthorizationNumber
        {
            get { return _authorizationNumber; }
        }

        public string Date
        {
            get { return _date; }
        }

        public string Source
        {
            get { return _source; }
        }

        #endregion

        #region Constructor

        public AUI(string val)
        {
            if(!string.IsNullOrEmpty(val))
            {
                _rawMessage = val;
                string[] valSplit = val.Split('^');
                try
                {
                    _authorizationNumber = valSplit[0];
                    _date = valSplit[1];
                    _source = valSplit[2];
                }
                catch { }
            }
        }

        #endregion
    }
}
