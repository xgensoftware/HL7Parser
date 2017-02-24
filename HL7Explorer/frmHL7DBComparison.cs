using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HL7Core;
using HL7Parser.Models;
using HL7ExplorerBL.Repository;
namespace HL7Explorer
{
    public partial class frmHL7DBComparison : BaseForm
    {
        #region Member Variables 

        GenericDBRepository _repo = null;
        HL7Message _hl7Message = null;

        #endregion

        #region Private Methods

        private void LoadControls()
        {
            string segments = _hl7Message.SegmentString();
            cmbDBTables.DataSource = _repo.GetDatabaseTables(segments).Collection;
            cmbDBTables.DisplayMember = "TableName";
        }
        #endregion

        #region Form Events
        public frmHL7DBComparison(HL7Message msg)
        {
            InitializeComponent();
            this.Load += FrmHL7DBComparison_Load;

            _repo = new GenericDBRepository(AppConfiguration.DBProvider, AppConfiguration.DBConnection);

            this._hl7Message = msg;          
                        
        }

        private void FrmHL7DBComparison_Load(object sender, EventArgs e)
        {
            LoadControls();
        }
        #endregion
    }
}
