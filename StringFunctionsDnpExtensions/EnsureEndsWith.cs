using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using StringKing.StringFunctionInterface;

namespace StringFunctionsDnpExtensions
{
    [StringFunction("EnsureEndsWith")]
    public class EnsureEndsWith : StringFunctionBase
    {
        private const string ArgumentSuffix = "suffix";

        public override Dictionary<string, object> GetListOfArgument()
        {
            Dictionary<string, object> listOfArgument = new Dictionary<string, object>();

            StringFunctionArgument arg1 = new StringFunctionArgument(ArgumentSuffix);
            arg1.DefaultValue = string.Empty;
            listOfArgument.Add(ArgumentSuffix, arg1);

            return listOfArgument;
        }

        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            string suffix = GetArgumentValue(arguments, ArgumentSuffix).ToString();

            List<string> lines = SplitByNewLine(input[0]);

            StringBuilder sb = new StringBuilder();

            string workLine = string.Empty;

            foreach (string line in lines)
            {
                if (!line.EndsWith(suffix))
                {
                    sb.AppendLine(string.Concat(line, suffix));
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
