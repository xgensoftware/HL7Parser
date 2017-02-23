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
        ConcurrentBag<HL7EventSegment> _events;
        
        #endregion

        #region Properties    
        public Token MessageToken
        {
            get { return _token; }
        }
        
        public List<HL7EventSegment> Events
        {
            get { return this._events.OrderBy(x => x.Sequence).ToList(); }
        }
        #endregion

        #region Constructor
        public HL7Message(string[] message)
        {
            this._token = new Token(message);
            this._events = new ConcurrentBag<HL7EventSegment>();
        }

        #endregion

        #region Public Methods
        public void AddEventSegment(HL7EventSegment e)
        {
            this._events.Add(e);
        }
        #endregion
    }
}
