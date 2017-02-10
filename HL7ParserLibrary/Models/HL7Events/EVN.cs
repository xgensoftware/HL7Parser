using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL7Parser.Base;

namespace HL7Parser.Models
{
    public class EVN : BaseEvent, IEvent
    {
        #region Constructor 
        public EVN(string eventType, string name, string version, int seq, bool isOptional, bool isRepeated)
            :base()
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
