using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringKing.FunctionInterface;

namespace StringKing.Functions
{
    [StringFunction("ExtractLowerCaseWords")]
    public class ExtractLowerCaseWords : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            List<string> lines = SplitByNewLine(input[0]);
            StringBuilder sb = new StringBuilder();
            foreach (string line in lines)
            {
                if (line == line.ToLower())
                {
                    sb.AppendLine(line);
                }
            }

            return sb.ToString();
        }

        public override string GetTestString()
        {
            return "zeile1\r\nZEILE2\r\nzeile3\r\nZEILE4";
        }
    }
}
