using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Web;
using StringKing.FunctionInterface;

namespace StringKing.Functions
{
    [StringFunction("HtmlDecode")]
    public class HtmlDecode : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            return WebUtility.HtmlDecode(input[0]);
        }

        public override string GetTestString()
        {
            // &quot; -> "
            return @"&quot;Geschlecht. Werte: w=nat\u00fcrliche Person weiblichen Geschlechts; m=nat\u00fcrliche Person m\u00e4nnlichen Geschlechts.&quot;";
        }
        
        public static string Execute(params string[] input)
        {
            return StringFunctionBase.CallDirect(MethodBase.GetCurrentMethod().DeclaringType, null, input);
        }
    }
}
