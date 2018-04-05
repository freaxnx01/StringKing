using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using StringKing.FunctionInterface;
using System.Text.RegularExpressions;

namespace StringFunctionsDnpExtensions
{
    [StringFunction("GetWords")]
    public class GetWords : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string word in Regex.Split(input[0], @"\W"))
            {
                sb.AppendLine(word);
            }
            return sb.ToString();
        }
    }
}
