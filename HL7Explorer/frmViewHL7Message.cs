using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using HL7Core;
using HL7Parser.Parser;
using HL7Parser.Models;
using HL7Parser.Repository;
using HL7ExplorerBL.Entities;
namespace HL7Explorer
{
    /// <summary>
    /// This form will allow the user to load an raw HL7Message parsed 
    /// to its respective segments
    /// </summary>
    public partial class frmViewHL7Message : BaseForm
    {
        #region Member Variables
        HL7Message _hl7Message = null;
        SegmentTableMappingList _segmentTableList = null;
        frmProgress _progressIndicator = null;
        #endregion

        #region Private Methods
        protected override void CreateMenuItems()
        {
            base.CreateMenuItems();

            this.FormClosing += FrmViewHL7Message_FormClosing;


            ToolStripItem tsiHL7DBMapping = new ToolStripMenuItem();
            tsiHL7DBMapping.Text = "HL7 To Database Columns Mapping";
            tsiHL7DBMapping.Click += TsiHL7DBMapping_Click;
            this.toolStripMenuItemTools.DropDownItems.Add(tsiHL7DBMapping);

            ToolStripItem tsiEventBuilder = new ToolStripMenuItem();
            tsiEventBuilder.Text = "HL7 Event Builder";
            tsiEventBuilder.Click += tsiEventBuilder_Click;
            this.toolStripMenuItemTools.DropDownItems.Add(tsiEventBuilder);
         
        }

        void CreateFormControls()
        {
            this.FormClosing += FrmViewHL7Message_FormClosing;
            this.txtRawHL7Message.DragDrop += TxtRawHL7Message_DragDrop;
            this.txtRawHL7Message.DragEnter += TxtRawHL7Message_DragEnter;
            tvSegments.NodeMouseClick += TvSegments_NodeMouseClick;
            bgwParser.DoWork += bgwParser_DoWork;
            bgwParser.RunWorkerCompleted += bgwParser_RunWorkerCompleted;
            bgwDBCompare.DoWork += BgwDBCompare_DoWork;
            bgwDBCompare.RunWorkerCompleted += BgwDBCompare_RunWorkerCompleted;
        }
        
        void LoadHL7(string fileName)
        {
            this._hl7Message = null;
            toolStripButtonLoad.Enabled = false;

            string hl7File = File.ReadAllText(fileName);
            bgwParser.RunWorkerAsync(hl7File);

            _progressIndicator = new frmProgress();
            _progressIndicator.ShowDialog();           
        }

        #endregion

        #region Form Events
        public frmViewHL7Message(HL7SchemaRepository repo) : base()
        {
            InitializeComponent();
            this._repo = repo;

            CreateMenuItems();
            CreateFormControls();
        }

        public frmViewHL7Message() 
        {
            InitializeComponent();
            this._repo = new HL7SchemaRepository();

            CreateMenuItems();
            CreateFormControls();        
        }
        
        private void frmViewHL7Message_Load(object sender, EventArgs e)
        {
            this.Text = "View HL7 Message";

            if (!string.IsNullOrEmpty(AppConfiguration.DBConnection))
            {
                if (AppConfiguration.DBConnection.Contains("SheridanHL7Data"))
                    toolStripButtonDBCompare.Enabled = true;
            }
        }

        private void FrmViewHL7Message_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 0; i <= toolStripMenuItemTools.DropDownItems.Count - 1; i++)
            {
                toolStripMenuItemTools.DropDownItems.RemoveAt(i);
            }
        }

        private void toolStripButtonLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                LoadHL7(openFileDialog1.FileName);
            }
            else
            {
                toolStripButtonLoad.Enabled = true;
            }                     
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (this._hl7Message != null)
            {
                if (!string.IsNullOrEmpty(AppConfiguration.DBConnection))
                {
                    bgwDBCompare.RunWorkerAsync();

                    _progressIndicator = new frmProgress();
                    _progressIndicator.ShowDialog();
                }
            }
            else
            {
                LogInfo("In order to continue, you must first load an HL7 message");
            }
        }

        private void TsiHL7DBMapping_Click(object sender, EventArgs e)
        {
            frmHL7DBComparison comparison = new frmHL7DBComparison();
            comparison.ShowDialog();
        }

        private void tsiEventBuilder_Click(object sender, EventArgs e)
        {
            frmEventBuilder evntBuilder = new frmEventBuilder(_repo);
            evntBuilder.ShowDialog();
        }

        private void TvSegments_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;
            grdSegmentFields.DataSource = node.Tag as List<HL7SegmentEvent>;
            
        }

        private void TxtRawHL7Message_DragDrop(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop,false)==true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void TxtRawHL7Message_DragEnter(object sender, DragEventArgs e)
        {
            var temp = e.Data.GetData(DataFormats.FileDrop) as string[];
            LoadHL7(temp[0]);
        }

        private void bgwParser_DoWork(object sender, DoWorkEventArgs e)
        {
            PipeParser parser = new PipeParser();
            try
            {
                _hl7Message = parser.Parse(e.Argument.ToString());
            }
            catch(ParserException ex)
            {
                LogError(string.Format("Parser error: {0}", ex.Message));
            }
        }

        private void bgwParser_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tvSegments.Nodes.Clear();           

            if (_hl7Message != null)
            {
                txtRawHL7Message.Text = _hl7Message.MessageToken.RawMessage;
                foreach (var seg in _hl7Message.Events)
                {
                    TreeNode n = new TreeNode(seg.Value.Name);
                    n.Name = seg.Value.Name;
                    n.Tag = seg.Value.Segments;
                    tvSegments.Nodes.Add(n);
                }

                tvSegments.Nodes[0].Toggle();
                tvSegments.SelectedNode = tvSegments.Nodes[0];
                tvSegments.Focus();
                grdSegmentFields.DataSource = tvSegments.Nodes[0].Tag;                
            }

            if (_progressIndicator != null)
            {
                _progressIndicator.Stop();
                _progressIndicator = null;
            }

            toolStripButtonLoad.Enabled = true;
        }
        
        private void BgwDBCompare_DoWork(object sender, DoWorkEventArgs e)
        {
            _segmentTableList = new SegmentTableMappingList();
            _segmentTableList.GetMappingFile(AppConfiguration.SegmentTableMappingFile);

            try
            {
                _segmentTableList.GetMessagesFromDB(_hl7Message.MessageToken.MessageControlId);
            }
            catch(Exception ex)
            {
                LogError(string.Format("Failed to retrieve db record for message control id {0}. ERROR:{1}", _hl7Message.MessageToken.MessageControlId, ex.Message));
            }
        }

        private void BgwDBCompare_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_segmentTableList.Count > 0)
            {
                foreach (SegmentTableMapping stm in _segmentTableList.SegmentMappings)
                {
                    frmDatabaseView db = new frmDatabaseView(stm);
                    db.Show();
                }
            }
            else
                MessageBox.Show(string.Format("No database records found for Message control Id {0}", _hl7Message.MessageToken.MessageControlId));


            if (_progressIndicator != null)
            {
                _progressIndicator.Stop();
                _progressIndicator = null;
            }
        }
        #endregion
    }
}
