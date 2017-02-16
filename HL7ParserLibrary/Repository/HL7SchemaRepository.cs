using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7Parser.Repository
{
    /// <summary>
    /// Get HL7 schema based on Version and trigger event (i.e ADT_A31)
    /// </summary>
    public class HL7SchemaRepository : BaseRepository, IRepository
    {
        #region Member Variables 
        
        #endregion

        #region Properties

        #endregion

        #region Constructor 
        public HL7SchemaRepository()
        {
            this._dbCTX = new HL7DataEntities();
        }
        #endregion

        #region Public Methods
        public void AddNew<T>(T entity)
        {
            Type table = typeof(T);
            switch(table.Name)
            {
                case "TriggerEvent":
                    this._dbCTX.TriggerEvents.Add(entity as TriggerEvent);
                    break;

                case "Segment":
                    this._dbCTX.Segments.Add(entity as Segment);
                    break;
            }

            this._dbCTX.SaveChanges();         
        }

        public void Save()
        {
            this._dbCTX.SaveChanges();
        }

        public List<TriggerEvent> GetTriggerEventsBy(string version, string message, string eventType)
        {
            
            return  _dbCTX.TriggerEvents
                    .Where(x => x.Version == version && x.MessageType == message && x.EventType == eventType)
                    .OrderBy(x => x.Sequence)
                    .ToList();
        }

        public List<Segment> GetSegmentBy(string version, string segment)
        {
            return _dbCTX.Segments
                    .Where(x => x.Version == version && x.SegmentId == segment)
                    .OrderBy(x => x.Sequence)
                    .ToList();
        }

        public List<MessageType> GetMessageTypes()
        {
            return this._dbCTX.MessageTypes.Where(x => x.IsActive == true).OrderBy(x => x.MessageTypeId).ToList();
        }

        public List<EventType> GetEventTypes()
        {
            return this._dbCTX.EventTypes.Where(x => x.IsActive == true).OrderBy(x => x.EventType1).ToList();
        }

        public void Dispose()
        {
            if (this._dbCTX != null)
            {
                this._dbCTX.Dispose();
            }
        }

        #endregion
    }
}
