using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HL7Parser;
using HL7Parser.Repository;
namespace HL7Explorer
{
    /// <summary>
    /// Description: This form allows the user to add/update a new Trigger Event along with its segments
    /// </summary>
    /// 
    public partial class frmTriggerEventAddEdit : BaseForm
    {
        #region Member Variables 
        TriggerEvent _triggerEvent;
        #endregion

        #region Form Events
        public delegate void TriggerEventCompleted(bool isSuccess);
        public event TriggerEventCompleted OnTriggerEventCompleted;

        #endregion

        #region Private Methods 
        protected override void CreateMenuItems()
        {
            base.CreateMenuItems();

            ToolStripItem tsiNew = new ToolStripMenuItem();
            tsiNew.Text = "New";
            tsiNew.Click += ToolStripMenuItemNew_Click;
            this.toolStripMenuItemFile.DropDownItems.Add(tsiNew);
        }

        void PopulateControls()
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
        }

        void PopulateFormData()
        {
            gridSegments.DataSource = null;

            txtSegment.Text = this._triggerEvent.Segment;
            cmbHL7Versions.SelectedIndex = cmbHL7Versions.FindStringExact(this._triggerEvent.Version);
            cmbEventType.SelectedIndex = cmbEventType.FindStringExact(this._triggerEvent.EventType);
            cmbMessageType.SelectedIndex = cmbMessageType.FindStringExact(this._triggerEvent.MessageType);
            txtSequence.Text = this._triggerEvent.Sequence.ToString(); 
            chkIsOptional.Checked = this._triggerEvent.IsOptional;
            chkIsRepeatable.Checked = this._triggerEvent.IsRepeated;

            var s = this._repo.GetSegmentBy(this._triggerEvent.Version, this._triggerEvent.Segment);

            gridSegments.DataSource = s;

        }
        #endregion

        #region Constructor 
        public frmTriggerEventAddEdit(HL7SchemaRepository repo, TriggerEvent triggerEvent) : base()
        {
            InitializeComponent();
            this._repo = repo;

            CreateMenuItems();
            PopulateControls();

            this._triggerEvent = triggerEvent;
            if (this._triggerEvent != null)
            {
                this.Text = string.Format("Trigger Event Update: {0}_{1} {2} version: {3}", this._triggerEvent.MessageType, this._triggerEvent.EventType, this._triggerEvent.Segment, this._triggerEvent.Version);
                this.btnAddSegment.Enabled = true;
                this.PopulateFormData();
            }
            else
            {
                this.Text = "Add Trigger Event";
                this.btnAddSegment.Enabled = false;
            }

        }

        #endregion

        #region Form Methods

        private void ToolStripMenuItemNew_Click(object sender, EventArgs e)
        {
            this._triggerEvent = null;
            gridSegments.DataSource = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isSaved = true;
            string message = string.Empty;                    

            try
            {
                if (this._triggerEvent == null)
                    this._triggerEvent = new TriggerEvent();

                this._triggerEvent.Segment = txtSegment.Text;
                this._triggerEvent.Version = ((HL7Parser.Version)cmbHL7Versions.SelectedItem).Name;
                this._triggerEvent.MessageType = ((MessageType)cmbMessageType.SelectedItem).MessageType1;
                this._triggerEvent.EventType = ((EventType)cmbEventType.SelectedItem).EventType1;
                this._triggerEvent.Sequence = long.Parse(txtSequence.Text);
                this._triggerEvent.IsOptional = chkIsOptional.Checked;
                this._triggerEvent.IsRepeated = chkIsRepeatable.Checked;

                if (this._triggerEvent.Id == 0)
                {
                    this._repo.AddNew<TriggerEvent>(this._triggerEvent);
                }
                else
                    this._repo.Save();

                message = string.Format("Successfully saved {0}", this._triggerEvent.Segment);
            }
            catch(Exception ex)
            {
                message = string.Format("Error: {0}. Inner Exception: {1}", ex.Message, ex.InnerException);
                isSaved = false;
            }

            this.PopulateFormData();

            if (OnTriggerEventCompleted != null)
                OnTriggerEventCompleted(isSaved);

            MessageBox.Show(message);
        }

        
        #endregion

    }
}
