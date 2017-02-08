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
    public partial class frmEventBuilder : Form
    {
        #region Private Methods 
        void PopulateForms()
        {

            cmbHL7Versions.Items.Add("2.1");
            cmbHL7Versions.Items.Add("2.2");
            cmbHL7Versions.Items.Add("2.3");
            cmbHL7Versions.Items.Add("2.3.1");
            cmbHL7Versions.Items.Add("2.4");
            cmbHL7Versions.Items.Add("2.5");

            using (HL7DataEntities dbContext = new HL7DataEntities())
            {
                var messageType = dbContext.MessageTypes.Where(x => x.IsActive == true).OrderBy(x => x.MessageTypeId).ToList();
                foreach(var mt in messageType)
                    cmbMessageType.Items.Add(mt.MessageType1);

                var eventType = dbContext.EventTypes.Where(x => x.IsActive == true).OrderBy(x => x.EventType1).ToList();
                foreach (var et in eventType)
                    cmbEventType.Items.Add(et.EventType1);
            }
        }
        #endregion

        #region Form Events 
        public frmEventBuilder()
        {
            InitializeComponent();
        }

        private void frmEventBuilder_Load(object sender, EventArgs e)
        {
            this.PopulateForms();
        }

        private void btnQuery_Click(object sender, EventArgs e)
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
                messageType = cmbMessageType.SelectedItem.ToString();

            if (string.IsNullOrEmpty(messageType))
            {
                MessageBox.Show("You must select a message type");
                cmbMessageType.Focus();
                return;
            }

            if(cmbEventType.SelectedItem != null)
                eventType = cmbEventType.SelectedItem.ToString();

            if (string.IsNullOrEmpty(eventType))
            {
                MessageBox.Show("You must select an event type");
                cmbEventType.Focus();
                return;
            }

            using (HL7DataEntities dbContext = new HL7DataEntities())
            {
                var triggerEvent = dbContext.TriggerEvents
                    .Where(x => x.Version == version && x.MessageType == messageType && x.EventType == eventType)
                    .OrderBy(x => x.Sequence)
                    .ToList();

                dataGridView1.DataSource = triggerEvent;
            }
        }
        #endregion        
    }
}
