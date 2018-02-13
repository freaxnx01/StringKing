using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringKing.StringFunctionInterface;

namespace StringKing.StringFunctions
{
    [StringFunction("PathGetDirectoryName", "Returns the directory information for the specified path string.")]
    public class PathGetDirectoryName : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            StringBuilder sb = new StringBuilder();

            List<string> lines = SplitByNewLine(input[0]);
            
            foreach (string line in lines)
            {
                sb.AppendLine(Path.GetDirectoryName(line));
            }
            
            return sb.ToString();
        }

        public override string GetTestString()
        {
            return GetPathTestData();
        }
    }
}
