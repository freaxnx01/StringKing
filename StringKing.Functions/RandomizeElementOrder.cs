using System;
using System.Collections.Generic;

using StringKing.FunctionInterface;

namespace StringKing.Functions
{
    [StringFunction("RandomizeElementOrder")]
    public class RandomizeElementOrder : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            List<string> copyOfListOfString = SplitByNewLine(input[0]);
            List<string> newList = new List<string>();
            while (copyOfListOfString.Count > 0)
            {
                int randomIndex = new Random().Next(copyOfListOfString.Count - 1);
                newList.Add(copyOfListOfString[randomIndex]);
                copyOfListOfString.RemoveAt(randomIndex);
            }

            return ConvertListToString(newList);
        }
    }
}
