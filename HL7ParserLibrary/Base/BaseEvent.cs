using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL7Parser;
namespace HL7Parser.Base
{
    public abstract class BaseEvent
    {
        #region Member Variables 
        List<Models.HL7SegmentColumn> _segments;

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


        public List<Models.HL7SegmentColumn> SegmentEvents
        {
            get { return this._segments; }
        }
        #endregion

        #region Constructor 
        public BaseEvent()
        {
            this._segments = new List<Models.HL7SegmentColumn>();
        }
        #endregion

        #region Public Methods
        public Models.HL7SegmentColumn GetSegment(string name)
        {
            return this._segments.Where(x => x.Name == name).FirstOrDefault();
        }

        public void AddSegment(Models.HL7SegmentColumn s)
        {
            this._segments.Add(s);
        }

        #endregion
    }
}
