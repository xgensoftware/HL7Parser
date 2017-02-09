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
    public partial class Form1 : Form
    {
        #region Constructor 
        public Form1()
        {
            InitializeComponent();
        }
        #endregion

        #region Form Events
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("{0}: {1}", Application.ProductName, Application.ProductVersion);
        }

        private void toolStripMenuTriggerBuild_Click(object sender, EventArgs e)
        {
            frmEventBuilder frm = new frmEventBuilder();
            frm.ShowDialog();
        }
        
        private void toolStripClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
