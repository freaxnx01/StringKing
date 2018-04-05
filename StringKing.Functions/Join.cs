using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringKing.FunctionInterface;

namespace StringKing.Functions
{
    [StringFunction("Join")]
    public class Join  : StringFunctionBase
    {
        private const string ARGUMENT_SEPARATOR = "separator";

        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            string separatorString = GetArgumentValue(arguments, ARGUMENT_SEPARATOR).ToString();
            return string.Join(separatorString, input[0].Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));
        }

        public override string GetTestString()
        {
            return string.Format("line 1{0}line 2", Environment.NewLine);
        }

        public override Dictionary<string, object> GetListOfArgument()
        {
            Dictionary<string, object> listOfArgument = new Dictionary<string, object>();

            StringFunctionArgument arg1 = new StringFunctionArgument(ARGUMENT_SEPARATOR);
            arg1.DefaultValue = ",";

            listOfArgument.Add(ARGUMENT_SEPARATOR, arg1);

            return listOfArgument;
        }
    }
}
