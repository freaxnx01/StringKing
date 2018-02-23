﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using StringKing.StringFunctionInterface;

namespace StringFunctionsDnpExtensions
{
    [StringFunction("ExtractDigits")]
    public class ExtractDigits : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            return string.Join(null, Regex.Split(input[0], @"[^\d]"));
        }
    }
}