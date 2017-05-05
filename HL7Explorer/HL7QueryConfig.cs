using System;
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
using HL7Parser;
using HL7Parser.Repository;

namespace HL7Explorer
{
    /*
Setup the directory for the Query Editor

History
*********************************************************************************
Date        Author                  Description
*********************************************************************************
05/4/2017   Anthony Sanfilippo      Creation
*********************************************************************************
*/
    public partial class HL7QueryConfig : BaseForm
    {
        #region Member Variables

        #endregion

        #region Form Events 
        public delegate void QueryConfigSaveEvent(string pathToHL7Files);
        public event QueryConfigSaveEvent OnQueryConfigSaved;
        #endregion

        #region Private Methods
        void LoadMessageTypes()
        {
            var messageType = this._repo.GetMessageTypes();
            cmbMessageType.DataSource = messageType;
            cmbMessageType.DisplayMember = "MessageType1";

        }
        #endregion

        #region Constructor
        public HL7QueryConfig()
        {
            InitializeComponent();
            
            this.Text = SetFormText();

            _repo = new HL7SchemaRepository();
        }

        #endregion

        #region Form Methods
        private void HL7QueryConfig_Load(object sender, EventArgs e)
        {
            cmbMessageType.SelectedIndexChanged += CmbMessageType_SelectedIndexChanged;
            LoadMessageTypes();
        }

        private void btnSetQueryConfig_Click(object sender, EventArgs e)
        {
            //build the actual path to all the hl7 files
            StringBuilder pathToFiles = new StringBuilder();
            pathToFiles.Append(AppConfiguration.HL7QueryPath);

            //get message type
            pathToFiles.AppendFormat(@"\{0}", ((MessageType)cmbMessageType.SelectedItem).MessageType1);

            //get the facility directory from the drop down
            string facility = cmbFacility.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(facility))
            {
                pathToFiles.AppendFormat(@"\{0}", cmbFacility.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("You must select a facility.");
                return;
            }

            //parse out the year from the selected date
            pathToFiles.AppendFormat(@"\{0}", dtpFileDates.Value.Year.ToString());
            pathToFiles.AppendFormat(@"\{0}", dtpFileDates.Value.Month.ToString());
            pathToFiles.AppendFormat(@"\{0}", dtpFileDates.Value.Day.ToString());
            
            if (OnQueryConfigSaved != null)
                OnQueryConfigSaved(pathToFiles.ToString());

            this.Close();
        }


        private void CmbMessageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFacility.Items.Clear();

            string facilityPath = string.Format(@"{0}\{1}", AppConfiguration.HL7QueryPath, ((MessageType)cmbMessageType.SelectedItem).MessageType1);

            // build dropdown 
            foreach (string s in Directory.GetDirectories(facilityPath))
            {
                cmbFacility.Items.Add(s.Remove(0, facilityPath.Length + 1));
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
