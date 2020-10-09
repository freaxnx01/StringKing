using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using StringKing.FunctionInterface;

namespace StringKing.Functions
{
    [StringFunction("RemoveLineBreaks")]
    public class RemoveLineBreaks : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            return input[0].Replace(Environment.NewLine, string.Empty);
        }

        public override string GetTestString()
        {
            return string.Format("line 1{0}{0}{0}line 2{0}{0}line 3", Environment.NewLine);
        }
        
        public static string Execute(params string[] input)
        {
            return CallDirect(MethodBase.GetCurrentMethod().DeclaringType, null, input);
        }
    }
}
