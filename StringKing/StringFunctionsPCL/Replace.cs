using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using StringKing.StringFunctionInterface;

namespace StringKing.StringFunctions
{
    [StringFunction("Replace")]
    public class Replace  : StringFunctionBase
    {
        private const string ARGUMENT_OLD_VALUE = "oldvalue";
        private const string ARGUMENT_NEW_VALUE = "newvalue";

        public override Dictionary<string, object> GetListOfArgument()
        {
            Dictionary<string, object> listOfArgument = new Dictionary<string, object>();

            StringFunctionArgument arg1 = new StringFunctionArgument(ARGUMENT_OLD_VALUE);
            arg1.DefaultValue = string.Empty;
            listOfArgument.Add(ARGUMENT_OLD_VALUE, arg1);

            StringFunctionArgument arg2 = new StringFunctionArgument(ARGUMENT_NEW_VALUE);
            arg2.DefaultValue = string.Empty;
            listOfArgument.Add(ARGUMENT_NEW_VALUE, arg2);

            return listOfArgument;
        }

        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            string oldValue = string.Empty;
            string newValue = string.Empty;

            if (GetArgumentValue(arguments, ARGUMENT_OLD_VALUE) != null)
	        {
        		oldValue = GetArgumentValue(arguments, ARGUMENT_OLD_VALUE).ToString();
                oldValue = Regex.Unescape(oldValue);
            }

            if (GetArgumentValue(arguments, ARGUMENT_NEW_VALUE) != null)
	        {
        		newValue = GetArgumentValue(arguments, ARGUMENT_NEW_VALUE).ToString();
                newValue = Regex.Unescape(newValue);
	        }

            return input[0].Replace(oldValue, newValue);
        }
    }
}
