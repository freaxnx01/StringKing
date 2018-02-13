using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace StringKingProcessor
{
    public class Macro
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Recorded { get; set; }
        public string SampleInput { get; set; }
        public string SampleOutput { get; set; }
        public List<string> Commands { get; set; }

        public Macro()
        {
            Commands = new List<string>();
        }

        public static Macro Load(string path)
        {
            XmlSerializer xmlSer = new XmlSerializer(typeof(Macro));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                return (Macro)xmlSer.Deserialize(fs);
            }
        }

        public void Save(string path)
        {
            XmlSerializer xmlSer = new XmlSerializer(this.GetType());
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                xmlSer.Serialize(fs, this);
            }
        }
    }
}
