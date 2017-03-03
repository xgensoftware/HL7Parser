using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace HL7Parser.Models
{
    /// <summary>
    /// HL7 Message object with segments and events
    /// </summary>
    public class HL7Message
    {
        #region Member Variables 
        Token _token = null;
        //ConcurrentBag<HL7EventSegment> _events;
        Dictionary<int, HL7EventSegment> _events;
        #endregion

        #region Properties    
        public Token MessageToken
        {
            get { return _token; }
        }        

        public Dictionary<int,HL7EventSegment> Events
        {
            get { return this._events ; }
        }

        public string ToSegmentString
        {
            get
            {
                StringBuilder s = new StringBuilder();
                foreach (HL7EventSegment seg in _events.Values)
                {
                    s.Append(string.Format("{0},", seg.Name));
                }

                s.Remove(s.Length - 1, 1);

                return s.ToString();
            }
        }
        #endregion

        #region Constructor
        public HL7Message(string[] message)
        {
            this._token = new Token(message);
            this._events = new Dictionary<int, HL7EventSegment>();
        }

        #endregion

        #region Public Methods
        public void AddEventSegment(HL7EventSegment e)
        {
            int key = 0;

            if(this._events.Count > 0)
            {
                key = this._events.Keys.Max() + 1;
            }

            this._events.Add(key, e);
        }

        public string SegmentQueryParamter()
        {
            
            StringBuilder s = new StringBuilder();
            foreach(HL7EventSegment seg in _events.Values)
            {
                s.Append(string.Format("'{0}',", seg.Name));
            }

            s.Remove(s.Length - 1, 1);

            return s.ToString();            
        }

        
        #endregion
    }
}
