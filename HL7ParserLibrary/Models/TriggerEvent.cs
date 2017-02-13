using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7Parser
{
    public partial class TriggerEvent
    {
        #region Member Variables 

        #endregion

        #region Properties
        public string Trigger
        {
            get
            {
                return string.Format("{0}_{1}", this.MessageType, this.EventType);
            }
        }
        #endregion

        #region Constructor 

        #endregion
    }
}
