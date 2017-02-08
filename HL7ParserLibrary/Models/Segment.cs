using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL7Parser.DataTypes;
namespace HL7Parser.Models
{
    public class Segment
    {
        #region Member Variables        
        object _value;
        #endregion

        #region Properties 
        public long Sequence { get; }

        public long Length { get; }

        public string Version { get; }

        public string Name { get; }

        public string DataType { get;}

        public object Value {
            get
            {
                return this._value;
            }
        }
        #endregion

        #region Constructor
        public Segment(long sequence, long length, string version, string name, string dataType)
        {
            this.Sequence = sequence;
            this.Length = length;
            this.Version = version;
            this.Name = name;
            this.DataType = dataType;
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
        #endregion
    }
}
