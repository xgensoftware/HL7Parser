using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HL7Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHL7ParserService" in both code and config file together.
    [ServiceContract]
    public interface IHL7ParserService
    {
        [OperationContract]
        void ParseString(string[] message);
    }
}
