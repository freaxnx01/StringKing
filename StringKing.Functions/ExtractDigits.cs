using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

using StringKing.FunctionInterface;

namespace StringFunctionsDnpExtensions
{
    [StringFunction("ExtractDigits")]
    public class ExtractDigits : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            return string.Join(null, Regex.Split(input[0], @"[^\d]"));
        }
        
        public static string Execute(params string[] input)
        {
            return CallDirect(MethodBase.GetCurrentMethod().DeclaringType, null, input);
        }
    }
}
