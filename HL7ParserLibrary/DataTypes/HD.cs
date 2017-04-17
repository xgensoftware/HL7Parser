using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7Parser.DataTypes
{
    /// <summary>
    /// HierarchicDesignator
    /// </summary>
    public class HD : BaseDataType, IDataType
    {
        #region Member Variables
        string _namespaceId = string.Empty;
        string _universalId = string.Empty;
        string _universalIdType = string.Empty;

        #endregion

        #region Propteries

        public string NamespaceId
        {
            get { return _namespaceId; }
        }

        public string UniversalId
        {
            get { return _universalId; }
        }

        public string UniversalIdType
        {
            get { return _universalIdType; }
        }
        #endregion

        #region Constructor
        public HD(string val)
        {
            if(!string.IsNullOrEmpty(val))
            {
                _rawMessage = val;
                string[] valSplit = val.Split('^');
                _namespaceId = valSplit[0];

                if(valSplit.Length > 2)
                {
                    _universalId = valSplit[1];
                    _universalIdType = valSplit[2];
                }
            }
        }

        #endregion
    }
}
