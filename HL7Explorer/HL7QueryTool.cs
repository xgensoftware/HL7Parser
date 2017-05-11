using System;
using System.Collections.Concurrent;
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
using HL7Parser.Parser;
using HL7Parser.Models;
using HL7ExplorerBL.QueryParser;
namespace HL7Explorer
{
    /*
This is an editor that will mimic a sql window.  The user selects a path and date for files to query

History
*********************************************************************************
Date        Author                  Description
*********************************************************************************
05/4/2017   Anthony Sanfilippo      Creation
*********************************************************************************
*/
    public partial class HL7QueryTool : BaseForm
    {
        #region Member Variables
        string _pathToHL7Files = string.Empty;
        
        ConcurrentBag<HL7Message> _hl7MessageCollection = null;
        #endregion

        #region Private Methods 
        protected override void CreateMenuItems()
        {
            base.CreateMenuItems();

            this.FormClosed += HL7QueryTool_FormClosed;
        }

        #endregion

        #region Constructor 
        public HL7QueryTool()
        {
            InitializeComponent();

            this.Text = SetFormText();

            bgwHL7FileParser.DoWork += BgwHL7FileParser_DoWork;
            bgwHL7FileParser.RunWorkerCompleted += BgwHL7FileParser_RunWorkerCompleted;
            CreateMenuItems();
        }

        #endregion

        #region Form Methods
        
        private void toolStripButtonConnect_Click(object sender, EventArgs e)
        {
            HL7QueryConfig frm = new HL7QueryConfig();
            frm.OnQueryConfigSaved += Frm_OnQueryConfigSaved;
            frm.ShowDialog();
        }

        private void toolStripButtonRun_Click(object sender, EventArgs e)
        {
            QueryParser parser = new QueryParser();
           // parser.TokenizeQuery(txtQueryEditor.Text); 
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            bgwHL7FileParser.RunWorkerAsync();
            StartProgressBar();
        }

        private void Frm_OnQueryConfigSaved(string pathToHL7Files)
        {
            _hl7MessageCollection = new ConcurrentBag<HL7Message>();
            _pathToHL7Files = pathToHL7Files;
            bgwHL7FileParser.RunWorkerAsync();

            StartProgressBar();
        }

        private void HL7QueryTool_FormClosed(object sender, FormClosedEventArgs e)
        {
            for (int i = 0; i <= toolStripMenuItemTools.DropDownItems.Count - 1; i++)
            {
                toolStripMenuItemTools.DropDownItems.RemoveAt(i);
            }
        }

        private void BgwHL7FileParser_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] filesToParse = Directory.GetFiles(_pathToHL7Files);
            Parallel.ForEach(filesToParse, file => {
                string fileData = File.ReadAllText(file);

                PipeParser parser = new PipeParser();
                try
                {
                    _hl7MessageCollection.Add(parser.Parse(fileData));
                }
                catch (ParserException ex)
                {
                    LogError(string.Format("Parser error: {0}", ex.Message),false);
                }
            });
        }

        private void BgwHL7FileParser_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // load the treeview
            tvSegments.Nodes.Clear();
            List<HL7Message> hl7List = _hl7MessageCollection.ToList();
            foreach(HL7Message hl7Message in hl7List)
            {
                if (hl7Message != null)
                {
                    TreeNode parentSegment = new TreeNode(hl7Message.MessageToken.MessageControlId);
                    parentSegment.ImageIndex = 0;
                    foreach (HL7Segment seg in hl7Message.Segments)
                    {
                        TreeNode segmentNode = new TreeNode(seg.Name);
                        segmentNode.Name = seg.Name;
                        segmentNode.ImageIndex = 1;

                        foreach(HL7SegmentField col in seg.Segments)
                        {
                            TreeNode segmentColumn = new TreeNode(string.Format("{0}:{1}", col.Name, col.Value));
                            segmentColumn.Name = col.Name;
                            segmentColumn.ImageIndex = 2;
                            segmentNode.Nodes.Add(segmentColumn);
                        }
                        
                        parentSegment.Nodes.Add(segmentNode);                        
                    }

                    tvSegments.Nodes.Add(parentSegment);
                }
            }

            StopProgressBar();
        }

        #endregion

    }
}
