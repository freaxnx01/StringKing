using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
//using System.Windows.Forms;
using StringKing.FunctionInterface;

namespace StringKing.Functions
{
    [StringFunction("PasteFromClipboard")]
    public class PasteFromClipboard : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            throw new NotImplementedException();
            //return Clipboard.GetText();
        }
        
        public static string Execute(params string[] input)
        {
            return CallDirect(MethodBase.GetCurrentMethod().DeclaringType, null, input);
        }
    }
}
