using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web.Script.Serialization;
using System.Text;

using HL7Parser.Parser;
using HL7Parser.Models;

namespace HL7Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HL7ParserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select HL7ParserService.svc or HL7ParserService.svc.cs at the Solution Explorer and start debugging.
    public class HL7ParserService : IHL7ParserService
    {
        public HL7Message ParseString(string message)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            PipeParser parser = new PipeParser();
            HL7Message hl7Message = null;

            try
            {
                hl7Message = parser.Parse(message);
            }
            catch(ParserException ex)
            {

            }

            return hl7Message;
            //if (hl7Message != null)
            //    return serializer.Serialize(hl7Message);
            //else
            //    return string.Empty;
        }
    }
}
