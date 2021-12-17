using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XML_Viewer
{
    
      class XmlToJson
    {
        

        public static void printJson(Node node, StreamWriter file)
        {
            //var f = File.Open("JSON.json", FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            //StreamWriter file = new StreamWriter(f);
            file.WriteLine("\""+node.getTag()+"\""+":");
            file.WriteLine("\""+node.getData()+"\"");

            for(int i=0; i<node.getChildren().Count; i++)
            {
                if (node.getChildren()[i] != null)
                {
                    file.WriteLine("[\n{");
                    printJson(node.getChildren()[i], file);
                    file.WriteLine("}\n]");
                }
                file.Write(",");
            }
            
        }

    }
}
