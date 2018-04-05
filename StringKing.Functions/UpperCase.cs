using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringKing.FunctionInterface;

namespace StringKing.Functions
{
    [StringFunction("Upper case")]
    public class UpperCase : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            return input[0].ToUpper();
        }
    }
}
