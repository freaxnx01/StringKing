using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringKing.FunctionInterface
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

        public string TypeAsString
        {
            get
            {
                if (DefaultValue == null)
                {
                    return nameof(String);
                }
                
                var number = 0;
                if (int.TryParse(DefaultValue.ToString(), out number))
                {
                    return nameof(Int32);
                }
                
                return nameof(String);
            }
        }
    }
}
