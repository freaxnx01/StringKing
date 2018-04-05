using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringKing.FunctionInterface;

namespace StringKing.Functions
{
    [StringFunction("DuplicateFinder", "Find duplicates")]
    public class DuplicateFinder : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            List<string> lines = SplitByNewLine(input[0]);

            HashSet<string> hashSet = new HashSet<string>();

            List<string> duplicates = new List<string>();

            foreach (string line in lines)
            {
                if (!hashSet.Add(line))
                {
                    duplicates.Add(line);
                }
            }

            return ConvertListToString(duplicates);
        }

        public override string GetTestString()
        {
            return "ZeileA\nZeileB\nZeileC\nZeileA\nZeileb\nZeileD".Replace("\n", Environment.NewLine);
        }
    }
}
