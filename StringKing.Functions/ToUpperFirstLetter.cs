using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using StringKing.FunctionInterface;

namespace StringKing.Functions
{
    [StringFunction("ToUpperFirstLetter")]
    public class ToUpperFirstLetter : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            List<string> lines = SplitByNewLine(input[0]);
            StringBuilder sb = new StringBuilder();
            foreach (string line in lines)
            {
                char[] chArray = line.ToCharArray();
                chArray[0] = char.ToUpper(chArray[0]);
                sb.AppendLine(new string(chArray));
            }

            return sb.ToString();
        }
    }
}
