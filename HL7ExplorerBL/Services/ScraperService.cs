using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using HL7Core;
using HL7Parser;
using HL7Parser.Repository;
using HtmlAgilityPack;
using com.Xgensoftware.Core;

namespace HL7ExplorerBL.Services
{
    public enum SCRAPSERVICE_COMMAND
    {
        SEGMENT,
        DATATYPE
    }
    public class ScraperService : ServiceBase
    {
        #region Member Variables 

        #endregion

        #region Properties

        #endregion

        #region Constructor 
        public ScraperService()
        {
        }
        #endregion

        #region Private Methods 
        private string DataTypeMap(string type)
        {
            string dataType = "String";

            switch (type)
            {
                case "XPN":
                case "XTN":
                case "XAS":
                case "XCN":
                    dataType = type;
                    break;

                case "TS":
                    dataType = "DateTime";
                    break;
            }

            return dataType;
        }

        private void CreateSegment(string version, string segment)
        {
            HL7SchemaRepository repo = new HL7SchemaRepository();
            HtmlNodeCollection scrapedSegmentData = null;
            try
            {
                _fileLogger.LogMessage(LogMessageType.INFO, string.Format("Starting segment {0}, version {1}", segment, version));
                string url = string.Format("http://hl7-definition.caristix.com:9010/Default.aspx?version=HL7%20v{0}&segment={1}", version, segment);
                var Webget = new HtmlWeb();
                var doc = Webget.Load(url);
                scrapedSegmentData = doc.DocumentNode.SelectNodes("/html[1]/body[1]/div[5]/div[1]/div[3]/table[1]/tr");
            }
            catch (Exception ex)
            {
                _fileLogger.LogMessage(LogMessageType.INFO, string.Format("Failure scraping segment {0}, version {1}. ERROR: {2}", segment, version, ex.Message));
            }

            if (scrapedSegmentData != null)
            {
                foreach (HtmlNode node in scrapedSegmentData)
                {
                    if (node.Name == "tr")
                    {
                        Segment s = new Segment();
                        s.SegmentId = segment;
                        s.Version = version;
                        bool isValid = true;
                        const string tdPattern = @"<td\b[^>]*?>(?<V>[\s\S]*?)</\s*td>";
                        StringBuilder strNode = new StringBuilder();
                        foreach (Match match in Regex.Matches(node.InnerHtml, tdPattern, RegexOptions.IgnoreCase))
                        {
                            string value = match.Groups["V"].Value;
                            strNode.Append(value + "|");
                        }

                        if (strNode.Length > 0)
                        {
                            strNode.Remove(strNode.Length - 1, 1);

                            try
                            {
                                string[] splitData = strNode.ToString().Split('|');

                                //0 Sequence string, split on .
                                string[] sequence = splitData[0].Split('.');
                                s.Sequence = long.Parse(sequence[1]);

                                //index 1 = length
                                s.Length = long.Parse(splitData[1]);

                                //index 2 - the type. needs to run agains regex to get
                                const string aPattern = @"<a\b[^>]*?>(?<V>[\s\S]*?)</\s*a>";
                                foreach (Match match in Regex.Matches(splitData[2], aPattern, RegexOptions.IgnoreCase))
                                {
                                    string value = match.Groups["V"].Value;
                                    s.DataType = DataTypeMap(value);
                                }

                                //index 3 optional
                                s.IsRequired = bool.Parse(splitData[3] == "R" ? "true" : "false");

                                //index 4 is repeating
                                s.IsRepeating = bool.Parse(splitData[4] == "*" ? "true" : "false");

                                //index 6 name
                                s.Name = splitData[6];
                            }
                            catch (Exception ex)
                            {
                                _fileLogger.LogMessage(LogMessageType.ERROR, ex.Message);
                                isValid = false;
                            }

                            if (isValid)
                                repo.AddNew<Segment>(s);
                        }
                    }
                }
            }
            _fileLogger.LogMessage(LogMessageType.INFO, string.Format("Ending segment {0}, version {1}", segment, version));

        }

