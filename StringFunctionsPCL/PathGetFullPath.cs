﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringKing.StringFunctionInterface;

namespace StringKing.StringFunctions
{
    [StringFunction("PathGetFullPath", "Returns the absolute path for the specified path string.")]
    public class PathGetFullPath : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            //TODO PCL
            throw new NotImplementedException("PCL");

            //StringBuilder sb = new StringBuilder();

            //List<string> lines = SplitByNewLine(input[0]);
            
            //foreach (string line in lines)
            //{
            //    sb.AppendLine(Path.GetFullPath(line));
            //}
            
            //return sb.ToString();
        }

        public override string GetTestString()
        {
            return GetPathTestData();
        }
    }
}