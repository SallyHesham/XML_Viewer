using System;
using System.IO;
using System.Xml;
using Newtonsoft.Json;

namespace convXmlToJson
{
    internal class Program
    {
        
            static void Main(string[] args)
            {
            
            string xml_data = File.ReadAllText("sample.xml");
                
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml_data);
                string json_data = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented);
                string json_data2 = json_data.Replace("\\r\\n", string.Empty);
            while (json_data2.Contains("  "))
            {
                json_data2 = json_data2.Replace("  ", " ");
            }
            Console.WriteLine(json_data2);
            }
        }
    }
