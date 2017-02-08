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
            string filePath = @"C:\Users\anthony.sanfilippo\Downloads\HL7\2016-12-29 15.15.0_68140460.dat";

            string message = File.ReadAllText(filePath);

            HL7Message temp = parse.Parse(message);
        }
        #endregion

        static void Main(string[] args)
        {
            ParseMessage();
        }
    }
}
