using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using StringKing.FunctionInterface;

namespace StringKing.Functions
{
    [StringFunction("Upper case GUID")]
    public class UpperCaseGuids : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            string pattern = @"(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})";
            Regex regex = new Regex(pattern);
            MatchEvaluator matchEval = new MatchEvaluator(Replacer);
            return regex.Replace(input[0], Replacer);
        }

        private string Replacer(Match match)
        {
            return match.Groups[0].Value.ToUpper();
        }

        public override string GetTestString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 50; i++)
            {
                sb.AppendLine(Guid.NewGuid().ToString().ToLower());
            }

            return sb.ToString();
        }
    }
}
