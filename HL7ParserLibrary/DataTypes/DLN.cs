using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7Parser.DataTypes
{
    /// <summary>
    /// Driver License Number
    /// </summary>
    public class DLN : BaseDataType, IDataType
    {
        #region Member Variables 
        string _licenseNumber = string.Empty;
        string _issuingState = string.Empty;
        string _expirationDate = string.Empty;
        #endregion

        #region Properties
        public string LicenseNumber
        {
            get { return _licenseNumber; }
        }

        public string IssuingState
        {
            get { return _issuingState; }
        }

        public string ExpirationDate
        {
            get { return _expirationDate; }
        }
        #endregion

        #region Constructor 
        public DLN(string val)
        {
            if(!string.IsNullOrEmpty(val))
            {
                _rawMessage = val;
                string[] valSplit = val.Split('^');

                _licenseNumber = valSplit[0];

                if(valSplit.Length >2)
                {
                    _issuingState = valSplit[1];
                    _expirationDate = valSplit[2];
                }
            }
        }
        #endregion
    }
}
