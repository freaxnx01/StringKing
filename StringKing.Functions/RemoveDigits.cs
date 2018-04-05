using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringKing.FunctionInterface;

namespace StringKing.Functions
{
    [StringFunction("RemoveDigits")]
    public class RemoveDigits : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            char[] charArray = input[0].ToCharArray().Where(c => !char.IsDigit(c)).ToArray();
            return new string(charArray);
        }

        public override string GetTestString()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
