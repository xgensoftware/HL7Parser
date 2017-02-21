using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using HL7Parser;
using HL7Parser.Parser;
using HL7Parser.Helper;
using HL7Parser.Repository;
using HtmlAgilityPack;
namespace EDIParseConsole
{
    class Program
    {
        #region static Variables 
        static LogHelper log = new LogHelper(AppConfiguration.ApplicationName);
        #endregion

        #region " Private Methods "
        private static void ParseMessage()
        {
            PipeParser parse = new PipeParser();
            string filePath = @"C:\Users\anthony.sanfilippo\Downloads\HL7\1476286403448-1863881.txt.dpp";
            string message = File.ReadAllText(filePath);
            string[] temp = message.Split(new string[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i <= temp.Length - 1; i++)
            {
                string segment = temp[i].Substring(0, 3);
                if(segment == "MSH")
                {
                    //reorder the msh segment
                    temp[i] = string.Format("|{0}",temp[i]);
                }
                temp[i].Trim();

                
            }


            //HL7Message temp = parse.Parse(message);
            //var segment = temp.Events.Where(x => x.Name == "MSH").FirstOrDefault();
        }
        private static string DataTypeMap(string type)
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

        private static void CreateSegment(string segment, string version)
        {           
            HL7SchemaRepository rep = new HL7SchemaRepository();
            
            
            HtmlNodeCollection desc = null;
            try
            {
                log.LogMessage(LogType.INFO, string.Format("Starting segment {0}, version {1}", segment, version));
                string url = string.Format("http://hl7-definition.caristix.com:9010/Default.aspx?version=HL7%20v{0}&segment={1}", version, segment);
                var Webget = new HtmlWeb();
                var doc = Webget.Load(url);
                desc = doc.DocumentNode.SelectNodes("/html[1]/body[1]/div[5]/div[1]/div[3]/table[1]/tr");
            }
            catch(Exception ex)
            {
                log.LogMessage(LogType.INFO, string.Format("Failure scraping segment {0}, version {1}. ERROR: {2}", segment, version, ex.Message));
            }

            if (desc != null)
            {
                foreach (HtmlNode node in desc)
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
                                log.LogMessage(LogType.ERROR, ex.Message);
                                isValid = false;
                            }

                            if (isValid)
                                rep.AddNew<Segment>(s);
                        }
                    }
                }
            }
            log.LogMessage(LogType.INFO, string.Format("Ending segment {0}, version {1}", segment, version));

        }

        private static void ScrapeSegments()
        {
            HL7SchemaRepository repo = new HL7SchemaRepository();
            List<string> collection = new List<string>();
            log.LogMessage(LogType.INFO, string.Format("**************** Starting Scraping {0} ****************", DateTime.Now.ToString("yyyyMMdd hh:mm:ss")));

            //this will read in from a file

            string[] segments = ConfigurationManager.AppSettings["Segments"].ToString().Split(',');
            string version = ConfigurationManager.AppSettings["Version"].ToString();

            var database = repo.GetDistinctSegmentsBy(version);

            //only run for the ones that do not exists
            var finalList = segments.Except(database);
            Parallel.ForEach(finalList, (segmentData) =>
            {
                CreateSegment(segmentData, version);
            });

            log.LogMessage(LogType.INFO, string.Format("**************** Completed Scraping {0} ****************", DateTime.Now.ToString("yyyyMMdd hh:mm:ss")));
        }
        

        #endregion

        static void Main(string[] args)
        {
            ScrapeSegments();
        }
    }
}
