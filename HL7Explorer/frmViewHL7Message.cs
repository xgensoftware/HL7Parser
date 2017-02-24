using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using HL7Parser.Parser;
using HL7Parser.Models;
using HL7Parser.Repository;

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
        #endregion

        #region Private Methods 

        #endregion

        #region Form Events
        public frmViewHL7Message(HL7SchemaRepository repo) : base()
        {
            InitializeComponent();
            this._repo = repo;

            tvSegments.NodeMouseClick += TvSegments_NodeMouseClick;
            backgroundWorker1.DoWork += BackgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;
        }
        
        public frmViewHL7Message() 
        {
            InitializeComponent();
            this._repo = new HL7SchemaRepository();
            
            tvSegments.NodeMouseClick += TvSegments_NodeMouseClick;
            backgroundWorker1.DoWork += BackgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;
        }
        
        private void frmViewHL7Message_Load(object sender, EventArgs e)
        {
            this.Text = "View HL7 Message";
        }
        
        private void toolStripButtonLoad_Click(object sender, EventArgs e)
        {
            this._hl7Message = null;
            toolStripButtonLoad.Enabled = false;
                      

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string hl7File = File.ReadAllText(openFileDialog1.FileName);
                backgroundWorker1.RunWorkerAsync(hl7File);
            }
           
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (this._hl7Message != null)
            {
                frmHL7DBComparison dbComparison = new frmHL7DBComparison(this._hl7Message);
                dbComparison.ShowDialog();
            }
            else
            {
                MessageBox.Show("In order to continue, you must first load an HL7 message");
            }
        }

        private void TvSegments_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;
            grdSegmentFields.DataSource = node.Tag as List<HL7SegmentEvent>;
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            PipeParser parser = new PipeParser();
            _hl7Message = parser.Parse(e.Argument.ToString());
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tvSegments.Nodes.Clear();
            toolStripButtonLoad.Enabled = true;

            txtRawHL7Message.Text = _hl7Message.MessageToken.RawMessage;
            foreach (var seg in _hl7Message.Events)
            {
                TreeNode n = new TreeNode(seg.Value.Name);
                n.Tag = seg.Value.Segments;
                tvSegments.Nodes.Add(n);
            }

            tvSegments.Nodes[0].Toggle();
            tvSegments.SelectedNode = tvSegments.Nodes[0];
            tvSegments.Focus();
            grdSegmentFields.DataSource = tvSegments.Nodes[0].Tag;
        }
        #endregion
    }
}
