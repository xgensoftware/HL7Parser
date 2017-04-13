using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7Parser.Models
{
    /// <summary>
    /// THis will be the new class for dynamic HL7Events based on the Segment and TriggerEvent Tables
    /// </summary>
    public class HL7Segment : Object
    {
        #region Member Variables 
        ConcurrentBag<HL7SegmentColumn> _segmentEvents;

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
        public List<HL7SegmentColumn> Segments
        {
            get { return _segmentEvents.OrderBy(x => x.Sequence).ToList<HL7SegmentColumn>(); }
        }
        #endregion

        #region Constructor 
        public HL7Segment(string eventType, string name, string version, int seq, bool isOptional, bool isRepeated)
        {
            this._eventType = eventType;
            this._name = name;
            this._version = version;
            this._sequence = seq;
            this._isOptional = isOptional;
            this._isRepeated = isRepeated;
            _segmentEvents = new ConcurrentBag<HL7SegmentColumn>();           
        }
        
        #endregion

        #region Public Method
        public void AddSegmentEvent(HL7SegmentColumn se)
        {
            this._segmentEvents.Add(se);
        }

        #endregion

        #region Override
        public override string ToString()
        {
            return string.Format("{0}_{1}",this._eventType,this._name);
        }
        #endregion
    }
}
