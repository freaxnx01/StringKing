using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringKing.StringFunctionInterface;

namespace StringKing.StringFunctions
{
    [StringFunction("HexConverterFrom")]
    public class HexConverterFrom : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            if (input[0].Length % 2 != 0)
            {
                throw new StringFunctionException("Number of characters has to be even.");
            }

            StringBuilder sb = new StringBuilder();

            byte[] byteArray = new byte[input[0].Length / 2];

            int j = 0;

            for (int i = 0; i < input[0].Length; i++)
            {
                if ((i + 1) % 2 == 0)
                {
                    byte value = 0;
                    if (byte.TryParse(input[0].Substring(i - 1, 2), System.Globalization.NumberStyles.HexNumber, null, out value))
                    {
                        byteArray[j] = value;
                        j++;
                    }
                }
            }

            return Encoding.ASCII.GetString(byteArray);
        }
    }
}
