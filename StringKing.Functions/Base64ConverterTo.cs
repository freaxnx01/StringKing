﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using StringKing.FunctionInterface;

namespace StringKing.Functions
{
    [StringFunction("Base64ConverterTo")]
    public class Base64ConverterTo : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            byte[] byteArray = Encoding.Default.GetBytes(input[0]);
            return Convert.ToBase64String(byteArray);
        }
        
        public static string Execute(params string[] input)
        {
            return CallDirect(MethodBase.GetCurrentMethod().DeclaringType, null, input);
        }
    }
}
