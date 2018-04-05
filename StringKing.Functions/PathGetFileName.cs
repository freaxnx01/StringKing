using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringKing.FunctionInterface;

namespace StringKing.Functions
{
    [StringFunction("PathGetFileName", "Returns the file name and extension of the specified path string.")]
    public class PathGetFileName : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            StringBuilder sb = new StringBuilder();

            List<string> lines = SplitByNewLine(input[0]);
            
            foreach (string line in lines)
            {
                sb.AppendLine(Path.GetFileName(line));
            }
            
            return sb.ToString();
        }

        public override string GetTestString()
        {
            return GetPathTestData();
        }
    }
}
