using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7Parser.Models
{
    /// <summary>
    /// THis will be the new class for dynamic HL7Events based on the Segment and TriggerEvent Tables
    /// </summary>
    public class EventSegment : Object
    {
        #region Member Variables 
        List<Models.SegmentEvent> _segmentEvents;

        protected string _eventType = string.Empty;
        protected string _name = string.Empty;
        protected string _version = string.Empty;
        protected int _sequence = -1;
        protected bool _isOptional = true;
        protected bool _isRepeated = false;
        #endregion

        #region Properties
        public string EventType
        {
            get { return _eventType; }
        }

        public string Name
        {
            get { return _name; }
        }

        public string Version
        {
            get { return _version; }
        }

        public int Sequence
        {
            get { return _sequence; }
        }

        public bool IsOptional
        {
            get { return _isOptional; }
        }

        public bool IsRepeated
        {
            get { return _isRepeated; }
        }
        public List<SegmentEvent> Segments { get; }
        #endregion

        #region Constructor 
        public EventSegment(IEvent e)
        {
            _segmentEvents = new List<SegmentEvent>();            
        }
        
        #endregion

        #region Public Method
        public void AddSegmentEvent(SegmentEvent se)
        {
            this._segmentEvents.Add(se);
        }

        #endregion
    }
}
