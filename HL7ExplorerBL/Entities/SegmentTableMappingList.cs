using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        #endregion

        #region Properties
        public List<SegmentTableMapping> SegmentMappings
        {
            get { return this._segmentMappings; }
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
            this._segmentMappings = xml.FromXML<List<SegmentTableMapping>>();
        }

        public void GetMessagesFromDB(string messageControlId)
        {
            int messageHeaderId = -1;
            messageHeaderId = _repo.GetMessageHeaderIdBy(messageControlId);

            if (messageHeaderId != -1)
            {
                Parallel.ForEach(this._segmentMappings, segment =>
                {
                    segment.GetTableData(messageHeaderId);
                });

                //foreach (SegmentTableMapping stm in this._segmentMappings)
                //{
                //    stm.GetTableData(messageHeaderId);
                //}
            }
        }
        #endregion
    }
}
