using System.Collections.Generic;

namespace StringKing.StringFunctions
{
    public interface IStringFunctionWithArguments : IStringFunction
    {
        Dictionary<string, object> GetListOfArgument();
    }
}
