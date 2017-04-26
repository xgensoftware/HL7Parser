using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using HL7Parser;
using HL7Parser.Parser;
using HL7Core;
using HL7ExplorerBL.Entities;
using HL7Parser.Models;
using HL7Parser.Repository;
using HtmlAgilityPack;
using com.Xgensoftware.Core;
using System.Xml.Serialization;

namespace EDIParseConsole
{
    class Program
    {
        #region static Variables 
        static ILogger log = null;
        #endregion

        #region " Private Methods "
        private static void ParseMessage()
        {
            Console.WriteLine(DateTime.Now.ToString());

            PipeParser parse = new PipeParser();
            string filePath = @"C:\Users\anthony.sanfilippo\Downloads\HL7\A08_BO00000119_BO0000011231_20170224210724_fd105be7-51f8-41f0-ad6a-d2116ef75438.hl7";
            string message = File.ReadAllText(filePath);

            HL7Message temp = parse.Parse(message);

            string filename = string.Format("{0}{1}.hl7", DateTime.Now.ToString("yyyyMMddHHmmss"), temp.MessageToken.MessageControlId);
            filePath = @"C:\Development\HL7Parser\" + filename;

            HL7FileBuilder builder = new HL7FileBuilder("2.5", "ADT", "A08");
            //builder.EnableLogging = true;
            builder.CreateFile(temp, filePath);


            //Console.WriteLine(DateTime.Now.ToString());
            //Console.WriteLine(temp.SegmentString());
            //var segment = temp.Events.Where(x => x.Name == "MSH").FirstOrDefault();
        }

        //private static string DataTypeMap(string type)
        //{
        //    string dataType = "String";

        //    switch (type)
        //    {
        //        case "XPN":
        //        case "XTN":
        //        case "XAS":
        //        case "XCN":
        //            dataType = type;
        //            break;

        //        case "TS":
        //            dataType = "DateTime";
        //            break;
        //    }

        //    return dataType;
        //}

        //private static void CreateSegment(string segment, string version)
        //{           
        //    HL7SchemaRepository rep = new HL7SchemaRepository();


        //    HtmlNodeCollection desc = null;
        //    try
        //    {
        //        log.LogMessage(LogMessageType.INFO, string.Format("Starting segment {0}, version {1}", segment, version));
        //        string url = string.Format("http://hl7-definition.caristix.com:9010/Default.aspx?version=HL7%20v{0}&segment={1}", version, segment);
        //        var Webget = new HtmlWeb();
        //        var doc = Webget.Load(url);
        //        desc = doc.DocumentNode.SelectNodes("/html[1]/body[1]/div[5]/div[1]/div[3]/table[1]/tr");
        //    }
        //    catch(Exception ex)
        //    {
        //        log.LogMessage(LogMessageType.INFO, string.Format("Failure scraping segment {0}, version {1}. ERROR: {2}", segment, version, ex.Message));
        //    }

        //    if (desc != null)
        //    {
        //        foreach (HtmlNode node in desc)
        //        {
        //            if (node.Name == "tr")
        //            {
        //                Segment s = new Segment();
        //                s.SegmentId = segment;
        //                s.Version = version;
        //                bool isValid = true;
        //                const string tdPattern = @"<td\b[^>]*?>(?<V>[\s\S]*?)</\s*td>";
        //                StringBuilder strNode = new StringBuilder();
        //                foreach (Match match in Regex.Matches(node.InnerHtml, tdPattern, RegexOptions.IgnoreCase))
        //                {
        //                    string value = match.Groups["V"].Value;
        //                    strNode.Append(value + "|");
        //                }

        //                if (strNode.Length > 0)
        //                {
        //                    strNode.Remove(strNode.Length - 1, 1);

        //                    try
        //                    {
        //                        string[] splitData = strNode.ToString().Split('|');

        //                        //0 Sequence string, split on .
        //                        string[] sequence = splitData[0].Split('.');
        //                        s.Sequence = long.Parse(sequence[1]);

        //                        //index 1 = length
        //                        s.Length = long.Parse(splitData[1]);

        //                        //index 2 - the type. needs to run agains regex to get
        //                        const string aPattern = @"<a\b[^>]*?>(?<V>[\s\S]*?)</\s*a>";
        //                        foreach (Match match in Regex.Matches(splitData[2], aPattern, RegexOptions.IgnoreCase))
        //                        {
        //                            string value = match.Groups["V"].Value;
        //                            s.DataType = DataTypeMap(value);
        //                        }

        //                        //index 3 optional
        //                        s.IsRequired = bool.Parse(splitData[3] == "R" ? "true" : "false");

        //                        //index 4 is repeating
        //                        s.IsRepeating = bool.Parse(splitData[4] == "*" ? "true" : "false");

