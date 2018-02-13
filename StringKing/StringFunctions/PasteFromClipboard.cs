using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StringKing.StringFunctionInterface;

namespace StringKing.StringFunctions
{
    [StringFunction("PasteFromClipboard")]
    public class PasteFromClipboard : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            return Clipboard.GetText();
        }
    }
}
