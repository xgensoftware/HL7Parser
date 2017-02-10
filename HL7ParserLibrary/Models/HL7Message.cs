using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7Parser.Models
{
    public class HL7Message
    {
        #region Member Variables 
        Token _token = null;
        List<IEvent> _events;
        MSH _msh = null;
        #endregion

        #region Properties    
        public Token MessageToken
        {
            get { return _token; }
        }
        
        //public MSH MSH
        //{
        //    get { return _msh; }
        //}

        public List<IEvent> Events
        {
            get { return this._events; }
            set { this._events = value; }
        }
        #endregion

        #region Constructor
        public HL7Message(string[] message)
        {
            //this._msh = new MSH();
            this._token = new Token(message);
            this._events = new List<IEvent>();

            //string[] parsedMSH = this._token.GetSegmentData("MSH");
            //if (parsedMSH.Length > 0)
            //{
            //    //Parse the message header based on the |                
            //    this._msh.SendingApplication = parsedMSH[2];
            //    this._msh.SendingFacility = parsedMSH[3];
            //    this._msh.ReceivingApplication = parsedMSH[4];
            //    this._msh.Security = parsedMSH[7];
            //    this._msh.MessageControlId = parsedMSH[9];
            //    this._msh.Version = this._token.MessageVersion;
            //    this._msh.MessageType = this._token.MessageType;
            //    this._msh.EventType = this._token.EventType;

            //    int year = int.Parse(parsedMSH[6].Substring(0, 4));
            //    int month = int.Parse(parsedMSH[6].Substring(4, 2));
            //    int day = int.Parse(parsedMSH[6].Substring(6, 2));
            //    int hour = int.Parse(parsedMSH[6].Substring(8, 2));
            //    int minute = int.Parse(parsedMSH[6].Substring(10, 2));
            //    int seconds = int.Parse(parsedMSH[6].Substring(12, 2));
            //    this._msh.DateTimeOfMessage = new DateTime(year, month, day, hour, minute, seconds);
            //}
        }

        #endregion

        #region Public Methods
        public void AddEventSegment(IEvent e)
        {
            this._events.Add(e);
        }
        #endregion
    }
}
