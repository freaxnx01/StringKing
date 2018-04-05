using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using StringKing.FunctionInterface;

namespace StringFunctionsDnpExtensions
{
    [StringFunction("TrimToMaxLength")]
    public class TrimToMaxLength : StringFunctionBase
    {
        private const string ARGUMENT_MAX_LENGTH = "maxLength";

        public override Dictionary<string, object> GetListOfArgument()
        {
            Dictionary<string, object> listOfArgument = new Dictionary<string, object>();

            StringFunctionArgument arg1 = new StringFunctionArgument(ARGUMENT_MAX_LENGTH);
            arg1.DefaultValue = "20";
            listOfArgument.Add(ARGUMENT_MAX_LENGTH, arg1);

            return listOfArgument;
        }

        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            int maxLength = 0;

            if (!int.TryParse(GetArgumentValue(arguments, ARGUMENT_MAX_LENGTH).ToString(), out maxLength))
            {
                throw new StringFunctionException(string.Format("Argument {0} not numeric.", ARGUMENT_MAX_LENGTH));
            }

            List<string> lines = SplitByNewLine(input[0]);
            StringBuilder sb = new StringBuilder();
            foreach (string line in lines)
            {
                if ((line != null) && (line.Length > maxLength))
                {
                    sb.AppendLine(line.Substring(0, maxLength));
                }
            }

            return sb.ToString();
        }
    }
}
