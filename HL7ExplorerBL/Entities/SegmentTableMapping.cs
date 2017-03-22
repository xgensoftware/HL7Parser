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
        string _segmentName = string.Empty;
        string _tableName = string.Empty;

        List<SegmentDBColumnMapping> _columnMappings = null;
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

        public List<SegmentDBColumnMapping> ColumnMappings
        {
            get { return _columnMappings; }
            set { _columnMappings = value; }
        }

        public System.Data.DataTable TableData
        {
            get { return _dt; }
        }
        #endregion

        #region Constructor 
        public SegmentTableMapping()
        {
            _columnMappings = new List<SegmentDBColumnMapping>();
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
            _columnMappings = new List<SegmentDBColumnMapping>();
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
            StringBuilder columns = new StringBuilder();
            if (_columnMappings.Count() == 0)
            {
                columns.Append("*");
            }
            else
            {
                foreach (SegmentDBColumnMapping col in _columnMappings)
                {
                    columns.AppendFormat("{0},", col.DatabaseColumn);
                }
                columns.Remove(columns.Length - 1, 1);
            }

            try
            {
                _dt = _repo.GetSegmentTableData(messageHeaderId, columns.ToString(), _tableName);
            }
            catch { }
        }

        
        #endregion
    }
}
