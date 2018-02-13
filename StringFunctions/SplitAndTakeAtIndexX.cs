using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using StringKing.StringFunctionInterface;

namespace StringKing.StringFunctions
{
    [StringFunction("SplitAndTakeAtIndexX")]
    public class SplitAndTakeAtIndexX : StringFunctionBase
    {
        private const string ARGUMENT_SPLIT_CHAR = "splitchar";
        private const string ARGUMENT_INDEX = "index";

        public override Dictionary<string, object> GetListOfArgument()
        {
            var listOfArgument = new Dictionary<string, object>();

            StringFunctionArgument arg1 = new StringFunctionArgument(ARGUMENT_SPLIT_CHAR);
            arg1.DefaultValue = string.Empty;
            listOfArgument.Add(ARGUMENT_SPLIT_CHAR, arg1);

            StringFunctionArgument arg2 = new StringFunctionArgument(ARGUMENT_INDEX);
            arg2.DefaultValue = "-1";
            listOfArgument.Add(ARGUMENT_INDEX, arg2);

            return listOfArgument;
        }

        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            char splitChar = ' ';
            if (GetArgumentValue(arguments, ARGUMENT_SPLIT_CHAR) != null)
            {
                splitChar = GetArgumentValue(arguments, ARGUMENT_SPLIT_CHAR).ToString().ToCharArray()[0];
            }

            int index = 0;
            if (!int.TryParse(GetArgumentValue(arguments, ARGUMENT_INDEX).ToString(), out index))
            {
                throw new StringFunctionException(string.Format("Argument {0} not numeric.", ARGUMENT_INDEX));
            }

            List<string> lines = SplitByNewLine(input[0]);
            StringBuilder sb = new StringBuilder();
            foreach (string line in lines)
            {
                string[] splitted = line.Split(splitChar);
                int takeIndex = index;
                if (takeIndex == -1)
                {
                    takeIndex = splitted.Length - 1;
                }
                sb.AppendLine(splitted[takeIndex]);
            }

            return sb.ToString();
        }

        public override string GetTestString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"\\servser\share\folder\file.xyz");
            sb.AppendLine(@"\\servser\share\folder\subfolder\file2.xyz");
            sb.AppendLine(@"c:\temp\datei.dat");
            sb.AppendLine(@"c:\rootfile.fil");
            return sb.ToString();
        }
    }
}
