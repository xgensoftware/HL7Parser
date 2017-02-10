using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7Parser.DataTypes
{
    public abstract class BaseDataType : Object
    {
        #region Member Variables 
        protected string _rawMessage = string.Empty;
        #endregion

        #region Properties
        public override string ToString()
        {
            return this._rawMessage;
        }
        #endregion

        #region Constructor 

        #endregion
    }
}
