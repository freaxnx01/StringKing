using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringKing.StringFunctions
{
    public class StringFunctionException : ApplicationException
    {
        public StringFunctionException(string message) : base(message) {}
    }
}
