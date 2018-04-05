using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Windows.Forms;
using StringKing.FunctionInterface;

namespace StringKing.Functions
{
    [StringFunction("CopyToClipboard")]
    public class CopyToClipboard : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            throw new NotImplementedException();
            //Clipboard.SetText(input[0]);
        }
    }
}
