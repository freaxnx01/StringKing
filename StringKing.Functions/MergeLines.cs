using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using StringKing.FunctionInterface;

namespace StringKing.Functions
{
    [StringFunction("MergeLines")]
    public class MergeLines  : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            if (input == null ||input.Length == 0)
            {
                return string.Empty;
            }

            bool preserveEmptyLines = true;
            var inputs = new List<List<string>>();
            for (int i = 0; i < input.Length; i++)
            {
                inputs.Add(SplitByNewLine(input[i], preserveEmptyLines));
            }

            for (int i = 1; i < inputs.Count; i++)
            {
                for (int l = 0; l < inputs[0].Count; l++)
                {
                    if (l < inputs[i].Count)
                    {
                        inputs[0][l] += inputs[i][l];
                    }
                }
            }

            return ConvertListToString(inputs[0]);
        }
    }
}