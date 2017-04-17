using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7Parser.DataTypes
{
    /// <summary>
    /// Extended Person Name
    /// </summary>
    public class XPN : BaseDataType, IDataType
    {
        #region Member Variables 
        string _lastName = string.Empty;
        string _firstName = string.Empty;
        string _mi = string.Empty;
        #endregion

        #region Properties
        public string FirstName
        {
            get { return this._firstName; }
        }

        public string LastName
        {
            get { return this._lastName; }
        }

        public string MiddleInitial
        {
            get { return this._mi; }
        }
        #endregion

        #region Constructor

        public XPN(string val)
        {
            _rawMessage = val;

            if(!string.IsNullOrEmpty(val))
            {
                if (val.Contains('^'))
                {
                    string[] splitString = val.Split('^');

                    this._lastName = splitString[0];
                    this._firstName = splitString[1];

                    if (splitString.Count() > 2)
                    {
                        this._mi = splitString[2];
                    }
                }
                else
                    this._lastName = val;
            }
        }

        #endregion
    }
}
