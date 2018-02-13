using System;
using System.Collections.Generic;
//using System.Web;
using StringKing.StringFunctionInterface;

namespace StringKing.StringFunctions
{
    [StringFunction("UrlDecode")]
    public class UrlDecode : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            //TODO PCL
            throw new NotImplementedException("PCL");
            
            //return HttpUtility.UrlDecode(input[0]);
        }

        public override string GetTestString()
        {
            return "http://msdn.microsoft.com/en-us/library/bb736357%28VS.85%29.aspx";
        }
    }
}
