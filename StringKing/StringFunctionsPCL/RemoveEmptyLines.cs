﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringKing.StringFunctionInterface;

namespace StringKing.StringFunctions
{
    [StringFunction("RemoveEmptyLines")]
    public class RemoveEmptyLines : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            StringBuilder sb = new StringBuilder();

            string[] lines = input[0].Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                sb.AppendLine(line);
            }

            return sb.ToString();
        }

        public override string GetTestString()
        {
            return string.Format("line 1{0}{0}{0}line 2{0}{0}line 3", Environment.NewLine);
        }
    }
}
