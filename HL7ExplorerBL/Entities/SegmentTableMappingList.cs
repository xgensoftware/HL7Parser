using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using com.Xgensoftware.Core;
using HL7Core;
using HL7ExplorerBL.Repository;

namespace HL7ExplorerBL.Entities
{
    [Serializable]
    public class SegmentTableMappingList 
    {
        #region Member Variables 
        SegmentMappingRepository _repo = null;

        List<SegmentTableMapping> _segmentMappings = null;

        string _messageType = string.Empty;
        string _eventType = string.Empty;
        string _version = string.Empty;
        #endregion

        #region Properties
        public string EventType
        {
            get { return _eventType; }
            set { _eventType = value; }
        }

        public string MessageType
        {
            get { return _messageType; }
            set { _messageType = value; }
        }

        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }

        public List<SegmentTableMapping> SegmentMappings
        {
            get { return this._segmentMappings; }
            set { this._segmentMappings = value; }
        }

        public int Count
        {
            get { return this._segmentMappings.Count(); }
        }
        #endregion

        #region Private Methods 
        
        #endregion

        #region Constructor 
        public SegmentTableMappingList() {

            this._segmentMappings = new List<SegmentTableMapping>();
            try
            {
                _repo = new SegmentMappingRepository(AppConfiguration.DBProvider, AppConfiguration.DBConnection);
            }
            catch { }

            
        }
        #endregion

        #region Public Methods
        public void GetMappingFile(string pathToMappingFile)
        {
            string xml = File.ReadAllText(pathToMappingFile);

            var tempMappings = xml.FromXML<SegmentTableMappingList>();

            // check to make sure the XML serialized correctly
            if (tempMappings == null)
            {
                throw new SerializationException(string.Format("Failed to correctly serialize the file {0}", pathToMappingFile));
            }
            else
            {
                this._segmentMappings = tempMappings.SegmentMappings;
            }
        }

        public void GetMessagesFromDB(string messageControlId)
        {
            int messageHeaderId = -1;
            messageHeaderId = _repo.GetMessageHeaderIdBy(messageControlId);

            if (messageHeaderId != -1)
            {
                //Parallel.ForEach(this._segmentMappings, segment =>
                //{
                //    segment.GetTableData(messageHeaderId);
                //});

                foreach (SegmentTableMapping stm in this._segmentMappings)
                {
                    stm.GetTableData(messageHeaderId);
                }
            }
        }
        #endregion
    }
}
