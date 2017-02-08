using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7Parser.Models
{
    public interface IEvent
    {
        //List<Models.Segment> Segments { get; }
        Segment GetSegment(string name);

        void AddSegment(Models.Segment s);
    }
}
