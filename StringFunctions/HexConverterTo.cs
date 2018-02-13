﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringKing.StringFunctionInterface;

namespace StringKing.StringFunctions
{
    [StringFunction("HexConverterTo")]
    public class HexConverterTo : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char character in input[0])
            {
                sb.Append(string.Format("{0:x2}", Convert.ToInt32(character)));
            }
            
            return sb.ToString();
        }
    }
}
