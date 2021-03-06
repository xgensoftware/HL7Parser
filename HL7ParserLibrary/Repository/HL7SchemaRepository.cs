﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HL7Parser.Repository
{
    /// <summary>
    /// Repositry that handles getting trigger events and segments
    /// from the local SQLite DB.
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
            string entityName = string.Empty;
            switch (table.Name)
            {
                case "TriggerEvent":
                    TriggerEvent tr = entity as TriggerEvent;
                    entityName = string.Format("{0}_{1}:{2}", tr.MessageType, tr.EventType, tr.Segment);
                    this._dbCTX.TriggerEvents.Add(entity as TriggerEvent);
                    break;

                case "Segment":
                    Segment s = entity as Segment;
                    entityName = string.Format("{0}:{1}", s.SegmentId, s.Name);
                    this._dbCTX.Segments.Add(entity as Segment);
                    break;

                case "DataType":
                    DataType dt = entity as DataType;
                    entityName = string.Format("{0}:{1}", dt.Name, dt.Version);
                    this._dbCTX.DataTypes.Add(dt as DataType);
                    break;

                case "DataTypeColumn":
                    DataTypeColumn dtc = entity as DataTypeColumn;
                    entityName = string.Format("{0}:{1}_{2}", dtc.DataType1.Version, dtc.DataType1.Name, dtc.Name);
                    this._dbCTX.DataTypeColumns.Add(dtc);
                    break;
            }

            try
            {                
                this._dbCTX.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = string.Format("Error saving entity {0}. ERROR: {1}. INNER EXCEPTION: {2}", entityName, ex.Message,ex.InnerException);
                LogErrorMessage(message);
            }
        }

        public void Save()
        {
            this._dbCTX.SaveChanges();
        }

        public SegmentConfiguration GetSegmentConfigurationByVersion(string version)
        {
            return _dbCTX.SegmentConfigurations.Where(x => x.Version == version).FirstOrDefault();
        }

        public TriggerEvent[] GetTriggerEventsBy(string version, string message, string eventType)
        {

            TriggerEvent[] collection = _dbCTX.TriggerEvents
                                            .Where(x => x.Version == version && x.MessageType == message && x.EventType == eventType)
                                            .AsParallel()
                                            .OrderBy(x => x.Sequence)
                                            .ToArray<TriggerEvent>();

            if (collection.Length >0)
            {
                for (int idx = 0; idx <= collection.Count() - 1; idx++)
                {
                    collection[idx].SegmentCollection = GetSegmentBy(version, collection[idx].Segment);
                }
            }

            return collection;
        }

        public TriggerEvent[] GetAllTriggerEvents()
        {
            return _dbCTX.TriggerEvents.AsParallel().ToArray<TriggerEvent>();
        }

        public  Segment[] GetSegmentBy(string version, string segment)
        {
            Segment[] collection = null;

            try
            {
                collection = _dbCTX.Segments
                            .Where(x => x.Version == version && x.SegmentId == segment)
                            .AsParallel()
                            .OrderBy(x => x.Sequence)
                            .ToArray<Segment>();
            }
            catch { collection = new Segment[] { };  }


            return collection;
        }

        public string[] GetDistinctSegmentsBy(string version)
        {
            string sql = string.Format("select segmentId From Segment where version = '{0}' group by segmentId order by segmentId asc",version);
            return _dbCTX.Database.SqlQuery<string>(sql).ToArray();                      
        }

        public List<MessageType> GetMessageTypes()
        {
            return this._dbCTX.MessageTypes.Where(x => x.IsActive == true).OrderBy(x => x.MessageTypeId).ToList();
        }

        public List<EventType> GetEventTypes()
        {
            return this._dbCTX.EventTypes.Where(x => x.IsActive == true).OrderBy(x => x.EventType1).ToList();
        }

        public List<Version> GetVersions()
        {
            return _dbCTX.Versions.ToList();
        }

        public List<DataType> GetDataTypesBy(string hl7Version)
        {
            return _dbCTX.DataTypes.Where(x => x.Version == hl7Version).AsParallel().ToList();
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
