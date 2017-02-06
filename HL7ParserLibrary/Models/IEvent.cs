using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7Parser.Models
{
    public interface IEvent
    {
         Dictionary<string, Segment> Segments { get; set; }

        Segment GetSegment(string name);
    }
}
