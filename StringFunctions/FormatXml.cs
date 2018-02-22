﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using StringKing.StringFunctionInterface;

namespace StringKing.StringFunctions
{
    [StringFunction("FormatXml")]
    public class FormatXml : StringFunctionBase
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
            return "<root><node1>theValue</node1></root>";
        }
    }
}