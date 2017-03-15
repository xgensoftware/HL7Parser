using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL7Core;
using HL7ExplorerBL.Repository;
namespace HL7ExplorerBL.Entities
{
    public class SegmentTableMapping 
    {
        #region Member Variables 
        SegmentMappingRepository _repo = null;
        int _messageHeaderID = -1;
        string _segmentName = string.Empty;
        string _tableName = string.Empty;
        System.Data.DataTable _dt = null;
        #endregion

        #region Properties

        public string SegmentName
        {
            get { return _segmentName; }
            set { _segmentName = value; }
        }
        

        public string TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }

        public System.Data.DataTable TableData
        {
            get { return _dt; }
        }
        #endregion

        #region Constructor 
        public SegmentTableMapping()
        {
            try
            {
                _repo = new SegmentMappingRepository(AppConfiguration.DBProvider, AppConfiguration.DBConnection);
            }
            catch { }              
               
        }

        public SegmentTableMapping(string segmentName, string tableName)
        {
            this._segmentName = segmentName;
            this._tableName = tableName;

            try
            {
                _repo = new SegmentMappingRepository(AppConfiguration.DBProvider, AppConfiguration.DBConnection);
            }
            catch { }

        }
        #endregion

        #region Public Methods 

        public void GetTableData(int messageHeaderId)
        {
            try
            {
                _dt = _repo.GetSegmentTableData(messageHeaderId,_tableName);
            }
            catch { }
        }

        
        #endregion
    }
}
