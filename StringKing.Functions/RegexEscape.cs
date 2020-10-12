using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using StringKing.FunctionInterface;

namespace StringKing.Functions
{
    // Escapes a minimal set of characters (\, *, +, ?, |, {, [, (,), ^, $,., #, and white space) by replacing them with their escape codes.
    // This instructs the regular expression engine to interpret these characters literally rather than as metacharacters.

    [StringFunction("RegexEscape")]
    [StringFunctionAlias("Escape")]
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
        
        public static string Execute(params string[] input)
        {
            return CallDirect(MethodBase.GetCurrentMethod().DeclaringType, null, input);
        }
    }
}
