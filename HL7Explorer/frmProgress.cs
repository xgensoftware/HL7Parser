using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HL7Explorer
{
    public partial class frmProgress : Form
    {
        #region Member Variables
        bool _isRunning = false;
        #endregion

        #region Properties
        
        #endregion

        #region Form Events 

        public frmProgress()
        {
            InitializeComponent();

            this.Load += FrmProgress_Load;
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += BackgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;
            backgroundWorker1.ProgressChanged += BackgroundWorker1_ProgressChanged;
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int progress = e.ProgressPercentage;
            progressBar1.Value = progress;
            if (progressBar1.Value == 100)
            {
                progressBar1.Value = 0;
            }
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int x = 0; x <= 100; x++)
            {
                Thread.Sleep(500);
                if (_isRunning == true)
                    backgroundWorker1.ReportProgress(x);
                else
                {
                    backgroundWorker1.ReportProgress(100);
                    break;
                }
            }
        }

        private void FrmProgress_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            _isRunning = true;
            backgroundWorker1.RunWorkerAsync();
        }

        public void Stop()
        {
            _isRunning = false;
            backgroundWorker1.CancelAsync();
        }
        #endregion
    }
}
