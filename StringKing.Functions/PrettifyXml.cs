using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Reflection;
using StringKing.FunctionInterface;

namespace StringKing.Functions
{
    [StringFunction("PrettifyXml")]
    public class PrettifyXml : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(input[0]);

            string data = string.Empty;

            using (StringWriter sw = new StringWriter())
            {
                using (XmlTextWriter writer = new XmlTextWriter(sw))
                {
                    writer.Formatting = System.Xml.Formatting.Indented;
                    doc.WriteTo(writer);
                    data = sw.ToString();
                }
            }

            return data;
        }

        public override string GetTestString()
        {
            return "<root><record><field>text</field></record></root>";
        }
        
        public static string Execute(params string[] input)
        {
            return CallDirect(MethodBase.GetCurrentMethod().DeclaringType, null, input);
        }
    }
}
