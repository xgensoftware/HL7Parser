using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HL7Parser.Models;
using HL7Parser.Parser;
namespace HL7Parser.Parser
{
/// <summary>
/// Created By: Anthony Sanfilippo
/// Create Date: 2017-02-08
/// Description: Parse a raw HL7message into a HL7Message object 
/// </summary>

    public class PipeParser : ParserBase
    {
        #region Member Variables 
        Token _messageToken;
        #endregion

        #region Constructor 
        public PipeParser()
            :base()
        {

        }
        #endregion

        #region Private Methods 
        private MSH CreateMessageHeader(string[] parsedMSH)
        {
            MSH msh = new MSH();

            if (parsedMSH.Length > 0)
            {
                //Parse the message header based on the |                
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

        private IEvent CreateEvent(string segmentName, List<Segment> segmentsConfig)
        {
            IEvent e = null;
            try
            {
                Type segmentType = Type.GetType(string.Format("HL7Parser.Models.{0}", segmentName));
                e = (IEvent)Activator.CreateInstance(segmentType);
            }
            catch (ArgumentNullException) { }

            if (e != null)
            {
                string[] messageSegmentData = this._messageToken.GetSegmentData(segmentName);
                foreach (Segment s in segmentsConfig)
                {
                    try
                    {
                        Models.Segment segment = new Models.Segment(s.Sequence, s.Length, s.Version, s.Name, s.DataType);
                        segment.SetValue(s.DataType,messageSegmentData[s.Sequence]);
                        e.AddSegment(segment);
                    }
                    catch (Exception ex)
                    {
                        this.LogErrorMessage(string.Format("CreateEvent failed on {0}.{1}. ERROR: {2}", segmentName, s.Name, ex.Message));
                    }
                }
            }
            else
            {
                this.LogInfoMessage(string.Format("No Segment class exists for {0}.", segmentName));
            }
            return e;
        }
                
        #endregion

        #region Public Methods 
        public HL7Message Parse(string message)
        {            
            string[] temp = message.Split(new string[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            for(int i=0; i <= temp.Length -1; i++)
            {
                temp[i].Trim();
            }
            this._messageToken = Tokenizer.CreateMessageToken(temp);
            HL7Message hl7 = new HL7Message(this._messageToken, message);           

            //Create the MSH segment of the message object
            hl7.MSH = this.CreateMessageHeader(this._messageToken.GetSegmentData("MSH"));
            hl7.MSH.Version = this._messageToken.MessageVersion;
            hl7.MSH.MessageType = this._messageToken.MessageType;
            hl7.MSH.EventType = this._messageToken.EventType;


            using (HL7DataEntities e = new HL7DataEntities())
            {
                //get all the trigger events based on Message type, event type, and version
                //Do not include MSH, those will be a manual process
                var triggerEvents = e.TriggerEvents
                    .Where(x => x.Version == this._messageToken.MessageVersion && x.MessageType == this._messageToken.MessageType && x.EventType == this._messageToken.EventType)
                    .Where(x => x.Segment != "MSH")
                    .OrderBy(x => x.Sequence)
                    .ToList();
                foreach (var tr in triggerEvents)
                {
                    var eventSegments = e.Segments
                        .Where(x => x.SegmentId == tr.Segment && x.Version == tr.Version)
                        .OrderBy(x => x.Sequence)
                        .ToList();

                    IEvent newEvent = this.CreateEvent(tr.Segment, eventSegments);
                    if(newEvent != null)
                        hl7.Events.Add(tr.Segment,newEvent);
                }
            }               



            return hl7;
        }
        #endregion
    }
}
