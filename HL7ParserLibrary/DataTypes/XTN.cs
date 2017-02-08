using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7Parser.DataTypes
{
    public class XTN : Object
    {
        #region Member Variables 
        string _phone = string.Empty;
        #endregion

        #region Properties
        public string PhoneNumber
        {
            get { return this._phone; }
        }
        #endregion

        #region Constructor 
        public XTN() { }

        public XTN(string val)
        {
            if (!string.IsNullOrEmpty(val))
            {
                string[] splitString = val.Split('^');

                this._phone = splitString[0];
            }
        }
        #endregion
    }
}
