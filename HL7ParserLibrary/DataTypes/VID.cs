using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7Parser.DataTypes
{
    /// <summary>
    /// Version Identifier
    /// </summary>
    public class VID : BaseDataType, IDataType
    {
        #region Member Variables 
        string _versionId = string.Empty;
        string _internationalizationCode = string.Empty;
        string _internationalVersionId = string.Empty;
        #endregion

        #region Properties
        public string VersionID
        {
            get { return _versionId; }
        }
        #endregion

        #region Constructor 
        public VID(string val)
        {
            if(!string.IsNullOrEmpty(val))
            {
                _rawMessage = val;
                string[] valSplit = val.Split('^');

                _versionId = valSplit[0];

                if(valSplit.Length > 2)
                {
                    _internationalizationCode = valSplit[1];
                    _internationalVersionId = valSplit[2];
                }
            }
        }
        #endregion
    }
}
