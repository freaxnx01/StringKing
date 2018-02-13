using System.Collections.Generic;
using System.Text.RegularExpressions;
using StringKing.StringFunctionInterface;

namespace StringKing.StringFunctions
{
    // Escapes a minimal set of characters (\, *, +, ?, |, {, [, (,), ^, $,., #, and white space) by replacing them with their escape codes. This instructs the regular expression engine to interpret these characters literally rather than as metacharacters.

    [StringFunction("RegexEscape")]
    public class RegexEscape : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            return Regex.Escape(input[0]);
        }

        public override string GetTestString()
        {
            return @"\, *, +, ?, |, {, [, (,), ^, $,., #";
        }
    }
}
