using System.Collections.Generic;

namespace StringKing.StringFunctionInterface
{
    public interface IStringFunction
    {
        string ExecuteFunction(string[] input, Dictionary<string, object> arguments);
        Dictionary<string, object> GetListOfArgument();
        string GetTestString();
        string GetDisplayName();
        string GetCallAsString(Dictionary<string, object> arguments);
    }
}
