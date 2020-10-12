using System;

namespace StringKing.FunctionInterface
{
    [AttributeUsage(AttributeTargets.Class)]
    public class StringFunctionAlias : Attribute
    {
        private string Alias { get; set; }

        public StringFunctionAlias(string alias)
        {
            Alias = alias;
        }
    }
}
