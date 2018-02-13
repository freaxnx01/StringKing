using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringKing.StringFunctionInterface;

namespace StringKing.StringFunctions
{
    [StringFunction("Lower case")]
    public class LowerCase : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            return input[0].ToLower();
        }
    }
}
