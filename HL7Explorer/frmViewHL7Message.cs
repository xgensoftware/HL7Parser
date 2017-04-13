using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows.Forms;
using com.Xgensoftware.Core;
using HL7Core;
using HL7Parser.Parser;
using HL7Parser.Models;
using HL7Parser.Repository;
using HL7ExplorerBL.Entities;
using HL7ExplorerBL.QueryBuilder;

namespace HL7Explorer
{
    /*
    This form will allow the user to load an raw HL7Message parsed to its respective segments

    History
    *********************************************************************************
    Date        Author                  Description
    *********************************************************************************
    04/3/2017   Anthony Sanfilippo      added history comments
    04/04/2017  Anthony Sanfilippo      added multi HL7 Message Selection
    04/06/2017  ABS                     Changed so that an HL7 Message will drive what gets 
                                        queried using the Model SegmentTableMappingList
    *********************************************************************************
    */

    public partial class frmViewHL7Message : BaseForm
    {
        #region Member Variables
        HL7Message _hl7Message = null;
        frmHL7DataFileList _dataList = null;
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
        
        void LoadHL7(string hl7Data)
        {
            this._hl7Message = null;
            toolStripButtonLoad.Enabled = false;
            
            bgwParser.RunWorkerAsync(hl7Data);

            StartProgressBar();        
        }

        void LoadHL7Controls()
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
        }

        #endregion

        #region Form Events
        public frmViewHL7Message(HL7SchemaRepository repo) : base()
        {
            InitializeComponent();
            this._repo = repo;
            this.Text = SetFormText();

            CreateMenuItems();
            CreateFormControls();
        }

        public frmViewHL7Message() : base()
        {
            InitializeComponent();
            this._repo = new HL7SchemaRepository();
            this.Text = SetFormText();

            CreateMenuItems();
            CreateFormControls();        
        }
        
        private void frmViewHL7Message_Load(object sender, EventArgs e)
        {

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
                string hl7Data = File.ReadAllText(openFileDialog1.FileName);
                LoadHL7(hl7Data);
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
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Tag = "DBCompare";
                    dialog.InitialDirectory = Application.ExecutablePath;
                    dialog.FileOk += Dialog_FileOk;
                    dialog.Filter = "XML (*.xml)|*.xml";
                    dialog.ShowDialog();                   
                }
            }
            else
            {
                LogInfo("In order to continue, you must first load an HL7 message");
            }
        }

        private void toolStripButtonLoadHL7DatFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Tag = "HL7DATLoad";
            dialog.InitialDirectory = Application.ExecutablePath;
            dialog.FileOk += Dialog_FileOk;
            dialog.Filter = "HL7 File (*.dat)|*.dat";
            dialog.ShowDialog();
        }

        private void Dialog_FileOk(object sender, CancelEventArgs e)
        {
            OpenFileDialog dialog = sender as OpenFileDialog;
           
            switch(dialog.Tag.ToString())
            {
                case "DBCompare":
                    bgwDBCompare.RunWorkerAsync(dialog.FileName);

                    StartProgressBar();
                    break;

                case "HL7DATLoad":
                    _dataList = new frmHL7DataFileList();
                    _dataList.OnHL7ObjectSelected += DataList_OnHL7ObjectSelected;
                    _dataList.OnHL7DataFileParsed += DataList_OnHL7DataFileParsed;                    
                    _dataList.LoadMessages(dialog.FileName);                    
                    break;
            }                      
        }

        private void DataList_OnHL7DataFileParsed(bool isSuccess)
        {
            if (isSuccess && _dataList != null)
            {
                _dataList.Show();
            }
        }

        private void DataList_OnHL7ObjectSelected(HL7Message hl7Object)
        {
            _hl7Message = hl7Object;
            LoadHL7Controls();
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
            grdSegmentFields.DataSource = node.Tag as List<HL7SegmentColumn>;
            
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
            string hl7Data = File.ReadAllText(temp[0]);
            LoadHL7(hl7Data);
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
            this.LoadHL7Controls();

            StopProgressBar();

            toolStripButtonLoad.Enabled = true;
        }
        
        private void BgwDBCompare_DoWork(object sender, DoWorkEventArgs e)
        {            
            
            SegmentTableMappingList segmentTableList = new SegmentTableMappingList();           
            
            try
            {
                segmentTableList.GetMappingFile(e.Argument.ToString());
            }
            catch(FileNotFoundException ex)
            {
                LogError(ex.Message);
            }
            catch(SerializationException ex)
            {
                LogError(ex.Message);
            }

            try
            {
                segmentTableList.GetMessagesFromDB(_hl7Message);
                e.Result = segmentTableList;
            }
            catch (Exception ex)
            {
                LogError(string.Format("Failed to retrieve db record for message control id {0}. ERROR:{1}", _hl7Message.MessageToken.MessageControlId, ex.Message));
            }
            
        }

        private void BgwDBCompare_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SegmentTableMappingList segmentTableList = e.Result as SegmentTableMappingList;
            foreach (SegmentTableMapping map in segmentTableList.SegmentMappings)
            {
                frmDatabaseView db = new frmDatabaseView(map);
                db.Show();
            }

            StopProgressBar();
        }

        //private void BgwDBCompare_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    SegmentTableMappingList segmentTableList = e.Result as SegmentTableMappingList;
        //    foreach (KeyValuePair<int, HL7EventSegment> hl7Data in _hl7Message.Events)
        //    {
        //        HL7EventSegment hl7EventSegmentData = hl7Data.Value;
        //        SegmentTableMapping map = segmentTableList.SegmentMappings.Where(x => x.SegmentName == hl7Data.Value.Name).FirstOrDefault();
        //        if (map != null)
        //        {
        //            List<HL7DBCompare> collection = new List<HL7DBCompare>();
        //            List<HL7SegmentEvent> hl7segments = hl7EventSegmentData.Segments.Where(x => x.Name.Contains("Set ID")).ToList();
        //            if (hl7segments.Count > 0)
        //            {
        //                foreach(HL7SegmentEvent evnt in hl7segments)
        //                {
        //                    //System.Data.DataRow dr = map.TableData.Select(string.Format("SetID = '{0}'",evnt.)
        //                }
        //            }
        //            else
        //            {
        //                if (map.TableData.Rows.Count > 0)
        //                {
        //                    System.Data.DataRow dr = map.TableData.Rows[0];
        //                    foreach (SegmentDBColumnMapping sdbc in map.ColumnMappings)
        //                    {
        //                        HL7DBCompare comp = new HL7DBCompare();
        //                        HL7SegmentEvent hl7SegColName = hl7EventSegmentData.Segments.Where(x => x.Name == sdbc.SegmentColumn).FirstOrDefault();
        //                        if (hl7SegColName != null)
        //                        {
        //                            comp.DBValue = dr[sdbc.DatabaseColumn].ToString();
        //                            comp.DBColumn = sdbc.DatabaseColumn;
        //                            comp.SegmentName = hl7SegColName.Name;
        //                            comp.SegmentValue = hl7SegColName.Value.ToString();
        //                            collection.Add(comp);
        //                        }
        //                    }
        //                }

        //                if (collection.Count > 0)
        //                {
        //                    frmDatabaseView db = new frmDatabaseView(map, collection);
        //                    db.Show();
        //                }
        //            }
        //        }
        //    }

        //    StopProgressBar();
        //}


        #endregion
    }
}
