using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringKing.StringFunctionInterface;
using System.Xml;
using System.IO;

namespace StringKing.StringFunctions
{
    [StringFunction("FileDescriptionTableFixedLengthToXml")]
    public class FileDescriptionTableFixedLengthToXml : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            //TODO PCL
            throw new NotImplementedException("PCL");

            //List<string> lines = SplitByNewLine(input[0]);

            //MemoryStream ms = new MemoryStream();

            //string xmlString = Encoding.UTF8.GetString(ms.ToArray(), 0, ms.ToArray().Length);

            //XmlWriterSettings settings = new XmlWriterSettings();
            //settings.Encoding = new UTF8Encoding(false);
            //settings.ConformanceLevel = ConformanceLevel.Document;
            //settings.Indent = true;

            //XmlWriter writer = XmlWriter.Create(ms, settings);
            //writer.WriteStartDocument();
            //writer.WriteStartElement("FileImportConversions");

            //string fileType = string.Empty;

            //foreach (string line in lines.Where(l => !string.IsNullOrEmpty(l)))
            //{
            //    string[] splitted = line.Split(new char[] { '\t' });

            //    if (splitted.Length == 1)
            //    {
            //        if (!string.IsNullOrEmpty(fileType))
            //        {
            //            writer.WriteEndElement();
            //            writer.WriteEndElement();
            //        }
            //        fileType = splitted[0];

            //        writer.WriteStartElement("FileImportConversion");
            //        writer.WriteAttributeString("name", fileType);
            //        writer.WriteAttributeString("type", "FixedLengthToXml");
            //        writer.WriteStartElement("Headers");
            //    }
                
            //    if (splitted.Length >= 3)
            //    {
            //        WriteHeader(writer, splitted);
            //    }
            //}

            //writer.WriteEndElement();
            //writer.WriteEndDocument();
            //writer.Close();

            //return Encoding.UTF8.GetString(ms.ToArray());
        }

        private void WriteHeader(XmlWriter writer, string[] splitted)
        {
            string name = PurifyName(splitted[0]);
            string sampleData = splitted[1];
            string length = splitted[2];

            string[] splittedLength = length.Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            if (splittedLength.Length == 2)
            {
                string dataType = splittedLength[0];

                string size = splittedLength[1];
                string numberOfDigitsAfterDecimalPoint = string.Empty;

                if (dataType == "DEZ")
                {
                    string[] splittedDecimal = size.Split('.');
                    if (splittedDecimal.Length == 2)
                    {
                        size = splittedDecimal[0];
                        numberOfDigitsAfterDecimalPoint = splittedDecimal[1];
                    }
                }

                writer.WriteStartElement("Header");
                writer.WriteAttributeString("name", name);
                writer.WriteElementString("FixValue", string.Empty);
                writer.WriteElementString("SampleValue", sampleData);
                writer.WriteElementString("DataType", dataType);
                writer.WriteElementString("Size", size);
                writer.WriteElementString("NumberOfDigitsAfterDecimalPoint", numberOfDigitsAfterDecimalPoint);
                writer.WriteEndElement();
            }
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
            return @"BERE

Auftragstyp	EG	CHAR(2)			
Satztyp	1	NUM(1)			
Mandant	GRUE	CHAR(4)			
Bestellnummer		CHAR(30)			
Artikel Position		NUM(9)			
Artikel Nummer		CHAR(20)			
Einheit		CHAR(10)			
Menge		DEZ(10.2)			
Charge Ja/Nein		CHAR(1)			
Charge		CHAR(20)			
MHD		DATE			
Gewicht		DEZ(10.2)			
SSCC		CHAR(18)			
GTIN 		CHAR(14)			
Letzte Rückmeldung		CHAR(1)			

PARE

Auftragstyp	AG	CHAR(2)			
Satztyp	1	NUM(1)			
Mandant	GRUE	CHAR(4)			
PA Nummer		CHAR(30)			
PA Kurz Bezeichnung		CHAR(22)			
Doc Typ	PA	CHAR(2)			
Produktionsdatum Plan Start		DATE			
Positionsnummer		NUM(9)			
Artikel Nummer		CHAR(20)			
Charge Ja/Nein		CHAR(1)			
Charge		CHAR(20)			
Menge		DEZ(10.2)			
SSCC		CHAR(18)			
GTIN 		CHAR(14)			

ABRE

Auftragstyp	AG	CHAR(2)			
Satztyp	1	NUM(1)			
Mandant	GRUE	CHAR(4)			
AB Nummer		CHAR(18)			
Kunden Name		CHAR(40)			
Lieferdatum		DATE			
Positionsnummer		NUM(9)			
Artikel B Nummer		CHAR(20)			
Artikel Nummer		CHAR(20)			
Artikel Kurz Bezeichnung		CHAR(40)			
Charge Ja/Nein		CHAR(1)			
Charge		CHAR(20)			
Menge		DEZ(10.2)			
SSCC		CHAR(18)			
GTIN 		CHAR(14)			";
        }
    }
}
