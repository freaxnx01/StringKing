using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringKing.FunctionInterface;

namespace StringKing.Functions
{
    [StringFunction("ChopAt")]
    public class ChopAt  : StringFunctionBase
    {
        private const string ARGUMENT_CHOP_POSITION = "choppos";
        private const string ARGUMENT_CHOP_LENGTH = "choplen";

        public override Dictionary<string, object> GetListOfArgument()
        {
            Dictionary<string, object> listOfArgument = new Dictionary<string, object>();

            StringFunctionArgument arg1 = new StringFunctionArgument(ARGUMENT_CHOP_POSITION);
            arg1.DefaultValue = "0";
            listOfArgument.Add(ARGUMENT_CHOP_POSITION, arg1);

            StringFunctionArgument arg2 = new StringFunctionArgument(ARGUMENT_CHOP_LENGTH);
            arg2.DefaultValue = string.Empty;
            listOfArgument.Add(ARGUMENT_CHOP_LENGTH, arg2);

            return listOfArgument;
        }

        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            // chopPos 0 = vor erstem Zeichen
            
            int chopPos = 0;
            int chopLen = 0;

            if (!int.TryParse(GetArgumentValue(arguments, ARGUMENT_CHOP_POSITION).ToString(), out chopPos))
            {
                throw new StringFunctionException(string.Format("Argument {0} not numeric.", ARGUMENT_CHOP_POSITION));
            }

            if (!int.TryParse(GetArgumentValue(arguments, ARGUMENT_CHOP_LENGTH).ToString(), out chopLen))
            {
                throw new StringFunctionException(string.Format("Argument {0} not numeric.", ARGUMENT_CHOP_LENGTH));
            }

            List<string> lines = SplitByNewLine(input[0]);

            StringBuilder sb = new StringBuilder();

            string workLine = string.Empty;

            foreach (string line in lines)
            {
                workLine = line;

                if (chopLen > 0)
                {
                    if (chopPos == 0)
                    {
                        workLine = workLine.Substring(chopLen);
                    }
                    else
                    {
                        workLine = string.Format("{0}{1}", workLine.Substring(0, chopPos), workLine.Substring(chopPos + chopLen));
                    }
                }

                sb.AppendLine(workLine);
            }

            return sb.ToString();
        }
    }
}
