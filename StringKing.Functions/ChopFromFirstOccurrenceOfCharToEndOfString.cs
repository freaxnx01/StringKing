using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using StringKing.FunctionInterface;

namespace StringKing.Functions
{
    [StringFunction("ChopFromFirstOccurrenceOfCharToEndOfString")]
    public class ChopFromFirstOccurrenceOfCharToEndOfString : StringFunctionBase
    {
        private const string ARGUMENT_FIND_CHAR = "findchar";

        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            char findChar = ' ';
            if (GetArgumentValue(arguments, ARGUMENT_FIND_CHAR) != null)
            {
                findChar = GetArgumentValue(arguments, ARGUMENT_FIND_CHAR).ToString().ToCharArray()[0];
            }

            List<string> lines = SplitByNewLine(input[0]);
            StringBuilder sb = new StringBuilder();
            foreach (string line in lines)
            {
                int findCharIndex = line.IndexOf(findChar);
                if (findCharIndex > -1)
                {
                    sb.AppendLine(line.Substring(0, findCharIndex));
                }
                else
                {
                    sb.AppendLine(line);
                }
            }

            return sb.ToString();
        }

        public override Dictionary<string, object> GetListOfArgument()
        {
            var listOfArgument = new Dictionary<string, object>();

            StringFunctionArgument arg1 = new StringFunctionArgument(ARGUMENT_FIND_CHAR);
            arg1.DefaultValue = string.Empty;
            listOfArgument.Add(ARGUMENT_FIND_CHAR, arg1);

            return listOfArgument;
        }











        public override string GetTestString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Common.dll\" Source=\"../ReferencedAssemblies/Common.dll\"/>");
            sb.AppendLine("Library.dll\" Source=\"../ReferencedAssemblies/Library.dll\"/>");
            return sb.ToString();
        }
    }
}
