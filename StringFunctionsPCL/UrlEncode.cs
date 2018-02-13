using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Web;
using StringKing.StringFunctionInterface;

namespace StringKing.StringFunctions
{
    [StringFunction("UrlEncode")]
    public class UrlEncode : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            //TODO PCL
            throw new NotImplementedException("PCL");

            //return HttpUtility.UrlEncode(input[0]);
        }

        public override string GetTestString()
        {
            return "http://msdn.microsoft.com/en-us/library/bb736357(VS.85).aspx";
        }
    }
}
