﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading;
using StringKing.StringFunctionInterface;

namespace StringKing.StringFunctions
{
    [StringFunction("TitleCase")]
    public class TitleCase : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            string output = string.Empty;
            TextInfo ti = Thread.CurrentThread.CurrentCulture.TextInfo;
            return ti.ToTitleCase(input[0]);
        }
    }
}
