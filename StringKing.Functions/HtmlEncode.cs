using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Web;
using StringKing.FunctionInterface;

namespace StringKing.Functions
{
    [StringFunction("HtmlEncode")]
    public class HtmlEncode : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            return WebUtility.HtmlEncode(input[0]);
        }

        public override string GetTestString()
        {
            // " -> &quot;
            return @"text ""in"" quotes.";
        }
        
        public static string Execute(params string[] input)
        {
            return StringFunctionBase.CallDirect(MethodBase.GetCurrentMethod().DeclaringType, null, input);
        }
    }
}
