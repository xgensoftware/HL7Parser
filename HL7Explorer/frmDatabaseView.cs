using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using com.Xgensoftware.Core;
using HL7Core;
using HL7ExplorerBL.Entities;
namespace HL7Explorer
{
    public partial class frmDatabaseView : Form
    {
        #region Member Variables 
        string _segmentName = string.Empty;

        SegmentTableMapping _segmentMapping = null;
        #endregion

        #region Private Methods
        private void GetMappingFile()
        {
            
            
        }
        #endregion

        public frmDatabaseView(SegmentTableMapping stm)
        {
            InitializeComponent();

            //this.Text = segmentName;

            try
            {
                gridSegment.DataSource = stm.TableData;
                //SegmentTableMappingList collection = File.ReadAllText(AppConfiguration.SegmentTableMappingFile).FromXML<SegmentTableMappingList>();
                //_segmentMapping = collection.Where(x => x.SegmentName == segmentName).FirstOrDefault();
                //_segmentMapping.GetTableData();

                //gridSegment.DataSource = _segmentMapping.TableData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0}", ex.Message));
            }
        }

        private void frmDatabaseView_Load(object sender, EventArgs e)
        {                    

           
        }
    }
}
