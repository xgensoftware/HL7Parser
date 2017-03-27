﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using com.Xgensoftware.Core;
using HL7Core;
using HL7ExplorerBL.Entities;
namespace HL7Explorer
{
    public partial class frmDatabaseView : BaseForm
    {
        #region Member Variables 
        string _segmentName = string.Empty;

        SegmentTableMapping _segmentMapping = null;
        #endregion

        #region Private Methods
        private void GetMappingFile()
        {
            
            
        }
        #endregion

        public frmDatabaseView(SegmentTableMapping stm)
        {
            InitializeComponent();

            this.Text = stm.SegmentName;

            try
            {
                gridSegment.DataSource = stm.TableData;
            }
            catch (Exception ex)
            {
                LogError(string.Format("Database view of segment {0} had an unexpected error. {1}", stm.SegmentName,ex.Message));
            }
        }

        private void frmDatabaseView_Load(object sender, EventArgs e)
        {                    

           
        }
    }
}
