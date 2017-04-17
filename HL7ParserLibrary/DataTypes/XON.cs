using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7Parser.DataTypes
{
    /// <summary>
    /// Extended Composite Name and Identification Number for Organizations
    /// </summary>
    public class XON : BaseDataType, IDataType
    {
        #region Member Variables 
        string _organizationName = string.Empty;
        string _organizationNameTypeCode = string.Empty;
        string _idNumber = string.Empty;
        string _checkDigit = string.Empty;
        string _checkDigitScheme = string.Empty;
        string _assigningAuthority = string.Empty;
        string _identifierTypeCode = string.Empty;
        string _assigningFacility = string.Empty;
        string _nameRepCode = string.Empty;
        string _organizationId = string.Empty;
        #endregion

        #region Properties
        public string OrganizationName
        {
            get { return _organizationName; }
        }

        #endregion

        #region Constructor 
        public XON(string val)
        {
            if(!string.IsNullOrEmpty(val))
            {
                _rawMessage = val;
                string[] valSplit = val.Split('^');

                _organizationName = valSplit[0];                
            }
        }
        #endregion
    }
}
