using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringKing.FunctionInterface;

namespace StringKing.Functions
{
    [StringFunction("PathChangeExtension", "Changes the extension of a path string.")]
    public class PathChangeExtension  : StringFunctionBase
    {
        private const string ARGUMENT_NEW_EXTENSION = "newextension";

        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            List<string> lines = SplitByNewLine(input[0]);

            StringBuilder sb = new StringBuilder();

            string newExtension = GetArgumentValue(arguments, ARGUMENT_NEW_EXTENSION).ToString();

            foreach (string line in lines)
            {
                sb.AppendLine(Path.ChangeExtension(line, newExtension));
            }

            return sb.ToString();
        }

        public override string GetTestString()
        {
            return GetPathTestData();
        }

        public override Dictionary<string, object> GetListOfArgument()
        {
            Dictionary<string, object> listOfArgument = new Dictionary<string, object>();

            StringFunctionArgument arg1 = new StringFunctionArgument(ARGUMENT_NEW_EXTENSION);
            arg1.DefaultValue = string.Empty;

            listOfArgument.Add(ARGUMENT_NEW_EXTENSION, arg1);

            return listOfArgument;
        }
    }
}
