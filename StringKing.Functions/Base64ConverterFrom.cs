using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringKing.FunctionInterface;

namespace StringKing.Functions
{
    [StringFunction("Base64ConverterFrom")]
    public class Base64ConverterFrom : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            byte[] byteArray = Convert.FromBase64String(input[0]);
            return Encoding.Default.GetString(byteArray);
        }
    }
}
