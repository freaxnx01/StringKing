using System.Collections.Generic;

namespace StringKing.StringFunctions
{
    public interface IStringFunction
    {
        string ExecuteFunction(string input, Dictionary<string, object> arguments);
        string GetTestString();
    }
}
