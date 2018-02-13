using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using StringKing.StringFunctionInterface;

namespace StringFunctionsDnpExtensions
{
    [StringFunction("ToPlural")]
    public class ToPlural : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            List<string> lines = SplitByNewLine(input[0]);
            StringBuilder sb = new StringBuilder();
            foreach (string line in lines)
            {
                sb.AppendLine(ToPluralHelper(line));
            }

            return sb.ToString();
        }

        private string ToPluralHelper(string singular)
        {
            int length = singular.LastIndexOf(" of ");
            if (length > 0)
            {
                return (singular.Substring(0, length) + ToPluralHelper(singular.Remove(0, length)));
            }
            if (singular.EndsWith("sh"))
            {
                return (singular + "es");
            }
            if (singular.EndsWith("ch"))
            {
                return (singular + "es");
            }
            if (singular.EndsWith("us"))
            {
                return (singular + "es");
            }
            if (singular.EndsWith("ss"))
            {
                return (singular + "es");
            }
            if (singular.EndsWith("y"))
            {
                return (singular.Remove(singular.Length - 1, 1) + "ies");
            }
            if (singular.EndsWith("o"))
            {
                return (singular.Remove(singular.Length - 1, 1) + "oes");
            }
            return (singular + "s");
        }
    }
}
