using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringKing.StringFunctionInterface;
using System.Xml;
using System.IO;

namespace StringKing.StringFunctions
{
    [StringFunction("FileDescriptionTableCsvToXml")]
    public class FileDescriptionTableCsvToXml : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            List<string> lines = SplitByNewLine(input[0]);

            MemoryStream ms = new MemoryStream();

            string xmlString = Encoding.UTF8.GetString(ms.ToArray());

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = new UTF8Encoding(false);
            settings.ConformanceLevel = ConformanceLevel.Document;
            settings.Indent = true;

            XmlWriter writer = XmlWriter.Create(ms, settings);
            writer.WriteStartDocument();
            writer.WriteStartElement("FileImportConversions");

            string fileType = string.Empty;

            foreach (string line in lines.Where(l => !string.IsNullOrEmpty(l)))
            {
                if (line.StartsWith(" ") || line.StartsWith("\t"))
                {
                    WriteHeader(writer, line);
                }
                else
                {
                    if (!string.IsNullOrEmpty(fileType))
                    {
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                    }
                    fileType = line;

                    writer.WriteStartElement("FileImportConversion");
                    writer.WriteAttributeString("name", fileType);
                    writer.WriteAttributeString("type", "CsvToXml");
                    writer.WriteAttributeString("delimiter", ";");
                    writer.WriteStartElement("Headers");
                }
            }

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();

            return Encoding.UTF8.GetString(ms.ToArray());
        }

        private void WriteHeader(XmlWriter writer, string header)
        {
            string name = PurifyName(header);
            writer.WriteStartElement("Header");
            writer.WriteAttributeString("name", name);
            writer.WriteEndElement();
        }

        private string PurifyName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return string.Empty;
            }

            name = name.Replace(" ", string.Empty).Replace("ä", "ae").Replace("ö", "oe").Replace("ü", "ue");

            StringBuilder sb = new StringBuilder();
            foreach (char character in name.ToCharArray())
            {
                if (char.IsLetterOrDigit(character))
                {
                    sb.Append(character);
                }
            }

            return sb.ToString();
        }

        public override string GetTestString()
        {
            return @"HHDR01
    RECORDART
    DOKUMENT-ID
    DOKUMENT-ART
    DOKUMENT-FUNKTION
    DOKUMENT-ANTWORT

HDAT01
    RECORDART
    DOKUMENT-ID
    DATUM-QUAL
    DATUM
    DATUM-FORMAT

HTXT01
    RECORDART
    DOKUMENT-ID
    FREIER-TEXT-QUAL
    FREIER-TEXT-1
    FREIER-TEXT-2
    FREIER-TEXT-3
    FREIER-TEXT-4
    FREIER-TEXT-5
    FREIER-TEXT-CODE";
        }
    }
}
