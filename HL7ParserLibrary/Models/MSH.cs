using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7Parser.Models
{
    public class MSH
    {
        #region Member Variables 
        string _sendingApplication = string.Empty;
        string _sendingFacility = string.Empty;
        string _receivingApplication = string.Empty;
        string _dateTimeOfMessage = string.Empty;
        string _security = string.Empty;
        string _messageControlId = string.Empty;
        #endregion

        #region Properties
        public string SendingApplication { get; set; }

        public string SendingFacility { get; set; }

        public string ReceivingApplication { get; set; }

        public DateTime DateTimeOfMessage { get; set; }

        public string Security { get; set; }

        public string MessageControlId { get; set; }

        public string Version { get; set; }

        public string MessageType { get; set; }

        public string EventType { get; set; }
        #endregion

        #region Constructor 

        public MSH()
        {
            
        }
        #endregion

        #region Public Methods       
        
        #endregion
    }
}
