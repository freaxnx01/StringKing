using System;

namespace StringKing.StringFunctions
{
    [AttributeUsage(AttributeTargets.Class)]
    public class StringFunctionAttribute : Attribute
    {
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Example { get; set; }

        public StringFunctionAttribute(string displayName) : this(displayName, string.Empty) {}

        public StringFunctionAttribute(string displayName, string description) : this(displayName, description, string.Empty) {}

        public StringFunctionAttribute(string displayName, string description, string example)
        {
            DisplayName = displayName;
            Description = description;
            Example = example;
        }
    }
}
