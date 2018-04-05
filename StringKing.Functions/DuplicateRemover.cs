using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringKing.FunctionInterface;

namespace StringKing.Functions
{
    [StringFunction("DuplicateRemover", "Removes duplicates")]
    public class DuplicateRemover : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            string output = string.Empty;
            List<string> lines = SplitByNewLine(input[0]);
            List<string> linesWithoutDuplicates = lines.Distinct().ToList();
            return ConvertListToString(linesWithoutDuplicates);
        }

        public override string GetTestString()
        {
            return GetTestData() + '\n' + GetTestData();
        }
    }
}
