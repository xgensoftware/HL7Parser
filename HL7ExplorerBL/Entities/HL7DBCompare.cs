using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7ExplorerBL.Entities
{
    public class HL7DBCompare : Object
    {
        #region Member Variables 

        #endregion

        #region Properties
        public string SegmentName { get; set;}

        public string SegmentValue { get; set; }

        public string DBColumn { get; set; }

        public string DBValue { get; set;}
        #endregion

        #region Constructor 
        public HL7DBCompare() { }
        #endregion
    }
}