        //                        //index 6 name
        //                        s.Name = splitData[6];
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        log.LogMessage(LogMessageType.ERROR, ex.Message);
        //                        isValid = false;
        //                    }

        //                    if (isValid)
        //                        rep.AddNew<Segment>(s);
        //                }
        //            }
        //        }
        //    }
        //    log.LogMessage(LogMessageType.INFO, string.Format("Ending segment {0}, version {1}", segment, version));

        //}

        //private static void ScrapeSegments()
        //{
        //    HL7SchemaRepository repo = new HL7SchemaRepository();
        //    List<string> collection = new List<string>();
        //    log.LogMessage(LogMessageType.INFO, string.Format("**************** Starting Scraping {0} ****************", DateTime.Now.ToString("yyyyMMdd hh:mm:ss")));

        //    //this will read in from a file

        //    string[] segments = ConfigurationManager.AppSettings["Segments"].ToString().Split(',');
        //    string version = ConfigurationManager.AppSettings["Version"].ToString();

        //    var database = repo.GetDistinctSegmentsBy(version);

        //    //only run for the ones that do not exists
        //    var finalList = segments.Except(database);
        //    Parallel.ForEach(finalList, (segmentData) =>
        //    {
        //        CreateSegment(segmentData, version);
        //    });

        //    log.LogMessage(LogMessageType.INFO, string.Format("**************** Completed Scraping {0} ****************", DateTime.Now.ToString("yyyyMMdd hh:mm:ss")));
        //}


        //private static void CreateMappingFile()
        //{
        //    //SegmentTableMappingList collection = new SegmentTableMappingList();
        //    //collection.SegmentMappings = new List<SegmentTableMapping>();
        //    //collection.MessageType = "ADT";
        //    //collection.EventType = "A01";
        //    //collection.Version = "2.3";

        //    //SegmentTableMapping msh = new SegmentTableMapping("MSH", "MessageHeader_MSH");
        //    //msh.ColumnMappings.Add(new SegmentDBColumnMapping("Sending Application", "Sending Application"));
        //    //msh.ColumnMappings.Add(new SegmentDBColumnMapping("Message Type", "MessageType"));
        //    //collection.SegmentMappings.Add(msh);
        //    //string xml = collection.ToXML();

        //    //Console.WriteLine(x);

        //    //Console.WriteLine(xml);
        //    //SegmentTableMappingList newCollection = x.FromXML<SegmentTableMappingList>();

        //}

        //private static void CreateHL7MessageFrom(string messageControlId)
        //{
        //    /*
        //    This needs to build an array object with each index in the array
        //    contains a | seperated string of the actual HL7 data.  From
        //    that the HL7Message object can be created.    
        //    */   

        //    HL7SchemaRepository hl7Repo = new HL7SchemaRepository();
        //    string fileName = @"C:\Development\HL7Parser\ADT_A08_2_5.xml";

        //    //1. Read the mapping file
        //    SegmentTableMappingList mapFile = File.ReadAllText(fileName).FromXML<SegmentTableMappingList>();
        //    log.LogMessage(LogMessageType.INFO,string.Format("Reading file {0}", fileName));

        //    //2. Get the hl7 data from the database based on the messageControlId. The user will enter the MessageControlId 
        //    mapFile.GetMessagesFromDB(messageControlId);
        //    log.LogMessage(LogMessageType.INFO, string.Format("Fetching data for MessageContolId {0}", messageControlId));

        //    //3. Get the HL7 Schema object from the configuration DB
        //    TriggerEvent[] triggerEvents = hl7Repo.GetTriggerEventsBy("2.5", "ADT", "A08");
        //    log.LogMessage(LogMessageType.INFO, string.Format("Fetching HL7 schema. Version {0} MessageType{1} EventType {2}","2.5","ADT","A08"));

        //    //4. This needs to be based on the data, so that the correct number of segments are created.
        //    //   Loop each DataTable from the map list and then match based on the map config   
        //    foreach(SegmentTableMapping tableMap in mapFile.SegmentMappings)
        //    {
        //        DataTable dt = tableMap.TableData;
        //        TriggerEvent tr = triggerEvents.Where(x => x.Segment == tableMap.SegmentName).FirstOrDefault();
        //        if(tr != null)
        //        {

        //        }
        //    }
        //}
        #endregion

        static void Main(string[] args)
        {
            LogType logType = (LogType)Enum.Parse(typeof(LogType), AppConfiguration.LoggingType);
            log = LogFactory.CreateLogger(logType);

            //ScrapeSegments();

            ParseMessage();

            //CreateMappingFile();

            //CreateHL7MessageFrom("20170224072126F446119");

            Console.ReadLine();
        }
    }
}
