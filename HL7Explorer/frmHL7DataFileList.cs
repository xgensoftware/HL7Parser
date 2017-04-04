using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using HL7Parser.Models;
using HL7Parser.Parser;
using com.Xgensoftware.Core;

namespace HL7Explorer
{
    /*
    Form to show the HL7 data file with multiple HL7 Messages in a single file
    The file will be split and an entry in the list for each message, from which the
    user can select and the data will be shown in the message from

    History
    *******************************************************
    Date        Author                  Description
    *******************************************************
    04/3/2017   Anthony Sanfilippo      Initial Creation
    */

    public partial class frmHL7DataFileList : HL7Explorer.BaseForm
    {
        #region Member Variables
        string[] _hl7DataList;
        string _hl7DataFile = string.Empty;
        bool _isSuccess = true;
        #endregion

        #region Form Events
        public delegate void HL7DataLoad(HL7Message hl7Object);
        public event HL7DataLoad OnHL7ObjectSelected;

        public delegate void HL7DataFileParsed(bool isSuccess);
        public event HL7DataFileParsed OnHL7DataFileParsed;
        #endregion

        #region Public Methods
        public void LoadMessages(string hl7DataFile)
        {
            _hl7DataFile = hl7DataFile;                     
            bgwParse.RunWorkerAsync();
            StartProgressBar();
        }

        #endregion

        #region Form Methods
        public frmHL7DataFileList()
        {
            InitializeComponent();
            lstFileData.DoubleClick += LstFileData_DoubleClick;
            bgwParse.DoWork += BgwParse_DoWork;
            bgwParse.RunWorkerCompleted += BgwParse_RunWorkerCompleted;
            this.Text = SetFormText();                       
        }

        private void BgwParse_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           if(OnHL7DataFileParsed != null)
            {
                OnHL7DataFileParsed(_isSuccess);
            }
            StopProgressBar();
        }

        private void BgwParse_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string data = File.ReadAllText(_hl7DataFile);
                string[] stringSeparators = new string[] { "\r\n" };
                this._hl7DataList = data.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            }
            catch (Exception ex)
            {
                LogError(string.Format("Failed to parse the data file. ERROR: {0}", ex.Message));
                _isSuccess = false;
            }

            for (int x = 0; x <= this._hl7DataList.Length - 1; x++)
            {
                try
                {
                    PipeParser parser = new PipeParser();
                    HL7Message msg = parser.Parse(_hl7DataList[x]);
                    lstFileData.Items.Add(msg);
                }
                catch (ParserException ex)
                {
                    LogError(string.Format("Failed to parse. ERROR: {0}", ex.Message));
                    _isSuccess = false;
                }
            }
        }

        private void frmHL7DataFileList_Load(object sender, EventArgs e)
        {
           
        }

        private void LstFileData_DoubleClick(object sender, EventArgs e)
        {
            HL7Message msg = lstFileData.SelectedItem as HL7Message;

            if(OnHL7ObjectSelected != null)
            {
                OnHL7ObjectSelected(msg);
            }
        }
        #endregion
    }
}
