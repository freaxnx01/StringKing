using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringKing.StringFunctionInterface
{
    public class StringFunctionArgument
    {
        public StringFunctionArgument(string name) : this(name, null) {}

        public StringFunctionArgument(string name, object defaultValue)
        {
            Name = name;
            DefaultValue = defaultValue;
        }

        public string Name { get; set; }
        public object Value { get; set; }
        public bool Optional { get; set; }
        public object DefaultValue { get; set; }
        public object MinValue { get; set; }
        public object MaxValue { get; set; }
    }
}
