using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7Parser.DataTypes
{
    /// <summary>
    /// Extended Address
    /// </summary>
    public class XAD: BaseDataType,IDataType
    {
        #region Member Variables 
       
        string _streetAddress = string.Empty;
        string _city = string.Empty;
        string _state = string.Empty;
        string _zip = string.Empty;
        string _country = string.Empty;
        #endregion

        #region Properties
        public string StreetAddres
        {
            get { return this._streetAddress; }
        }

        public string City
        {
            get { return this._city; }
        }

        public string State
        {
            get { return this._state; }
        }

        public string Zip
        {
            get { return this._zip; }
        }

        public string Country
        {
            get { return this._country; }
        }
        #endregion

        #region Constructor 

        public XAD (string val)
        {
            _rawMessage = val;
            if (!string.IsNullOrEmpty(val))
            {
                string[] valSplit = val.Split('^');

                this._streetAddress = valSplit[0];                               

                if (valSplit.Count() > 6)
                {
                    this._city = valSplit[2];
                    this._state = valSplit[3];
                    this._zip = valSplit[4];
                    this._country = valSplit[5];
                }
            }
        }
        #endregion
    }
}
