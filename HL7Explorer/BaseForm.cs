﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HL7Parser.Repository;
using HL7Core;
using HL7ExplorerBL.Repository;
namespace HL7Explorer
{
    /*
    History

    *******************************************************
    Date        Author                  Description
    *******************************************************
    04/4/2017   Anthony Sanfilippo      Added protected Progress bar
                                        StartProgress/StopProgress methods

    */
    public partial class BaseForm : Form
    {
        #region Member Variables 
        protected enum Enable_Disable_Control
        {
            ENABLE,
            DISABLE
        }

        protected ILogger _logger = null;
        protected HL7SchemaRepository _repo = null;
        protected GenericDBRepository _dataRepo = null;
        protected frmProgress _progressIndicator = null;
        #endregion

        protected virtual void CreateMenuItems() { }

        protected string SetFormText()
        {
            return string.Format(string.Format("{0}: {1}", Application.ProductName, ProductVersion));
        }

        public BaseForm()
        {
            InitializeComponent();           
            
            try
            {
                _dataRepo = new GenericDBRepository(AppConfiguration.DBProvider, AppConfiguration.DBConnection);
            }
            catch { }

            this._logger = LogFactory.CreateLogger(LogType.FILE);
            this.FormClosing += FrmTriggerEventAddEdit_FormClosing;           
        }       

        protected void StartProgressBar()
        {
            _progressIndicator = new frmProgress();
            _progressIndicator.ShowDialog();
        }

        protected void StopProgressBar()
        {
            if (_progressIndicator != null)
            {
                _progressIndicator.Stop();
                _progressIndicator.Close();
                _progressIndicator = null;
            }
        }
       
        protected void LogError(string message)
        {
            this._logger.LogMessage(LogMessageType.ERROR, message);
            MessageBox.Show(message);
        }

        protected void LogInfo(string message)
        {
            this._logger.LogMessage(LogMessageType.INFO, message);
            MessageBox.Show(message);
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }        

        private void FrmTriggerEventAddEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
