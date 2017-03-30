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
using HL7Core;
using HL7Parser;
using HL7Parser.Models;
using HL7ExplorerBL.Entities;
using HL7ExplorerBL.Repository;
using HL7ExplorerBL.Helper;
using HL7ExplorerBL.QueryBuilder;
using com.Xgensoftware.Core;
namespace HL7Explorer
{
    public partial class frmHL7DBComparison : BaseForm
    {
        #region Member Variables 

        GenericDBRepository _genericRepo = null;
        
        IQueryBuilder _sql = null;

        SegmentTableMappingList _segmentDBMappingList = null;

        DBTableCollection _dbTableCollection = null;
        List<TriggerEvent> _triggerEvents = null;
        #endregion

        #region Private Methods

        void EnableDisableControl(Enable_Disable_Control status)
        {
            bool enable_disable = true;

            //enable/disable the combo boxes
            if (status == Enable_Disable_Control.DISABLE)
            {
                enable_disable = false;
            }

            cmbMessageType.Enabled = enable_disable;
            cmbEventType.Enabled = enable_disable;
            cmbHL7Versions.Enabled = enable_disable;
        }

        void LoadFromSegmentDbMappingCollection()
        {
            cmbHL7Versions.SelectedIndex = cmbHL7Versions.FindStringExact(_segmentDBMappingList.Version);
            cmbMessageType.SelectedIndex = cmbMessageType.FindStringExact(_segmentDBMappingList.MessageType);
            cmbEventType.SelectedIndex = cmbEventType.FindStringExact(_segmentDBMappingList.EventType);        


            foreach (SegmentTableMapping stm in _segmentDBMappingList.SegmentMappings)
            {
                TreeNode tnSegmentDB = new TreeNode(stm.ToString());
                tnSegmentDB.Tag = stm;
                tnSegmentDB.Name = stm.SegmentName;

                foreach(SegmentDBColumnMapping col in stm.ColumnMappings)
                {
                    TreeNode tnColMapping = new TreeNode(col.ToString());
                    tnColMapping.Tag = col;
                    tnColMapping.Name = col.SegmentColumn;
                    tnSegmentDB.Nodes.Add(tnColMapping);
                }

                tvSegmentTableMap.Nodes.Add(tnSegmentDB);
            }
            tvSegmentTableMap.ExpandAll();
        }

        void LoadSegments()
        {
            HL7Parser.Version ver = cmbHL7Versions.SelectedItem as HL7Parser.Version;
            MessageType mt = cmbMessageType.SelectedItem as MessageType;
            EventType et = cmbEventType.SelectedItem as EventType;

            List<TriggerEvent> _selectedEvents = _triggerEvents.Where(x => x.Version == ver.Name && x.MessageType == mt.MessageType1 && x.EventType == et.EventType1).ToList();
            foreach (TriggerEvent tr in _selectedEvents)
            {
                cmbSegment.Items.Add(tr.Segment);
            }


            if(cmbSegment.Items.Count > 0)
                cmbSegment.SelectedIndex = 0;
        }

        private void LoadDropDownControls()
        {           

            var versions = this._repo.GetVersions();
            cmbHL7Versions.DataSource = versions;
            cmbHL7Versions.DisplayMember = "Name";

            var messageType = this._repo.GetMessageTypes();
            cmbMessageType.DataSource = messageType;
            cmbMessageType.DisplayMember = "MessageType1";


            var eventType = this._repo.GetEventTypes();
            cmbEventType.DataSource = eventType;
            cmbEventType.DisplayMember = "EventType1";
            
            cmbDBTables.DataSource = _dbTableCollection.ToList();
            cmbDBTables.DisplayMember = "TableName";

            LoadSegments();            
        }

        protected override void CreateMenuItems()
        {
            base.CreateMenuItems();

            ToolStripItem tsiNew = new ToolStripMenuItem();
            tsiNew.Text = "New";
            tsiNew.Click += ToolStripMenuItemNew_Click;
            this.toolStripMenuItemFile.DropDownItems.Add(tsiNew);
        }
        #endregion

        #region Form Events
        public frmHL7DBComparison()
        {
            InitializeComponent();
            this.Load += FrmHL7DBComparison_Load;
            this.cmbDBTables.SelectedIndexChanged += CmbDBTables_SelectedIndexChanged;
            this.cmbSegment.SelectedIndexChanged += CmbSegment_SelectedIndexChanged;
            this.cmbMessageType.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            this.cmbEventType.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            this.cmbHL7Versions.SelectedIndexChanged += ComboBox_SelectedIndexChanged;

            _genericRepo = new GenericDBRepository(AppConfiguration.DBProvider, AppConfiguration.DBConnection);
            _repo = new HL7Parser.Repository.HL7SchemaRepository();
            
            this._sql = new SheridanQueryBuilder();
                        
        }

        private void FrmHL7DBComparison_Load(object sender, EventArgs e)
        {
            _dbTableCollection = _genericRepo.GetDatabaseTables(null);
            _triggerEvents = _repo.GetAllTriggerEvents();


            CreateMenuItems();
            LoadDropDownControls();
            EnableDisableControl(Enable_Disable_Control.ENABLE);
        }

        private void CmbSegment_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstSegColumns.Items.Clear();
            string segmentCol = cmbSegment.SelectedItem as string;

            HL7Parser.Version ver = cmbHL7Versions.SelectedItem as HL7Parser.Version;
            List<Segment> seg = _repo.GetSegmentBy(ver.Name, segmentCol);
            foreach(Segment s in seg)
            {
                lstSegColumns.Items.Add(s.Name);
            }
        }

