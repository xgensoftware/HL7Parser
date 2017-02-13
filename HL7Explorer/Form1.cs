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
    public partial class Form1 : Form
    {
        #region Member Variables 
        HL7SchemaRepository _repo = null;
        #endregion

        #region Constructor 
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
            this._repo = RepositoryFactory.CreateRepository<HL7SchemaRepository>();


        }        
        #endregion

        #region Form Events
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("{0}: {1}", Application.ProductName, Application.ProductVersion);
        }

        private void toolStripMenuTriggerBuild_Click(object sender, EventArgs e)
        {
            frmEventBuilder frm = new frmEventBuilder(this._repo);
            frm.ShowDialog();
        }
        
        private void toolStripClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._repo.Dispose();
        }

        private void toolStripMenuItemViewHL7Message_Click(object sender, EventArgs e)
        {
            frmViewHL7Message frm = new frmViewHL7Message(this._repo);
            frm.ShowDialog();
        }
        #endregion
    }
}
