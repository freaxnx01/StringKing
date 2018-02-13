using System;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;

using StringKing.StringFunctionInterface;
using System.Xml;

namespace StringKing.StringFunctions
{
    [StringFunction("Remove unneeded closing XML Tag")]
    public class RemoveUnneededClosingXmlTag : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            //TODO PCL
            throw new NotImplementedException("PCL");

            //XmlDocument xml = new XmlDocument();
            //xml.LoadXml(input[0]);

            //foreach (XmlElement element in xml.SelectNodes("//*[. = '' and count(*) = 0]"))
            //{
            //    element.IsEmpty = true;
            //}

            ////PrettifyXml prettifyXml = new PrettifyXml();
            ////prettifyXml.ExecuteFunction(new string[] { xml.InnerXml }, null);

            //return xml.InnerXml;
        }

        public override string GetTestString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<root>");
            sb.AppendLine("\t<sub>");

            int i = 0;
            foreach (string testString in base.GetTestString().Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
            {
                if (i % 2 == 0)
                {
                    sb.AppendLine(string.Format("\t\t<process name=\"{0}\">", testString));
                    sb.AppendLine("</process>");
                }
                else
                {
                    sb.AppendLine(string.Format("\t\t<process>{0}</process>", testString));
                }

                i++;
            }

            sb.AppendLine("\t</sub>");
            sb.AppendLine("</root>");

            return sb.ToString();
        }
    }
}
