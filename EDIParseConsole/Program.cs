using System;
using System.IO;
using System.Text;
using HL7Parser.Parser;
using HL7Core;
using HL7Parser.Models;
using HL7ExplorerBL.Services;
using HL7ExplorerBL.QueryParser;
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
            string query = "select * from MSH where MessageControlId = '123';";
            QueryParser parser = new QueryParser();
            parser.TokenizeQuery(query);

            //Console.ReadLine();
        }

        //static void Main(string[] args)
        //{
        //    LogType logType = (LogType)Enum.Parse(typeof(LogType), AppConfiguration.LoggingType);
        //    log = LogFactory.CreateLogger(logType);

        //    Console.WriteLine("Welcome to the HL7 Console.");
        //    Console.WriteLine("Please enter a command (Help for a list of commands): ");
        //    string command = Console.ReadLine();

        //    while (command.ToLower() != "exit")
        //    {
        //        switch (command.ToLower())
        //        {
        //            case "exit":
        //                break;

        //            case "help":
        //                StringBuilder help = new StringBuilder();
        //                help.AppendLine("Exit: exit console");
        //                help.AppendLine("Scrape: scrape HL7 segment column definitions");
        //                Console.WriteLine(help);
        //                break;

        //            case "scrape":
        //                Console.WriteLine("Please enter the scrape command and version");
        //                Console.WriteLine("Scrape Commands: SEGMENT, DATATYPE, DATATYPECOLUMN");
        //                Console.WriteLine("Usage: <ScrapeCommand>|<HL7Version> ");

        //                try
        //                {
        //                    string[] scrapeCmd = Console.ReadLine().Split('|');
        //                    SCRAPSERVICE_COMMAND cmd = (SCRAPSERVICE_COMMAND)Enum.Parse(typeof(SCRAPSERVICE_COMMAND), scrapeCmd[0]);
        //                    using (ScraperService scraper = new ScraperService())
        //                    {
        //                        scraper.ScrapeBy(cmd, scrapeCmd[1]);
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                    log.LogMessage(LogMessageType.ERROR, string.Format("Failed to run scrape service. ERROR: {0}", ex.Message));
        //                }

        //                break;
        //        }

        //        command = Console.ReadLine();
        //    }
        //}
    }
}
