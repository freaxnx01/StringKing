using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using StringKing.FunctionInterface;

namespace StringKing.Functions
{
    [StringFunction("PathGetPathRoot", "Gets the root directory information of the specified path.")]
    public class PathGetPathRoot : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            StringBuilder sb = new StringBuilder();

            List<string> lines = SplitByNewLine(input[0]);
            
            foreach (string line in lines)
            {
                sb.AppendLine(Path.GetPathRoot(line));
            }
            
            return sb.ToString();
        }

        public override string GetTestString()
        {
            return GetPathTestData();
        }
        
        public static string Execute(params string[] input)
        {
            return CallDirect(MethodBase.GetCurrentMethod().DeclaringType, null, input);
        }
    }
}
