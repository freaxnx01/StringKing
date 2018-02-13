using System.Collections.Generic;

namespace StringKing.StringFunctions
{
    public interface IStringFunctionMultiInput : IStringFunction
    {
        string ExecuteFunction(string[] input, Dictionary<string, object> arguments);
    }
}