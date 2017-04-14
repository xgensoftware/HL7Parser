using System;
using System.Linq;
using HL7Parser.Models;
using HL7Parser.Repository;
namespace HL7Parser.Parser
{
/// <summary>
/// Created By: Anthony Sanfilippo
/// Create Date: 2017-02-08
/// Description: Parse a raw HL7message into a HL7Message object 
/// </summary>
    public class ParserException : Exception
    {
        public ParserException() { }

        public ParserException(string message) : base(message)
        { }
    }

    public class PipeParser : ParserBase
    {
        #region Member Variables 
        HL7Message _hl7 = null;
        HL7SchemaRepository  _repo = null;

       
        #endregion

        #region Properties 

        /// <summary>
        /// Set to enable logging during parsing
        /// </summary>
        public bool EnableLogging
        {
            get { return _loggingEnabled; }
            set { _loggingEnabled = value; }
        }
        #endregion

        #region Constructor 
        public PipeParser()
            :base()
        {
            this._repo = RepositoryFactory.CreateRepository<HL7SchemaRepository>();
        }
        #endregion

        #region Private Methods        

        //private HL7Segment CreateEvent(TriggerEvent tr)
        //{
        //    HL7Segment e = null;
        //    var segmentsConfig = this._repo.GetSegmentBy(tr.Version, tr.Segment);
            
        //    try
        //    {
        //        e = new HL7Segment(tr.EventType, tr.Segment, tr.Version, (int)tr.Sequence, (bool)tr.IsOptional, (bool)tr.IsRepeated);
        //    }
        //    catch (ArgumentNullException)
        //    {
               
        //    }

        //    if (e != null)
        //    {
        //        var segmentArray = this._hl7.MessageToken.GetSegmentData(tr.Segment);
        //        foreach (Segment s in segmentsConfig)
        //        {
        //            try
        //            {
        //                HL7SegmentColumn segment = new HL7SegmentColumn(s.Sequence, s.Length, s.Version, s.Name, s.DataType, s.IsRequired, s.IsRepeating);
        //                segment.SetValue(s.DataType, segmentArray[s.Sequence]);
        //                e.AddSegmentEvent(segment);
        //            }
        //            catch { }
        //        }

        //    }
        //    else
        //    {
        //        this.LogInfoMessage(string.Format("No Segment class exists for {0}.", tr.Segment));
        //    }
                
            

        //    return e;
        //}

        private HL7Segment CreateFromSegmentString(string rawSegment, TriggerEvent tr)
        {
            HL7Segment e = null;
            Segment[] segmentsConfig = tr.SegmentCollection;
            
            if (segmentsConfig != null)
            {
                e = new HL7Segment(tr.EventType, tr.Segment, tr.Version, (int)tr.Sequence, (bool)tr.IsOptional, (bool)tr.IsRepeated);

                var segmentArray = rawSegment.Split(this._hl7.MessageToken.FieldSeparator);
                foreach (Segment s in segmentsConfig)
                {
                    try
                    {
                        HL7SegmentColumn segment = new HL7SegmentColumn(s.Sequence, s.Length, s.Version, s.Name, s.DataType, s.IsRequired, s.IsRepeating);
                        segment.SetValue(s.DataType, segmentArray[s.Sequence]);
                        e.AddSegmentEvent(segment);
                    }
                    catch { }
                }                   
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
            base.LogInfoMessage(string.Format("Creating HL7 message object from {0}",message));

            //The Fields in the message should drive this, to handle multiple similar segments.
            TriggerEvent[] triggerEvents = this._repo.GetTriggerEventsBy(this._hl7.MessageToken.MessageVersion, this._hl7.MessageToken.MessageType, this._hl7.MessageToken.EventType).AsParallel().ToArray<TriggerEvent>();

            base.LogInfoMessage(string.Format("Fetching TriggerEvent configuration for verions {0} {1}_{2}", this._hl7.MessageToken.MessageVersion
                , this._hl7.MessageToken.MessageType
                , this._hl7.MessageToken.EventType));

            if (triggerEvents.Length== 0)
            {
                throw new ParserException(string.Format("No trigger events found for version {0}, message type {1}_{2}", this._hl7.MessageToken.MessageVersion, this._hl7.MessageToken.MessageType, this._hl7.MessageToken.EventType));                
            }
            else
            {
                foreach (string s in this._hl7.MessageToken.Segments)
                {
                    string segId = s.Substring(0, 3);
                    base.LogInfoMessage(string.Format("Searching TriggerEvent configuration for segment {0}", segId));

                    TriggerEvent tr = triggerEvents.Where(x => x.Segment == segId).FirstOrDefault();
                    if (tr != null)
                    {
                        HL7Segment newEvent = this.CreateFromSegmentString(s, tr);
                        base.LogInfoMessage(string.Format("Successfully created HL7 segment {0} for TriggerEvent {1}_{2}", newEvent.Name, tr.MessageType,tr.EventType));
                        if (newEvent != null)
                            _hl7.AddEventSegment(newEvent);
                    }
                }

                return _hl7;
            }
        }
        #endregion
    }
}
