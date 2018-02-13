using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using StringKing.StringFunctionInterface;

namespace StringFunctionsDnpExtensions
{
    [StringFunction("EnsureStartsWith")]
    public class EnsureStartsWith : StringFunctionBase
    {
        private const string ArgumentPrefix = "prefix";

        public override Dictionary<string, object> GetListOfArgument()
        {
            Dictionary<string, object> listOfArgument = new Dictionary<string, object>();

            StringFunctionArgument arg1 = new StringFunctionArgument(ArgumentPrefix);
            arg1.DefaultValue = string.Empty;
            listOfArgument.Add(ArgumentPrefix, arg1);

            return listOfArgument;
        }

        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            string prefix = GetArgumentValue(arguments, ArgumentPrefix).ToString();

            List<string> lines = SplitByNewLine(input[0]);

            StringBuilder sb = new StringBuilder();

            string workLine = string.Empty;

            foreach (string line in lines)
            {
                if (!line.StartsWith(prefix))
                {
                    sb.AppendLine(string.Concat(prefix, line));
                }
                else
                {
                    sb.AppendLine(line);
                }
            }

            return sb.ToString();
        }
    }
}
