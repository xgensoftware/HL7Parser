using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7Parser.Models
{
    public interface IEvent
    {
        #region Properties
        string EventType { get; }
        string Name { get; }
        string Version { get; }
        int Sequence { get; }
        bool IsOptional { get; }
        bool IsRepeated { get; }

        List<Models.HL7SegmentField> SegmentEvents { get; }
        #endregion

        HL7SegmentField GetSegment(string name);

        void AddSegment(Models.HL7SegmentField s);
    }
}
