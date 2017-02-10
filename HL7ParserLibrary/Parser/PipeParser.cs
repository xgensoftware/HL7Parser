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
        HL7Message _hl7 = null;
        HL7DataEntities _dbCTX = null;
        #endregion

        #region Constructor 
        public PipeParser()
            :base()
        {
            _dbCTX = new HL7DataEntities();
        }
        #endregion

        #region Private Methods        

        private IEvent CreateEvent(TriggerEvent tr, List<Segment> segmentsConfig)
        {
            IEvent e = null;
            try
            {
                Type segmentType = Type.GetType(string.Format("HL7Parser.Models.{0}", tr.Segment));
                e = (IEvent)Activator.CreateInstance(segmentType,tr.EventType,tr.Segment,tr.Version,(int)tr.Sequence,(bool)tr.IsOptional,(bool)tr.IsRepeated);
            }
            catch (ArgumentNullException) { }

            if (e != null)
            {
                string[] messageSegmentData = this._hl7.MessageToken.GetSegmentData(tr.Segment);
                foreach (Segment s in segmentsConfig)
                {
                    try
                    {
                        SegmentEvent segment = new SegmentEvent(s.Sequence, s.Length, s.Version, s.Name, s.DataType, s.IsRequired,s.IsRepeating);
                        segment.SetValue(s.DataType,messageSegmentData[s.Sequence]);
                        e.AddSegment(segment);
                    }
                    catch (Exception ex)
                    {
                        this.LogErrorMessage(string.Format("CreateEvent failed on {0}.{1}. ERROR: {2}", tr.Segment, s.Name, ex.Message));
                    }
                }
            }
            else
            {
                this.LogInfoMessage(string.Format("No Segment class exists for {0}.", tr.Segment));
            }
            return e;
        }
        
        #endregion

        #region Public Methods 
        public HL7Message Parse(string message)
        {            
            string[] tempMessage = message.Split(new string[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            for(int i=0; i <= tempMessage.Length -1; i++)
            {
                string segment = tempMessage[i].Substring(0, 3);
                if (segment == "MSH")
                {
                    tempMessage[i] = string.Format("{0}", tempMessage[i]);
                }

                tempMessage[i].Trim();
            }

            _hl7 = new HL7Message(tempMessage);

            var triggerEvents = _dbCTX.TriggerEvents
                    .Where(x => x.Version == _hl7.MessageToken.MessageVersion && x.MessageType == _hl7.MessageToken.MessageType && x.EventType == _hl7.MessageToken.EventType)
                    .OrderBy(x => x.Sequence)
                    .ToList();

            foreach (var tr in triggerEvents)
            {
                var eventSegments = _dbCTX.Segments
                    .Where(x => x.SegmentId == tr.Segment && x.Version == tr.Version)
                    .OrderBy(x => x.Sequence)
                    .ToList();
                IEvent newEvent = this.CreateEvent(tr, eventSegments);
                if (newEvent != null)
                    _hl7.AddEventSegment(newEvent);
            }

            return _hl7;
        }
        #endregion
    }
}
