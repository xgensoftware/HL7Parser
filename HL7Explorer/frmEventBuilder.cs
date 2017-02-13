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
    public partial class frmEventBuilder :BaseForm
    {
        #region Member Variables 
        #endregion 

        #region Private Methods 
        void PopulateFormControls()
        {

            cmbHL7Versions.Items.Add("2.1");
            cmbHL7Versions.Items.Add("2.2");
            cmbHL7Versions.Items.Add("2.3");
            cmbHL7Versions.Items.Add("2.3.1");
            cmbHL7Versions.Items.Add("2.4");
            cmbHL7Versions.Items.Add("2.5");
            cmbHL7Versions.SelectedIndex = cmbHL7Versions.FindStringExact("2.3");

            var messageType = this._repo.GetMessageTypes();
            cmbMessageType.DataSource = messageType;
            cmbMessageType.DisplayMember = "MessageType1";


            var eventType = this._repo.GetEventTypes();
            cmbEventType.DataSource = eventType;
            cmbEventType.DisplayMember = "EventType1";
        }

        void PopulateGrid()
        {
            dataGridView1.DataSource = null;
            string version = string.Empty;
            string messageType = string.Empty;
            string eventType = string.Empty;

            if (cmbHL7Versions.SelectedItem != null)
                version = cmbHL7Versions.SelectedItem.ToString();

            if (string.IsNullOrEmpty(version))
            {
                MessageBox.Show("You must select a version");
                cmbHL7Versions.Focus();
                return;
            }

            if (cmbMessageType.SelectedItem != null)
                messageType = ((MessageType)cmbMessageType.SelectedItem).MessageType1;

            if (string.IsNullOrEmpty(messageType))
            {
                MessageBox.Show("You must select a message type");
                cmbMessageType.Focus();
                return;
            }

            if (cmbEventType.SelectedItem != null)
                eventType = ((EventType)cmbEventType.SelectedItem).EventType1;

            if (string.IsNullOrEmpty(eventType))
            {
                MessageBox.Show("You must select an event type");
                cmbEventType.Focus();
                return;
            }

            List<TriggerEvent> triggerEvents = this._repo.GetTriggerEventsBy(version, messageType, eventType);
            
            dataGridView1.DataSource = triggerEvents;
        }
        #endregion

        #region Form Events 
        public frmEventBuilder(HL7SchemaRepository repo)
        {
            InitializeComponent();
            this.dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;

            this._repo = repo;
        }

        private void frmEventBuilder_Load(object sender, EventArgs e)
        {
            this.PopulateFormControls();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.PopulateGrid();
        }

        private void DataGridView1_CellDoubleClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            var row = (TriggerEvent)dataGridView1.SelectedRows[0].DataBoundItem;
            frmTriggerEventAddEdit frm = new frmTriggerEventAddEdit(this._repo,row);
            frm.OnTriggerEventCompleted += Frm_OnTriggerEventCompleted;
            frm.ShowDialog();

        }       

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmTriggerEventAddEdit frm = new frmTriggerEventAddEdit(this._repo,null);
            frm.OnTriggerEventCompleted += Frm_OnTriggerEventCompleted;
            frm.ShowDialog();
        }

        private void Frm_OnTriggerEventCompleted(bool isSuccess)
        {
            //Refresh the grid
            if(isSuccess)
                this.PopulateGrid();
        }
        #endregion
    }
}
