using System;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using StringKing.StringFunctionInterface;

namespace StringKing.StringFunctions
{
    [StringFunction("ExtractGuids")]
    public class ExtractGuids : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            string pattern = @"(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})";
            Regex regex = new Regex(pattern);
            MatchCollection matchCollection = regex.Matches(input[0]);
            
            StringBuilder sb = new StringBuilder();
            foreach (Match match in matchCollection)
            {
                sb.AppendLine(match.Groups[0].Value);
            }

            return sb.ToString();
        }

        public override string GetTestString()
        {
            //TODO PCL
            throw new NotImplementedException("PCL");

            //StringBuilder sb = new StringBuilder();
            //foreach (Process proc in Process.GetProcesses())
            //{
            //    sb.Append(proc.ProcessName);
            //    sb.Append(" ");
            //    sb.Append("{" + Guid.NewGuid().ToString() + "}");
            //    sb.Append(" ");
            //}
            //return sb.ToString().TrimEnd();
        }
    }
}
