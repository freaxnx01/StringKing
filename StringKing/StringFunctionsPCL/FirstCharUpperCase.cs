﻿using System.Collections.Generic;
using System.Text;
using StringKing.StringFunctionInterface;

namespace StringKing.StringFunctions
{
    [StringFunction("FirstCharUpperCase")]
    public class FirstCharUpperCase : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            List<string> lines = SplitByNewLine(input[0]);

            StringBuilder sb = new StringBuilder();

            foreach (string line in lines)
            {
                string newLine = line;

                if (!string.IsNullOrEmpty(newLine))
                {
                    char[] charArray = newLine.ToCharArray();
                    charArray[0] = char.ToUpper(charArray[0]);
                    newLine = new string(charArray);
                }

                sb.AppendLine(newLine);
            }

            return sb.ToString();
        }
    }
}