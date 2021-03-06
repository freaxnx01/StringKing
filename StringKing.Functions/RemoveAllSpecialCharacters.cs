﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using StringKing.FunctionInterface;

namespace StringFunctionsDnpExtensions
{
    [StringFunction("RemoveAllSpecialCharacters")]
    public class RemoveAllSpecialCharacters : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            StringBuilder builder = new StringBuilder();
            foreach (char ch in input[0].Where<char>(delegate(char c)
            {
                if (((c < '0') || (c > '9')) && ((c < 'A') || (c > 'Z')))
                {
                    return (c >= 'a') && (c <= 'z');
                }
                return true;
            }))
            {
                builder.Append(ch);
            }
            return builder.ToString();
        }
        
        public static string Execute(params string[] input)
        {
            return CallDirect(MethodBase.GetCurrentMethod().DeclaringType, null, input);
        }
    }
}
