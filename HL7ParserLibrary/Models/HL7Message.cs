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
        ConcurrentBag<EventSegment> _events;
        
        #endregion

        #region Properties    
        public Token MessageToken
        {
            get { return _token; }
        }
        
        public List<EventSegment> Events
        {
            get { return this._events.OrderBy(x => x.Sequence).ToList(); }
        }
        #endregion

        #region Constructor
        public HL7Message(string[] message)
        {
            this._token = new Token(message);
            this._events = new ConcurrentBag<EventSegment>();
        }

        #endregion

        #region Public Methods
        public void AddEventSegment(EventSegment e)
        {
            this._events.Add(e);
        }
        #endregion
    }
}
