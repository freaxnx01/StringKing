﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringKing.StringFunctionInterface;

namespace StringKing.StringFunctionInterface
{
    public class StringFunctionException : System.Exception
    {
        public StringFunctionException(string message) : base(message) {}
    }
}