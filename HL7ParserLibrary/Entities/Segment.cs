using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7Parser
{
    /// <summary>
    /// Partial class for DB entity
    /// </summary>
    public partial class Segment
    {
        public override string ToString()
        {
            return string.Format("{0}_{1}",SegmentId,Name);
        }
    }
}
