using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL7Core;
using HL7ExplorerBL.Repository;

namespace HL7ExplorerBL.Entities
{
    [Serializable]
    public class SegmentTableMappingList : List<SegmentTableMapping>
    {
        #region Member Variables 
        SegmentMappingRepository _repo = null;


        #endregion

        #region Properties

        #endregion

        #region Constructor 
        public SegmentTableMappingList() {

            try
            {
                _repo = new SegmentMappingRepository(AppConfiguration.DBProvider, AppConfiguration.DBConnection);
            }
            catch { }
        }
        #endregion

        #region Public Methods
        public void GetMessagesFromDB(string messageControlId)
        {
            int messageHeaderId = -1;
            try
            {
                 messageHeaderId = _repo.GetMessageHeaderIdBy(messageControlId);
            }
            catch { }

            if(messageHeaderId != -1)
            {
                Parallel.ForEach(this,segment =>{
                    segment.GetTableData(messageHeaderId);
                });

                //foreach(SegmentTableMapping stm in this)
                //{
                //    stm.GetTableData(messageHeaderId);
                //}
            }
        }
        #endregion
    }
}
