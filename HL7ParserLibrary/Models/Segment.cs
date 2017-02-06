using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7Parser.Models
{
    public class Segment
    {
        #region Member Variables
        //This needs to be changed to OBJ and will be set based on the DB type
        string _value;
        #endregion

        #region Properties 
        public int Sequence { get; }

        public int Length { get; }

        public string Version { get; }

        public string Name { get; }

        public string Value {
            get { return this._value; }
        }
        #endregion

        #region Constructor
        public Segment(int sequence, int length, string version, string name)
        {
            this.Sequence = sequence;
            this.Length = length;
            this.Version = version;
            this.Name = name;
            this._value = string.Empty;
        }
        #endregion

        #region Public Methods
        public void SetValue(string obj)
        {
            this._value = obj;
        }
        #endregion
    }
}
