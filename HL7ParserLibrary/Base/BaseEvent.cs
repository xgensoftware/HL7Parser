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
        List<Models.Segment> _segments;
        #endregion

        #region Properties 
        
        #endregion

        #region Constructor 
        public BaseEvent()
        {
            this._segments = new List<Models.Segment>();
        }
        #endregion

        #region Public Methods
        public Models.Segment GetSegment(string name)
        {
            return this._segments.Where(x => x.Name == name).FirstOrDefault();
        }

        public void AddSegment(Models.Segment s)
        {
            this._segments.Add(s);
        }

        #endregion
    }
}
