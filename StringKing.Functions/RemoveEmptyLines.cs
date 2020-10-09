using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using StringKing.FunctionInterface;

namespace StringKing.Functions
{
    [StringFunction("RemoveEmptyLines")]
    public class RemoveEmptyLines : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            StringBuilder sb = new StringBuilder();

            string[] lines = input[0].Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                sb.AppendLine(line);
            }

            return sb.ToString();
        }

        public override string GetTestString()
        {
            return string.Format("line 1{0}{0}{0}line 2{0}{0}line 3", Environment.NewLine);
        }
        
        public static string Execute(params string[] input)
        {
            return CallDirect(MethodBase.GetCurrentMethod().DeclaringType, null, input);
        }
    }
}
