using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringKing.StringFunctionInterface;

namespace StringKing.StringFunctions
{
    [StringFunction("RemoveLinesStartingWith")]
    public class RemoveLinesStartingWith : StringFunctionBase
    {
        private const string ArgumentStartingWith = "startingwith";

        public override Dictionary<string, object> GetListOfArgument()
        {
            Dictionary<string, object> listOfArgument = new Dictionary<string, object>();

            StringFunctionArgument arg1 = new StringFunctionArgument(ArgumentStartingWith);
            arg1.DefaultValue = string.Empty;
            listOfArgument.Add(ArgumentStartingWith, arg1);

            return listOfArgument;
        }

        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            string startingWith = GetArgumentValue(arguments, ArgumentStartingWith).ToString();
            
            StringBuilder sb = new StringBuilder();
            string[] lines = input[0].Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            foreach (string line in lines)
            {
                if (!line.StartsWith(startingWith))
                {
                    sb.AppendLine(line);
                }
            }
            
            return sb.ToString();
        }

        public override string GetTestString()
        {
            return string.Format("Start: line 1{0}line 2{0}line 3{0}line 4{0}{0}Start: line 3", Environment.NewLine);
        }
    }
}
