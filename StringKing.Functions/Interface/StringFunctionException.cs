using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringKing.FunctionInterface
{
    public class StringFunctionException : System.Exception
    {
        public StringFunctionException(string message) : base(message) {}
    }
}
