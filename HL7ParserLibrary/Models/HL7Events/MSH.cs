using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL7Parser.Base;

namespace HL7Parser.Models
{
    public class MSH : BaseEvent, IEvent
    {
        #region Member Variables 
        //string _sendingApplication = string.Empty;
        //string _sendingFacility = string.Empty;
        //string _receivingApplication = string.Empty;
        //string _dateTimeOfMessage = string.Empty;
        //string _security = string.Empty;
        //string _messageControlId = string.Empty;
        //List<SegmentEvent> _segments;

        #endregion

        #region Properties
        //public string SendingApplication { get; set; }

        //public string SendingFacility { get; set; }

        //public string ReceivingApplication { get; set; }

        //public DateTime DateTimeOfMessage { get; set; }

        //public string Security { get; set; }

        //public string MessageControlId { get; set; }

        //public string Version { get; set; }

        //public string MessageType { get; set; }

        //public string EventType { get; set; }

        //public List<Models.SegmentEvent> SegmentEvents
        //{
        //    get { return this._segments; }
        //}
        #endregion

        #region Constructor 

        public MSH(string eventType, string name, string version, int seq, bool isOptional, bool isRepeated)
            : base()
        {
            _eventType = eventType;
            _name = name;
            _version = version;
            _sequence = seq;
            _isOptional = isOptional;
            _isRepeated = isRepeated;
        }
        #endregion

        #region Public Methods       

        #endregion
    }
}
