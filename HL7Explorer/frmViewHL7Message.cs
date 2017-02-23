using System;
using System.Collections;
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

        private void TvSegments_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;
            grdSegmentFields.DataSource = node.Tag as List<HL7SegmentEvent>;
        }

        private void databaseComparisonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var treeViewItem = tvSegments.SelectedNode;

        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            PipeParser parser = new PipeParser();
            _hl7Message = parser.Parse(e.Argument.ToString());
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripButtonLoad.Enabled = true;

            txtRawHL7Message.Text = _hl7Message.MessageToken.RawMessage;
            foreach (var seg in _hl7Message.Events)
            {
                TreeNode n = new TreeNode(seg.Name);
                n.Tag = seg.Segments;
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
