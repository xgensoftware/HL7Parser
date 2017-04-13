using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL7Parser.DataTypes;
namespace HL7Parser.Models
{
    public class HL7SegmentColumn
    {
        #region Member Variables        
        object _value;

        long _sequence = 0;
        long _length = 0;
        string _version = string.Empty;
        string _name = string.Empty;
        string _dataType = string.Empty;
        bool _isRequired = false;
        bool _isRepeating = false;
        #endregion

        #region Properties 
        public long Sequence { get { return _sequence; } }

        public long Length { get { return _length; } }

        public string Version { get { return _version; } }

        public string Name { get { return _name; } }

        public string DataType { get { return _dataType; } }

        public bool IsRequired { get { return _isRequired; } }

        public bool IsRepeating { get { return _isRepeating; } }

        public object Value {
            get
            {
                return this._value;
            }
        }
        #endregion

        #region Constructor
        public HL7SegmentColumn(long sequence, long length, string version, string name, string dataType,bool isRequired, bool isRepeating)
        {
            this._sequence = sequence;
            this._length = length;
            this._version = version;
            this._name = name;
            this._dataType = dataType;
            this._isRequired = isRequired;
            this._isRepeating = isRepeating;
            this._value = string.Empty;
            
        }
        #endregion

        #region Public Methods
        public void SetValue(string dataType, object obj)
        {
            Type type = Type.GetType(string.Format("HL7Parser.DataTypes.{0}",dataType));

            if(type != null)
            {
                this._value = (IDataType)Activator.CreateInstance(type,obj);
            }
            else
            {
                this._value = obj;
            }            
        }

        public override string ToString()
        {
            return this._name;
        }
        #endregion

    }
}
