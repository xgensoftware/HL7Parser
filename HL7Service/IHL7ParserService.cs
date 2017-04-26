using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HL7Parser.Models;
namespace HL7Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHL7ParserService" in both code and config file together.
    [ServiceContract]
    public interface IHL7ParserService
    {
        [OperationContract]
         HL7Message ParseString(string message);
    }

}
