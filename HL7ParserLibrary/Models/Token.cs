using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7Parser.Models
{
    public class Token
    {
        #region Member Variables 
        char _fieldSeparator = '|';
        char _encodingCharacter = '^';
        string _messageVersion = string.Empty;
        string _messageType = string.Empty;
        string _eventType = string.Empty;

        Dictionary<string,string> _segment = null;      
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
        
        #endregion

        public Token(char fieldSep, char encoding, string version, string messageType, string eventType)
        {
            this._fieldSeparator = fieldSep;
            this._encodingCharacter = encoding;
            this._messageVersion = version;
            this._messageType = messageType;
            this._eventType = eventType;
            this._segment = new Dictionary<string, string>();
        }

        public void AddSegment(string key, string data)
        {
            this._segment.Add(key, data);
        }
        public string[] GetSegmentData(string segment)
        {
            string[] value = { };

            try
            {
                value = this._segment.Where(x => x.Key == segment).FirstOrDefault().Value.Split(this._fieldSeparator);
            }
            catch { }

            return value;
        }

    }
}
