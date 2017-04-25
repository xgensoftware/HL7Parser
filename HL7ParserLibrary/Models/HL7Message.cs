
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace HL7Parser.Models
{
    /// <summary>
    /// HL7 Message object with segments and events
    /// Events: Dictionary object with HL7Segment.
    /// </summary>
    /*
    History

    *******************************************************
    Date        Author                  Description
    *******************************************************
    04/4/2017   Anthony Sanfilippo      Added ToString Override

    */
    public class HL7Message : ModelBase
    {
        #region Member Variables 
        Token _token = null;
        //ConcurrentBag<HL7EventSegment> _events;
        Dictionary<int, HL7Segment> _segments;
        #endregion

        #region Properties    
        public Token MessageToken
        {
            get { return _token; }
        }        

        public Dictionary<int,HL7Segment> Segments
        {
            get { return this._segments ; }
        }

        /// <summary>
        /// Comma seperated string of segment names
        /// </summary>
        public string ToSegmentString
        {
            get
            {
                StringBuilder s = new StringBuilder();
                foreach (HL7Segment seg in _segments.Values)
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
            this._segments = new Dictionary<int, HL7Segment>();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Add a new Segment object to the Event Collection
        /// </summary>
        /// <param name="e"></param>
        public void AddEventSegment(HL7Segment e)
        {
            int key = 0;

            if(this._segments.Count > 0)
            {
                key = this._segments.Keys.Max() + 1;
            }

            this._segments.Add(key, e);
        }


        //public string SegmentQueryParamter()
        //{
            
        //    StringBuilder s = new StringBuilder();
        //    foreach(HL7Segment seg in _events.Values)
        //    {
        //        s.Append(string.Format("'{0}',", seg.Name));
        //    }

        //    s.Remove(s.Length - 1, 1);

        //    return s.ToString();            
        //}

        public override string ToString()
        {
            if (_token != null)
            {
                return _token.MessageControlId;
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion
    }
}
