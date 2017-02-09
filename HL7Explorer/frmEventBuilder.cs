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
namespace HL7Explorer
{
    public partial class frmEventBuilder :BaseForm
    {
        #region Member Variables 
        HL7DataEntities _dbCTX = null;
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

            var messageType = this._dbCTX.MessageTypes.Where(x => x.IsActive == true).OrderBy(x => x.MessageTypeId).ToList();
            cmbMessageType.DataSource = messageType;
            cmbMessageType.DisplayMember = "MessageType1";


            var eventType = this._dbCTX.EventTypes.Where(x => x.IsActive == true).OrderBy(x => x.EventType1).ToList();
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

            var triggerEvent = this._dbCTX.TriggerEvents
                .Where(x => x.Version == version && x.MessageType == messageType && x.EventType == eventType)
                .OrderBy(x => x.Sequence)
                .ToList();

            dataGridView1.DataSource = triggerEvent;
        }
        #endregion

        #region Form Events 
        public frmEventBuilder()
        {
            InitializeComponent();
            this.dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;

            this._dbCTX = new HL7DataEntities();
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
            frmTriggerEventAddEdit frm = new frmTriggerEventAddEdit(this._dbCTX,row);
            frm.OnTriggerEventCompleted += Frm_OnTriggerEventCompleted;
            frm.ShowDialog();

        }       

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmTriggerEventAddEdit frm = new frmTriggerEventAddEdit(this._dbCTX,null);
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
