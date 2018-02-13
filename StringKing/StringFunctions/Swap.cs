using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringKing.StringFunctionInterface;

namespace StringKing.StringFunctions
{
    [StringFunction("Swap")]
    public class Swap  : StringFunctionBase
    {
        private const string ARGUMENT_SEPARATOR = "separator";

        private const string TEST_STRING = "a = b\nc=d\ne= f\ng =h\ni j";
        private const string TEST_RESULT = "b = a\nd=c\nf =e\nh= g\ni j";

        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            string splitString = GetArgumentValue(arguments, ARGUMENT_SEPARATOR).ToString();

            List<string> lines = SplitByNewLine(input[0]);

            StringBuilder sb = new StringBuilder();

            foreach (string line in lines)
            {
                string[] splitted = line.Split(new string[] { splitString }, StringSplitOptions.None);
                if (splitted.Length == 2)
                {
                    int trailingSpaces = CountTrailingSpaces(splitted[0]);
                    int leadingSpaces = CountLeadingSpaces(splitted[1]);
                    
                    sb.AppendLine(string.Format("{0}{1}{2}{3}{4}",
                        splitted[1].Trim(), new string(' ', leadingSpaces),
                        splitString, new string(' ', trailingSpaces), splitted[0].Trim()));
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
            Dictionary<string, object> listOfArgument = new Dictionary<string,object>();

            StringFunctionArgument arg1 = new StringFunctionArgument(ARGUMENT_SEPARATOR);
            arg1.DefaultValue = "=";
            
            listOfArgument.Add(ARGUMENT_SEPARATOR, arg1);

            return listOfArgument;
        }

        public override string GetTestString()
        {
            return TEST_STRING.Replace("\n", Environment.NewLine);
        }

        private int CountLeadingSpaces(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return 0;
            }

            string textTrimmed = text.TrimStart(' ');
            return text.Length - textTrimmed.Length;
        }

        private int CountTrailingSpaces(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return 0;
            }

            string textTrimmed = text.TrimEnd(' ');
            return text.Length - textTrimmed.Length;
        }
    }
}
