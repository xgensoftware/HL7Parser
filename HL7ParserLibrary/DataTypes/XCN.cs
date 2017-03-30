using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7Parser.DataTypes
{
    public class XCN : BaseDataType, IDataType
    {
        #region Memebr Variables 
        string _id = string.Empty;
        string _lastName = string.Empty;
        string _firstName = string.Empty;
        string _suffix = string.Empty;
        string _prefix = string.Empty;
        string _assignAuthority = string.Empty;
        string _assignFacility = string.Empty;   
        #endregion

        #region Properties 
        public string Id { get { return _id; } }

        public string LastName { get { return _lastName; } }

        public string FirstName { get { return _firstName; } }

        public string Suffix { get { return _suffix; } }

        public string Prefix { get { return _prefix; } }

        public string AssigningAuthority { get { return _assignAuthority; } }

        public string AssigningFacility { get { return _assignFacility; } }
        #endregion

        #region Constructor
        public XCN(string val)
        {
            _rawMessage = val;

            if (!string.IsNullOrEmpty(val))
            {
                if (val.IndexOf('^') > 0)
                {
                    // split the value on the ^ char
                    string[] values = val.Split('^');

                    // assign the properties based on below
                    this._id = values[0];
                    this._lastName = values[1];
                    this._firstName = values[2];
                }
                else
                {
                    this._id = val;
                }
            }
        }
        
        #endregion
    }
}
