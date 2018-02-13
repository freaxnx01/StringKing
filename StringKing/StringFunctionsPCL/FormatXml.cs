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
    [StringFunction("FormatXml")]
    public class FormatXml : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            XDocument doc = XDocument.Parse(input[0]);
            string indented = doc.ToString();
            return indented;
        }

        public override string GetTestString()
        {
            return "<root><node1>theValue</node1></root>";
        }
    }
}
