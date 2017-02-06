using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7Parser.Base
{
    public abstract class BaseEvent
    {
        #region Member Variables 
        Dictionary<string, Segment> _segments;
        #endregion

        #region Constructor 
        public BaseEvent()
        {
            this._segments = new Dictionary<string, Segment>();
        }
        #endregion

        #region Public Methods
        public Segment GetSegment(string name)
        {
            return this._segments.Where(x => x.Key == name).FirstOrDefault().Value;
        }
        #endregion
    }
}
