using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringKing.FunctionInterface;

namespace StringKing.Functions
{
    [StringFunction("SkipEveryNthLine")]
    public class SkipEveryNthLine  : StringFunctionBase
    {
        private const string ARGUMENT_NTH_LINE= "nth line";

        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            int nthLine = 0;

            if (!int.TryParse(GetArgumentValue(arguments, ARGUMENT_NTH_LINE).ToString(), out nthLine))
            {
                throw new StringFunctionException(string.Format("Argument {0} not numeric.", ARGUMENT_NTH_LINE));
            }

            StringBuilder sb = new StringBuilder();
            string[] lines = input[0].Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            for (int i = 0; i < lines.Length; i++)
            {
                if ((i + 1) % nthLine != 0)
                {
                    sb.AppendLine(lines[i]);
                }
            }

            return sb.ToString();
        }

        public override string GetTestString()
        {
            return string.Format("line 1{0}line 2{0}line 3{0}line 4{0}line 5{0}line 6{0}line 7{0}", Environment.NewLine);
        }

        public override Dictionary<string, object> GetListOfArgument()
        {
            Dictionary<string, object> listOfArgument = new Dictionary<string, object>();

            StringFunctionArgument arg1 = new StringFunctionArgument(ARGUMENT_NTH_LINE);
            arg1.DefaultValue = "2";

            listOfArgument.Add(ARGUMENT_NTH_LINE, arg1);

            return listOfArgument;
        }
    }
}
