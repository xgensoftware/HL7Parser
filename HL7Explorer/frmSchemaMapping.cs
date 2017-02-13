using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HL7Explorer
{
    public partial class frmSchemaMapping : BaseForm
    {
        #region Private Methods 
        private void PopulateControls()
        {
            cmbVersions.Items.Add("2.1");
            cmbVersions.Items.Add("2.2");
            cmbVersions.Items.Add("2.3");
            cmbVersions.Items.Add("2.3.1");
            cmbVersions.Items.Add("2.4");
            cmbVersions.Items.Add("2.5");
            cmbVersions.SelectedIndex = cmbVersions.FindStringExact("2.3");


        }
        #endregion

        #region Form Events
        public frmSchemaMapping()
        {
            InitializeComponent();
        }

        private void frmSchemaMapping_Load(object sender, EventArgs e)
        {
            this.PopulateControls();
        }
        #endregion
    }
}
