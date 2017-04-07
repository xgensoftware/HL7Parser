using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL7Core;
using HL7ExplorerBL.Repository;

namespace HL7ExplorerBL.Entities
{
    public class SegmentDBColumnMapping : Object
    {
        #region Member Variables 
        string _segmentColumn = string.Empty;
        string _databaseColumn = string.Empty;
        #endregion

        #region Properties
        public string SegmentColumn
        {
            get { return _segmentColumn; }
            set { _segmentColumn = value; }              
        }

        public string DatabaseColumn
        {
            get { return _databaseColumn; }
            set { _databaseColumn = value; }
        }

        #endregion

        #region Constructor 
        public SegmentDBColumnMapping()
        {

        }

        public SegmentDBColumnMapping(string segmentCol, string dbColumn)
        {
            _segmentColumn = segmentCol;
            _databaseColumn = dbColumn;
        }
        #endregion

        #region Public Methods
               
        public override string ToString()
        {
            return string.Format("[Segment]: {0} | [DB]: {1}", _segmentColumn, _databaseColumn);
        }

        #endregion
    }
}
