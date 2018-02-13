using StringKing.StringFunctionInterface;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StringKing.StringFunctions
{
    [StringFunction("RegexReplace")]
    public class RegexReplace : StringFunctionBase
    {
        private const string ArgumentRegexPattern = "regexpattern";
        private const string ArgumentReplacement = "replacement ";

        public override Dictionary<string, object> GetListOfArgument()
        {
            Dictionary<string, object> listOfArgument = new Dictionary<string, object>();

            StringFunctionArgument arg1 = new StringFunctionArgument(ArgumentRegexPattern);
            arg1.DefaultValue = "[^a-zA-Z0-9_.]";
            listOfArgument.Add(ArgumentRegexPattern, arg1);

            StringFunctionArgument arg2 = new StringFunctionArgument(ArgumentReplacement);
            arg2.DefaultValue = "_";
            listOfArgument.Add(ArgumentReplacement, arg2);

            return listOfArgument;
        }

        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            string regexPattern = string.Empty;
            string replacement = string.Empty;

            if (GetArgumentValue(arguments, ArgumentRegexPattern) != null)
            {
                regexPattern = GetArgumentValue(arguments, ArgumentRegexPattern).ToString();
                regexPattern = Regex.Unescape(regexPattern);
            }

            if (GetArgumentValue(arguments, ArgumentReplacement) != null)
            {
                replacement = GetArgumentValue(arguments, ArgumentReplacement).ToString();
                replacement = Regex.Unescape(replacement);
            }

            return Regex.Replace(input[0], regexPattern, replacement);
        }
    }
}
