using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HL7Parser.Models;
using HL7Parser.Parser;
using HL7Parser.Repository;
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
        HL7SchemaRepository  _repo = null;
        #endregion

        #region Constructor 
        public PipeParser()
            :base()
        {
            this._repo = RepositoryFactory.CreateRepository<HL7SchemaRepository>();
        }
        #endregion

        #region Private Methods        

        private HL7EventSegment CreateEvent(TriggerEvent tr)
        {
            HL7EventSegment e = null;
            var segmentsConfig = this._repo.GetSegmentBy(tr.Version, tr.Segment);
            
            try
            {
                e = new HL7EventSegment(tr.EventType, tr.Segment, tr.Version, (int)tr.Sequence, (bool)tr.IsOptional, (bool)tr.IsRepeated);
            }
            catch (ArgumentNullException) { }

            if (e != null)
            {
                var segmentArray = this._hl7.MessageToken.GetSegmentData(tr.Segment);
                foreach (Segment s in segmentsConfig)
                {
                    try
                    {
                        HL7SegmentEvent segment = new HL7SegmentEvent(s.Sequence, s.Length, s.Version, s.Name, s.DataType, s.IsRequired, s.IsRepeating);
                        segment.SetValue(s.DataType, segmentArray[s.Sequence]);
                        e.AddSegmentEvent(segment);
                    }
                    catch { }
                }

            }
            else
            {
                this.LogInfoMessage(string.Format("No Segment class exists for {0}.", tr.Segment));
            }
                
            

            return e;
        }
        private HL7EventSegment CreateFromSegmentString(string rawSegment, TriggerEvent tr)
        {
            var segmentsConfig = this._repo.GetSegmentBy(tr.Version, tr.Segment);
            HL7EventSegment e = new HL7EventSegment(tr.EventType, tr.Segment, tr.Version, (int)tr.Sequence, (bool)tr.IsOptional, (bool)tr.IsRepeated);

            var segmentArray = rawSegment.Split(this._hl7.MessageToken.FieldSeparator);
            foreach (Segment s in segmentsConfig)
            {
                try
                {
                    HL7SegmentEvent segment = new HL7SegmentEvent(s.Sequence, s.Length, s.Version, s.Name, s.DataType, s.IsRequired, s.IsRepeating);
                    segment.SetValue(s.DataType, segmentArray[s.Sequence]);
                    e.AddSegmentEvent(segment);
                }
                catch { }
            }

            return e;
        }

        #endregion

        #region Public Methods 

        /// <summary>
        /// Parse HL7 message using the local DB for Segments and trigger events
        /// </summary>
        /// <param name="message">Raw HL7 formated file</param>
        /// <returns>HL7 object with segments and events</returns>
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

            this._hl7 = new HL7Message(tempMessage);

            //The Fields in the message should drive this, to handle multiple similar segments.
            List<TriggerEvent> triggerEvents = this._repo.GetTriggerEventsBy(this._hl7.MessageToken.MessageVersion, this._hl7.MessageToken.MessageType, this._hl7.MessageToken.EventType).AsParallel().ToList<TriggerEvent>();
            foreach (string s in this._hl7.MessageToken.Segments)
            {
                string segId = s.Substring(0, 3);
                TriggerEvent tr = triggerEvents.Where(x => x.Segment == segId).FirstOrDefault();

                HL7EventSegment newEvent = this.CreateFromSegmentString(s, tr);
                if (newEvent != null)
                    _hl7.AddEventSegment(newEvent);
            }

            return _hl7;
        }
        #endregion
    }
}
