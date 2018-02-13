using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using StringKing.StringFunctionInterface;
using System.Xml.Linq;

namespace StringKing.StringFunctions
{
    [StringFunction("UnformatXml")]
    public class UnformatXml : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            XDocument xdoc = XDocument.Parse(input[0]);

            string data = string.Empty;
            using (MemoryStream mem = new MemoryStream())
            {
                xdoc.Save(mem, SaveOptions.DisableFormatting);
                data = Encoding.UTF8.GetString(mem.ToArray(), 0, mem.ToArray().Length);
            }

            return data;
        }

        public override string GetTestString()
        {
            return "<root>\r\n\t<node1>theValue</node1>\r\n</root>";
        }
    }
}
