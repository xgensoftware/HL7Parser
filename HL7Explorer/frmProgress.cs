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
    public partial class frmProgress : Form
    {
        public frmProgress()
        {
            InitializeComponent();

            this.Load += FrmProgress_Load;
        }

        private void FrmProgress_Load(object sender, EventArgs e)
        {
            
        }
    }
}