        private void ScrapeSegmentDataBy(string hl7Version)
        {
            HL7SchemaRepository repo = new HL7SchemaRepository();
            List<string> collection = new List<string>();
            

            SegmentConfiguration segmentConfig = repo.GetSegmentConfigurationByVersion(hl7Version);
            if (segmentConfig != null)
            {
                string[] segmentsToScrape = segmentConfig.Segments.Split(',');
                string[] currentSegments = repo.GetDistinctSegmentsBy(hl7Version);

                List<string> segmentsNeeded = segmentsToScrape.Except(currentSegments).ToList();

                Parallel.ForEach(segmentsNeeded, (segmentData) =>
                {
                    CreateSegment(hl7Version, segmentData);
                });
            }
            else
            {
                _fileLogger.LogMessage(LogMessageType.INFO, string.Format("No segment configuration found for HL7 version {0}", hl7Version));
            }            
        }

        private void ScrapeDataTypeBy(string hl7Version)
        {
            HtmlNode scrapedData = null;

            try
            {
                string url = string.Format("http://hl7-definition.caristix.com:9010/Default.aspx?version=HL7%20v{0}", hl7Version);
                var Webget = new HtmlWeb();
                HtmlDocument doc = Webget.Load(url);
                scrapedData = doc.DocumentNode.SelectSingleNode("//select[@id='cbxDataType']");
            }
            catch (Exception ex)
            {
                _fileLogger.LogMessage(LogMessageType.INFO, string.Format("Failed to scrape DataType for version {0}. ERROR: {0}",hl7Version,ex.Message));
            }

            if(scrapedData != null)
            {
                    foreach (HtmlNode option in scrapedData.ChildNodes)
                    {
                        if (option.InnerText != "- Choose a data type" & option.InnerText != "\r\n\t" & !string.IsNullOrEmpty(option.InnerText))
                        {
                            bool isValid = true;
                            HL7SchemaRepository repo = new HL7SchemaRepository();
                            DataType dt = new DataType();

                            try
                            {
                                dt.Name = option.InnerText;
                                dt.Version = hl7Version;
                            }
                            catch (Exception ex)
                            {
                                _fileLogger.LogMessage(LogMessageType.INFO, string.Format("Error creating DataType {0} version {1}. ERROR: {2}", option.InnerText, hl7Version, ex.Message));
                                isValid = false;
                            }

                            if (isValid)
                            {
                                repo.AddNew<DataType>(dt);
                                _fileLogger.LogMessage(LogMessageType.INFO, string.Format("Created DataType {0} version {1}", option.InnerText, hl7Version));
                            }
                        }
                    }
            }
        }

        private void ScrapeDataTypeColumnBy(string hl7Version, string columnName)
        {
            string url = string.Format("http://hl7-definition.caristix.com:9010/Default.aspx?version=HL7%20v{0}&dataType={1}", hl7Version, columnName);
        }
        #endregion

        #region Public Methods
        public void ScrapeBy(SCRAPSERVICE_COMMAND command, string hl7Version)
        {
            _fileLogger.LogMessage(LogMessageType.INFO, string.Format("**************** Starting Scraping for {0} {1} ****************", command.ToString(),DateTime.Now.ToString("yyyyMMdd hh:mm:ss")));

            switch (command)
            {
                case SCRAPSERVICE_COMMAND.SEGMENT:
                    ScrapeSegmentDataBy(hl7Version);
                    break;

                case SCRAPSERVICE_COMMAND.DATATYPE:
                    ScrapeDataTypeBy(hl7Version);
                    break;
            }

            _fileLogger.LogMessage(LogMessageType.INFO, string.Format("**************** Completed Scraping for {0} {1} ****************", command.ToString(), DateTime.Now.ToString("yyyyMMdd hh:mm:ss")));
        }

        #endregion
    }
}
