using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7Parser.DataTypes
{
    /// <summary>
    /// Message Type
    /// </summary>
    public class CM_MSG : BaseDataType, IDataType
    {
        #region Member Variables 
        protected string _messageType = string.Empty;
        protected string _triggerEvent = string.Empty;
        #endregion

        #region Properties
        public string MessageType
        {
            get { return _messageType; }
        }

        public string EventType
        {
            get { return _triggerEvent; }
        }
        #endregion

        #region Constructor 
        public CM_MSG(string val)
        {
            _rawMessage = val;
            if(!string.IsNullOrEmpty(val))
            {
                string[] valSplit = val.Split('^');
                _messageType = valSplit[0];

                if(valSplit.Length > 1)
                    _triggerEvent = valSplit[1];
            }
        }

        #endregion
    }
}
