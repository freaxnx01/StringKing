using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringKing.FunctionInterface;

namespace StringKing.Functions
{
    [StringFunction("GuidGenerator")]
    public class GuidGenerator  : StringFunctionBase
    {
        private const string ARGUMENT_NUMBER_OF = "numberof";

        public override Dictionary<string, object> GetListOfArgument()
        {
            Dictionary<string, object> listOfArgument = new Dictionary<string, object>();

            StringFunctionArgument arg1 = new StringFunctionArgument(ARGUMENT_NUMBER_OF);
            arg1.DefaultValue = "1";
            listOfArgument.Add(ARGUMENT_NUMBER_OF, arg1);

            return listOfArgument;
        }

        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            int numberOf = 0;

            if (!int.TryParse(GetArgumentValue(arguments, ARGUMENT_NUMBER_OF).ToString(), out numberOf))
            {
                throw new StringFunctionException(string.Format("Argument {0} not numeric.", ARGUMENT_NUMBER_OF));
            }

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < numberOf; i++)
            {
                sb.AppendLine(Guid.NewGuid().ToString());
            }

            return sb.ToString();
        }

        public override string GetTestString()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
