using System;
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

namespace HL7Explorer
{
    public partial class BaseForm : Form
    {
        #region Member Variables 
        protected ILogger _logger = null;
        protected HL7SchemaRepository _repo = null;
        #endregion

        public BaseForm()
        {
            InitializeComponent();           
            

           // LogType logType = (LogType)Enum.Parse(typeof(LogType), AppConfiguration.LoggingType);
            this._logger = LogFactory.CreateLogger(LogType.FILE);
        }       

        protected void LogError(string message)
        {
            this._logger.LogMessage(LogMessageType.ERROR, message);
        }

        protected void LogInfo(string message)
        {
            this._logger.LogMessage(LogMessageType.INFO, message);
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
