using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringKing.StringFunctionInterface;
using System.Text.RegularExpressions;

namespace StringKing.StringFunctions
{
    [StringFunction("AutoIncrementNumber")]
    public class AutoIncrementNumber : StringFunctionBase
    {
        private const string ArgumentStep = "step";
        private const string ArgumentNoOfIncrements = "noofincrements";

        private List<NumberMatch> numbers = new List<NumberMatch>();
        private int matchIndex = 0;
        private int step = 0;

        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            int noOfIncrements = 0;

            if (!int.TryParse(GetArgumentValue(arguments, ArgumentStep).ToString(), out step))
            {
                throw new StringFunctionException(string.Format("Argument {0} not numeric.", ArgumentStep));
            }

            if (!int.TryParse(GetArgumentValue(arguments, ArgumentNoOfIncrements).ToString(), out noOfIncrements))
            {
                throw new StringFunctionException(string.Format("Argument {0} not numeric.", ArgumentNoOfIncrements));
            }

            List<string> lines = SplitByNewLine(input[0]);
            string inputLine = lines[0];

            Regex regex = new Regex(@"(\d+)");
            foreach (Match match in regex.Matches(input[0]))
            {
                int number = 0;
                if (int.TryParse(match.Value, out number))
                {
                    numbers.Add(new NumberMatch() { StartingNumber = number, Position = match.Index, Length = match.Length, CurrentValue = number });
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(inputLine);
            for (int i = 0; i < noOfIncrements; i++)
            {
                matchIndex = 0;
                string line = inputLine;

                MatchEvaluator matchEval = new MatchEvaluator(NumberReplacer);
                line = regex.Replace(line, NumberReplacer);

                sb.AppendLine(line);
            }

            return sb.ToString().Trim();
        }

        private string NumberReplacer(Match match)
        {
            numbers[matchIndex].CurrentValue += step;
            string newValue = numbers[matchIndex].CurrentValue.ToString();
            matchIndex++;
            return newValue;
        }

        public override Dictionary<string, object> GetListOfArgument()
        {
            Dictionary<string, object> listOfArgument = new Dictionary<string, object>();

            StringFunctionArgument arg1 = new StringFunctionArgument(ArgumentStep);
            arg1.DefaultValue = 1;
            listOfArgument.Add(ArgumentStep, arg1);

            StringFunctionArgument arg2 = new StringFunctionArgument(ArgumentNoOfIncrements);
            arg2.DefaultValue = 10;
            listOfArgument.Add(ArgumentNoOfIncrements, arg2);

            return listOfArgument;
        }

        public override string GetTestString()
        {
            return "<Frei1 elementNameInXml='Frei1' type='string' headerText='' width='' readOnly='' index=''/>".Replace("'", "\"");
        }

        private class NumberMatch
        {
            public int StartingNumber { get; set; }
            public int Position { get; set; }
            public int Length { get; set; }
            public int CurrentValue { get; set; }
        }
    }
}
