using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL7Parser.DataTypes;
using HL7Parser.Models;
using HL7Parser.Parser;

namespace EDIParseConsole
{
    class Program
    {
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
        #endregion

        static void Main(string[] args)
        {
            ParseMessage();
        }
    }
}