        private void CmbDBTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBTable table = cmbDBTables.SelectedItem as DBTable;
            lstDBColumns.DataSource = _genericRepo.GetDatabaseColumnsBy(table).Collection;
            lstDBColumns.DisplayMember = "ColumnName";
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSegments();
        }

        private void btnMap_Click(object sender, EventArgs e)
        {
            var dbTable = cmbDBTables.SelectedItem as DBTable;
            var dbColumn = lstDBColumns.SelectedItem as DBColumn;
            var segment = cmbSegment.SelectedItem.ToString();
            var segColumn = lstSegColumns.SelectedItem.ToString();

            if(_segmentDBMappingList == null)
            {
                MessageBox.Show("You must select New to create a new mapping file.");
                return;
            }
            else
            {
                btnSaveMap.Enabled = true;
                btnRemove.Enabled = true;
            }

            //first check to see if the db column already exists
            SegmentTableMapping stm = _segmentDBMappingList.SegmentMappings.Find(x => x.SegmentName == segment);
            if (stm == null)
            {
                stm = new SegmentTableMapping(segment, dbTable.TableName);
                _segmentDBMappingList.SegmentMappings.Add(stm);
            }

            SegmentDBColumnMapping scm = stm.ColumnMappings.Find(x => x.DatabaseColumn == dbColumn.ColumnName);
            if (scm == null)
            {
                scm = new SegmentDBColumnMapping(segColumn, dbColumn.ColumnName);
                stm.ColumnMappings.Add(scm);               
            }
            else
            {
                MessageBox.Show(string.Format("{0} is already mapped", segColumn));
            }

            //Load the treeview
            tvSegmentTableMap.Nodes.Clear();
            foreach (SegmentTableMapping tvSTM in _segmentDBMappingList.SegmentMappings)
            {
                TreeNode tnSegmentDB = new TreeNode(tvSTM.ToString());
                tnSegmentDB.Name = tvSTM.SegmentName;

                foreach (SegmentDBColumnMapping col in tvSTM.ColumnMappings)
                {
                    tnSegmentDB.Nodes.Add(col.ToString());
                }

                tvSegmentTableMap.Nodes.Add(tnSegmentDB);
            }
            tvSegmentTableMap.ExpandAll();

            //BL : once the user selects a Message,Event and Version disable so they can change mid mapping.  
            EnableDisableControl(Enable_Disable_Control.DISABLE);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvSegmentTableMap.SelectedNode;
            Type nodeType = selectedNode.Tag.GetType();
            MessageBox.Show(nodeType.Name);
            switch (nodeType.Name)
            {
                case "SegmentTableMapping":

                    break;

                case "SegmentDBColumnMapping":

                    break;
            }
        }

        private void btnSaveMap_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = Application.ExecutablePath;
            dialog.AddExtension = true;
            dialog.DefaultExt = "xml";
            dialog.Filter = "XML (*.xml)|*.xml";
            dialog.FileOk += Dialog_FileOk;
            dialog.ShowDialog();
        }

        private void Dialog_FileOk(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(_segmentDBMappingList.MessageType))
                _segmentDBMappingList.MessageType = ((MessageType)cmbMessageType.SelectedItem).MessageType1;

            if (string.IsNullOrEmpty(_segmentDBMappingList.EventType))
                _segmentDBMappingList.EventType = ((EventType)cmbEventType.SelectedItem).EventType1;

            if (string.IsNullOrEmpty(_segmentDBMappingList.Version))
                _segmentDBMappingList.Version = ((HL7Parser.Version)cmbHL7Versions.SelectedItem).Name;

            SaveFileDialog dialog = sender as SaveFileDialog;
            string fileToSave = dialog.FileName;
            if (!string.IsNullOrEmpty(fileToSave))
            {
                var data = _segmentDBMappingList.ToXML().ToByteArray();
                using (FileStream fs = new FileStream(fileToSave, FileMode.Create, FileAccess.Write))
                {
                    try
                    {
                        fs.Write(data, 0, data.Length);

                        MessageBox.Show(string.Format("Successfully saved mappings to {0}", fileToSave));
                    }
                    catch (IOException ex)
                    {
                        LogError(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("You must select a file to save too.");
            }
        }

        private void btnFindFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.DefaultExt = "xml";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtMapFilePath.Text = dialog.FileName;
                    if (_segmentDBMappingList == null && !string.IsNullOrEmpty(txtMapFilePath.Text))
                    {
                        btnLoadMapFile.Enabled = true;
                    }
                }
            }
        }

        private void ToolStripMenuItemNew_Click(object sender, EventArgs e)
        {
            EnableDisableControl(Enable_Disable_Control.ENABLE);

            txtMapFilePath.Clear();
            _segmentDBMappingList = new SegmentTableMappingList();
            cmbHL7Versions.SelectedIndex = 0;
            cmbMessageType.SelectedIndex = 0;
            cmbEventType.SelectedIndex = 0;
            btnLoadMapFile.Enabled = false;
            tvSegmentTableMap.Nodes.Clear();
            btnMap.Enabled = true;
            btnRemove.Enabled = false;
            btnSaveMap.Enabled = true;
        }

        private void btnLoadMapFile_Click(object sender, EventArgs e)
        {
            // load the mapping file if it exists
            string mapFile = txtMapFilePath.Text;
            if (!string.IsNullOrEmpty(mapFile))
            {
                btnSaveMap.Enabled = true;
                btnMap.Enabled = true;
                btnRemove.Enabled = true;
                this._segmentDBMappingList = File.ReadAllText(mapFile).FromXML<SegmentTableMappingList>();

                if (this._segmentDBMappingList != null)
                {
                    LoadFromSegmentDbMappingCollection();
                }
                else
                {
                    LogError(string.Format("Failed to transform file: {0}", mapFile));
                }
            }
        }
        #endregion


    }
}
