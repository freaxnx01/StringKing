﻿using System.Collections.Generic;
using System.Web;
using StringKing.FunctionInterface;

namespace StringKing.Functions
{
    [StringFunction("UrlPathEncode")]
    public class UrlPathEncode : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            return HttpUtility.UrlPathEncode(input[0]);
        }

        public override string GetTestString()
        {
            return "http://msdn.microsoft.com/en-us/library/bb736357(VS.85).aspx";
        }
    }
}
