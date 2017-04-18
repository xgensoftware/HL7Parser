using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL7Parser.Models;
using HL7Parser.Repository;

namespace HL7Parser.Parser
{
    public class HL7Builder : ParserBase
    {
        /// <summary>
        /// Builds HL7 file based on version and array of data
        /// </summary>
        #region Member Variables 
        HL7SchemaRepository _repo = null;
        

        string _messageType = string.Empty;
        string _eventType = string.Empty;
        string _hl7Version = string.Empty;
        #endregion

        #region Properties
        public bool EnableLogging
        {
            get { return _loggingEnabled; }
            set { _loggingEnabled = value; }
        }
        #endregion

        #region Constructor 
        public HL7Builder(string hl7Version, string messageType, string eventType)
        {
            _repo = new HL7SchemaRepository();
            _hl7Version = hl7Version;
            _messageType = messageType;
            _eventType = eventType;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Create and HL7 formated file from the TriggerEvent Array
        /// </summary>
        /// <param name="hl7Data">
        /// TriggerEvent array with the segment schema and data.
        /// </param>
        /// <param name="filePath">Path to save the HL7 file, including file name</param>
        /// <returns>
        /// True: successful file creation
        /// False: failed to create the file    
        /// </returns>
        public bool CreateFile(HL7Message hl7Data, string filePath)
        {
            bool isSuccess = true;
            StringBuilder hl7File = new StringBuilder();

            try
            {
                foreach (KeyValuePair<int,HL7Segment> hl7SegmentItem in hl7Data.Events)
                {
                    StringBuilder sbProp = new StringBuilder();
                    HL7Segment tr = hl7SegmentItem.Value;
                    sbProp.AppendFormat("{0}|", tr.Name);
                    foreach(HL7SegmentColumn column in tr.Segments)
                    {
                        sbProp.AppendFormat("{0}|",column.Value);
                        LogInfoMessage(string.Format("Successfully added segment column {0} to segment {1}", column.Name,tr.Name));
                    }

                    sbProp.Remove(sbProp.Length - 1, 1);
                    hl7File.AppendLine(sbProp.ToString());
                    LogInfoMessage(string.Format("Successfully added segment {0} to file {1}", tr.Name, filePath));
                }
            }
            catch(Exception ex)
            {
                LogErrorMessage(string.Format("Failed to create HL7 data object for file {0}. ERROR: {1}", filePath, ex.Message));
            }

            try
            {
                File.WriteAllText(filePath, hl7File.ToString());
                LogInfoMessage(string.Format("Creating file {0}", filePath));
            }
            catch(Exception ex)
            {
                LogErrorMessage(string.Format("Failed to create file to {0}. ERROR: {1}", filePath, ex.Message));
            }

            return isSuccess;
        }

        #endregion
    }
}
