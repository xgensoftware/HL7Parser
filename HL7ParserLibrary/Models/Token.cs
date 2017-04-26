using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace HL7Parser.Models
{
    /// <summary>
    /// HL7 token object that holds the respective identifing portions of the raw HL7 message
    /// </summary>
    public class Token : ModelBase
    {
        #region Member Variables 
        char _fieldSeparator = '|';
        char _encodingCharacter = '^';
        string _messageVersion = string.Empty;
        string _messageType = string.Empty;
        string _eventType = string.Empty;
        string _messageControlId = string.Empty;   

        string[] _segment = null;
        //Dictionary<string,string> _segment = null;

        StringBuilder _rawMessage = new StringBuilder();      
        #endregion

        #region Properties 
 
        public char EncodingCharacter
        {
            get { return _encodingCharacter; }
        }

        public char FieldSeparator
        {
            get { return _fieldSeparator; }
        }

        public string MessageVersion
        {
            get { return _messageVersion; }
        }

        public string MessageType
        {
            get { return _messageType; }
        }

        public string EventType
        {
            get { return _eventType; }
        }
        
        public string MessageControlId
        {
            get { return _messageControlId; }
        }

        /// <summary>
        /// Array holding the raw segments from the HL7 message
        /// </summary>
        public string[] Segments
        {
            get { return this._segment; }
        }

        /// <summary>
        /// Unformated HL7 string
        /// </summary>
        public string RawMessage
        {
            get { return _rawMessage.ToString(); }
        }
        #endregion
        
        public Token(string[] message)
        {
            //Parse the message header based on the |
            string[] parsedMSH = message[0].Split('|');

            char fieldSep = Convert.ToChar(message[0].Substring(3, 1));
            char encoding = Convert.ToChar(message[0].Substring(4, 1));
            var trigger = parsedMSH[8].Split('^');

            //fieldSep, encoding, parsedMSH[11], trigger[0], trigger[1]
            this._fieldSeparator = fieldSep;
            this._encodingCharacter = encoding;
            this._messageVersion = parsedMSH[11];
            this._messageControlId = parsedMSH[9];
            this._messageType = trigger[0];
            this._eventType = trigger[1];

            this._segment = new string[message.Length];
            for (int idx = 0; idx <= message.Length - 1; idx++)
            {
                this._segment[idx] = message[idx];
                this._rawMessage.AppendLine(message[idx]);
            }

        }

        public string[] GetSegmentData(string segment)
        {
            string[] value = { };

            try
            {
                return this._segment.Where(x => x.Substring(0, 3) == segment).FirstOrDefault().ToString().Split(this._fieldSeparator);
            }
            catch { }

            return value;
        }
    }
}
