using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringKing.StringFunctionInterface;

namespace StringKing.StringFunctions
{
    [StringFunction("WiseInstallFile")]
    public class WiseInstallFile : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            const string template = "item: Install File\r\n  Source={0}\r\n  Destination=%MAINDIR%\\{0}\r\n  Flags=0000000010000010\r\nend";

            List<string> lines = SplitByNewLine(input[0]);
            StringBuilder sb = new StringBuilder();
            foreach (var line in lines)
            {
                sb.AppendLine(string.Format(template, line));
            }
            
            return sb.ToString();
        }
    }
}
