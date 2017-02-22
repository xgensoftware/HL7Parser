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

        #endregion

        #region Private Methods 

        #endregion

        #region Form Events
        public frmViewHL7Message(HL7SchemaRepository repo)
        {
            InitializeComponent();
            this._repo = repo;

            tvSegments.NodeMouseClick += TvSegments_NodeMouseClick;
        }

        private void frmViewHL7Message_Load(object sender, EventArgs e)
        {
            this.Text = "View HL7 Message";
        }
        
        private void toolStripButtonLoad_Click(object sender, EventArgs e)
        {
            PipeParser parser = new PipeParser();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string hl7File = File.ReadAllText(openFileDialog1.FileName);

                HL7Message hl7 = parser.Parse(hl7File);
                txtRawHL7Message.Text = hl7.MessageToken.RawMessage;
                foreach (var seg in hl7.Events)
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

        }

        private void TvSegments_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;
            grdSegmentFields.DataSource = node.Tag as List<SegmentEvent>;
        }

        private void databaseComparisonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var treeViewItem = tvSegments.SelectedNode;

        }
        #endregion
    }
}
