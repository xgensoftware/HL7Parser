using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL7Parser.Models;

namespace HL7Parser.Parser
{
    public class Tokenizer
    {        
        public static Token CreateMessageToken(string[] message)
        {

            //Parse the message header based on the |
            string[] parsedMSH = message[0].Split('|');

            char fieldSep = Convert.ToChar(message[0].Substring(3, 1));
            char encoding = Convert.ToChar(message[0].Substring(4, 1));
            var trigger = parsedMSH[8].Split('^');
            Token t = new Token(fieldSep, encoding, parsedMSH[11], trigger[0], trigger[1]);

            //Get all segments from the message
            for (int idx = 0; idx <= message.Length-1; idx++)
            {
                t.AddSegment(message[idx].Substring(0, 3), message[idx]);
            }

            return t;
        }
 
    }
}
