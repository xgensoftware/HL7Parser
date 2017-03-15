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
        #endregion

        #region Private Methods 

        #endregion

        #region Form Events
        public frmViewHL7Message(HL7SchemaRepository repo) : base()
        {
            InitializeComponent();
            this._repo = repo;

            tvSegments.NodeMouseClick += TvSegments_NodeMouseClick;
            bgwParser.DoWork += BackgroundWorker1_DoWork;
            bgwParser.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;
            bgwDBCompare.DoWork += BgwDBCompare_DoWork;
            bgwDBCompare.RunWorkerCompleted += BgwDBCompare_RunWorkerCompleted;
        }
        public frmViewHL7Message() 
        {
            InitializeComponent();
            this._repo = new HL7SchemaRepository();

            this.toolStripMenuItemNew.Click += ToolStripMenuItemNew_Click;
            tvSegments.NodeMouseClick += TvSegments_NodeMouseClick;
            bgwParser.DoWork += BackgroundWorker1_DoWork;
            bgwParser.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;
            bgwDBCompare.DoWork += BgwDBCompare_DoWork;
            bgwDBCompare.RunWorkerCompleted += BgwDBCompare_RunWorkerCompleted;
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
        
        private void toolStripButtonLoad_Click(object sender, EventArgs e)
        {
            this._hl7Message = null;
            toolStripButtonLoad.Enabled = false;
                      

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string hl7File = File.ReadAllText(openFileDialog1.FileName);
                bgwParser.RunWorkerAsync(hl7File);
            }
           
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (this._hl7Message != null)
            {
                if (!string.IsNullOrEmpty(AppConfiguration.DBConnection))
                {
                    bgwDBCompare.RunWorkerAsync();                    
                }
            }
            else
            {
                MessageBox.Show("In order to continue, you must first load an HL7 message");
            }
        }

        private void ToolStripMenuItemNew_Click(object sender, EventArgs e)
        {
            
        }

        private void TvSegments_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;
            grdSegmentFields.DataSource = node.Tag as List<HL7SegmentEvent>;
            
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            PipeParser parser = new PipeParser();
            try
            {
                _hl7Message = parser.Parse(e.Argument.ToString());
            }
            catch(ParserException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tvSegments.Nodes.Clear();
            toolStripButtonLoad.Enabled = true;

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
        }
        
        private void BgwDBCompare_DoWork(object sender, DoWorkEventArgs e)
        {
            var msgControlid = _hl7Message.MessageToken.MessageControlId;
            _segmentTableList = new SegmentTableMappingList();
            _segmentTableList.GetMessagesFromDB(msgControlid);
        }

        private void BgwDBCompare_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (SegmentTableMapping stm in _segmentTableList)
            {
                frmDatabaseView db = new frmDatabaseView(stm);
                db.Show();
            }
        }
        #endregion
    }
}
