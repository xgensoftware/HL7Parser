using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL7Parser.Base;

namespace HL7Parser.Models
{
    public class PID : BaseEvent, IEvent
    {
        #region Member Variables 

        #endregion

        #region Properties

        #endregion

        #region Constructor 
        public PID(string eventType, string name, string version, int seq, bool isOptional, bool isRepeated) : base()
        {
            _eventType = eventType;
            _name = name;
            _version = version;
            _sequence = seq;
            _isOptional = isOptional;
            _isRepeated = isRepeated;
        }
        #endregion
    }
}
