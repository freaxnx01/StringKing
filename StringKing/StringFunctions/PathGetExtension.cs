using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringKing.StringFunctionInterface;

namespace StringKing.StringFunctions
{
    [StringFunction("PathGetExtension", "Returns the extension of the specified path string.")]
    public class PathGetExtension : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            StringBuilder sb = new StringBuilder();

            List<string> lines = SplitByNewLine(input[0]);
            
            foreach (string line in lines)
            {
                sb.AppendLine(Path.GetExtension(line));
            }
            
            return sb.ToString();
        }

        public override string GetTestString()
        {
            return GetPathTestData();
        }
    }
}
