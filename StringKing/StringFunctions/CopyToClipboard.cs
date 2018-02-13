using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StringKing.StringFunctionInterface;

namespace StringKing.StringFunctions
{
    [StringFunction("CopyToClipboard")]
    public class CopyToClipboard : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            Clipboard.SetText(input[0]);
            return string.Empty;
        }
    }
}
