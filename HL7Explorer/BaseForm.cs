﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HL7Parser;
using HL7Parser.Helper;
using HL7Parser.Repository;
namespace HL7Explorer
{
    public partial class BaseForm : Form
    {
        #region Member Variables 
        LogHelper _logger = null;
        protected HL7SchemaRepository _repo = null;
        #endregion

        public BaseForm()
        {
            InitializeComponent();

            this._logger = new LogHelper(AppConfiguration.ApplicationName);
        }

        protected void LogError(string message)
        {
            this._logger.LogMessage(LogType.ERROR, message);
        }

        protected void LogInfo(string message)
        {
            this._logger.LogMessage(LogType.INFO, message);
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
