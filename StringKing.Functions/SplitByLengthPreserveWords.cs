using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using StringKing.FunctionInterface;

namespace StringKing.Functions
{
    [StringFunction("SplitByLengthPreserveWords")]
    public class SplitByLengthPreserveWords : StringFunctionBase
    {
        private const string ARGUMENT_LENGTH = "length";

        public override Dictionary<string, object> GetListOfArgument()
        {
            var listOfArgument = new Dictionary<string, object>();

            StringFunctionArgument arg1 = new StringFunctionArgument(ARGUMENT_LENGTH);
            arg1.DefaultValue = string.Empty;
            listOfArgument.Add(ARGUMENT_LENGTH, arg1);

            return listOfArgument;
        }

        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            int length = 0;
            if (!int.TryParse(GetArgumentValue(arguments, ARGUMENT_LENGTH).ToString(), out length))
            {
                throw new StringFunctionException(string.Format("Argument {0} not numeric.", ARGUMENT_LENGTH));
            }

            List<string> linesOut = new List<string>();

            string[] words = input[0].Split(' ');
            StringBuilder sb = new StringBuilder();
            foreach (string word in words)
            {
                if (sb.Length + word.Length > length)
                {
                    linesOut.Add(sb.ToString());
                    sb.Length = 0;
                }

                sb.Append(word);
                sb.Append(' ');
            }

            linesOut.Add(sb.ToString());

            sb.Length = 0;
            linesOut.ForEach(l => sb.AppendLine(l));

            return sb.ToString();
        }

        public override string GetTestString()
        {
            return GetLoremIpsumString();
        }
    }

}
