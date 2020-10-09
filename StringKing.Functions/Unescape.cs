using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using StringKing.FunctionInterface;

namespace StringKing.Functions
{
    [StringFunction("Unescape")]
    public class Unescape : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            return Regex.Unescape(input[0]);
        }

        public override string GetTestString()
        {
            // w=nat\u00fcrliche Person -> w=natürliche Person
            return @"w=nat\u00fcrliche Person";
        }
        
        public static string Execute(params string[] input)
        {
            return CallDirect(MethodBase.GetCurrentMethod().DeclaringType, null, input);
        }
    }
}
