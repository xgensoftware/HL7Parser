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
    public class MSG : CM_MSG
    {
        #region Member Variables 
        string _messageStructure = string.Empty;
        #endregion

        #region Properties

        public string MessageStructure
        {
            get { return _messageStructure; }
        }
        #endregion

        #region Constructor 
        public MSG(string val) : base(val)
        {
            if (!string.IsNullOrEmpty(val))
            {
                string[] valSplit = val.Split('^');

                if (valSplit.Length > 2)
                    _messageStructure = valSplit[2];
            }
        }
        #endregion
    }
}
