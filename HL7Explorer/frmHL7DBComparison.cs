using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HL7Core;
using HL7Parser.Models;
using HL7ExplorerBL.Entities;
using HL7ExplorerBL.Repository;
using HL7ExplorerBL.Helper;
using HL7ExplorerBL.QueryBuilder;
namespace HL7Explorer
{
    public partial class frmHL7DBComparison : BaseForm
    {
        #region Member Variables 

        GenericDBRepository _genericRepo = null;
        HL7Message _hl7Message = null;

        Dictionary<string, string> _mappedSegments = null;

        IQueryBuilder _sql = null;
        #endregion

        #region Private Methods

        private void LoadControls()
        {
            string segments = _hl7Message.SegmentQueryParamter();
            DBTableCollection selectedTables = _genericRepo.GetDatabaseTables(segments);
            cmbDBTables.DataSource = selectedTables.ToList();
            cmbDBTables.DisplayMember = "TableName";
                        

            foreach(var evnt in this._hl7Message.Events)
            {
                cmbSegment.Items.Add(evnt.Value);
            }
            cmbSegment.SelectedIndex = 0;
        }
        #endregion

        #region Form Events
        public frmHL7DBComparison(HL7Message msg)
        {
            InitializeComponent();
            this.Load += FrmHL7DBComparison_Load;
            this.cmbDBTables.SelectedIndexChanged += CmbDBTables_SelectedIndexChanged;
            this.cmbSegment.SelectedIndexChanged += CmbSegment_SelectedIndexChanged;

            _genericRepo = new GenericDBRepository(AppConfiguration.DBProvider, AppConfiguration.DBConnection);

            this._mappedSegments = new Dictionary<string, string>();
            this._sql = new SheridanQueryBuilder();
            this._hl7Message = msg;          
                        
        }

        private void FrmHL7DBComparison_Load(object sender, EventArgs e)
        {
            LoadControls();
        }

        private void CmbSegment_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstSegColumns.Items.Clear();
            HL7EventSegment segment = cmbSegment.SelectedItem as HL7EventSegment;
            foreach(var s in segment.Segments)
            {
                lstSegColumns.Items.Add(s);
            }            
        }

        private void CmbDBTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBTable table = cmbDBTables.SelectedItem as DBTable;
            lstDBColumns.DataSource = _genericRepo.GetDatabaseColumnsBy(table).Collection;
            lstDBColumns.DisplayMember = "ColumnName";
        }

        private void btnMap_Click(object sender, EventArgs e)
        {
            var dbTable = cmbDBTables.SelectedItem as DBTable;
            var dbColumn = lstDBColumns.SelectedItem as DBColumn;
            var segment = cmbSegment.SelectedItem as HL7EventSegment;
            var segColumn = lstSegColumns.SelectedItem as HL7SegmentEvent;
                         
            if (this._mappedSegments.Where(x => x.Key == dbColumn.ColumnName).FirstOrDefault().Key != dbColumn.ColumnName)
            {
                this._mappedSegments.Add(dbColumn.ColumnName, segColumn.Name);
                this.lstMapping.Items.Add(string.Format("{0}:{1}", dbColumn.ColumnName, segColumn.Name));
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var selectedMap = lstMapping.SelectedItem;
            lstMapping.Items.Remove(selectedMap);
            this.lstMapping.Items.Remove(selectedMap);
        }
        #endregion
    }
}
