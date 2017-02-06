using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL7Parser.Models;
using HL7Parser.Parser;
namespace HL7Parser.Parser
{
    public class PipeParser : ParserBase
    {

        #region Constructor 
        public PipeParser()
            :base()
        {

        }
        #endregion

        #region Private Methods 
        private MSH CreateMessageHeader(string header)
        {
            MSH msh = new MSH();

            if (!string.IsNullOrEmpty(header))
            {
                //Parse the message header based on the |
                string[] parsedMSH = header.Split('|');
                msh.SendingApplication = parsedMSH[2];
                msh.SendingFacility = parsedMSH[3];
                msh.ReceivingApplication = parsedMSH[4];
                msh.Security = parsedMSH[7];
                msh.MessageControlId = parsedMSH[9];


                int year = int.Parse(parsedMSH[6].Substring(0, 4));
                int month = int.Parse(parsedMSH[6].Substring(4, 2));
                int day = int.Parse(parsedMSH[6].Substring(6, 2));
                int hour = int.Parse(parsedMSH[6].Substring(8, 2));
                int minute = int.Parse(parsedMSH[6].Substring(10, 2));
                int seconds = int.Parse(parsedMSH[6].Substring(12, 2));
                msh.DateTimeOfMessage = new DateTime(year, month, day,hour,minute,seconds);
            }

            return msh;
        }
        #endregion

        #region Public Methods 
        public HL7Message Parse(string message)
        {
            HL7DataEntities e = new HL7DataEntities();
            string[] temp = message.Split(new string[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            for(int i=0; i <= temp.Length -1; i++)
            {
                temp[i].Trim();
            }

            Token t = Tokenizer.CreateMessageToken(temp);
            HL7Message hl7 = new HL7Message(t, message);

            //Create the MSH segment of the message object
            hl7.MSH = this.CreateMessageHeader(t.GetSegmentData("MSH"));
            hl7.MSH.Version = t.MessageVersion;
            hl7.MSH.MessageType = t.MessageType;
            hl7.MSH.EventType = t.EventType;


            //get all the trigger events based on Message type, event type, and version
            //Do not include MSH, those will be a manual process
            var triggerEvents = e.TriggerEvents
                .Where(x => x.Version == t.MessageVersion && x.MessageType == t.MessageType && x.EventType == t.EventType)
                .Where(x => x.Segment != "MSH")
                .OrderBy(x => x.Sequence)
                .ToList();
            foreach (var tr in triggerEvents)
            {

            }



            return hl7;
        }
        #endregion
    }
}
