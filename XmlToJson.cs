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
        

        public void printJson(Node node)
        {
             
            Console.Write("\""+node.getTag()+"\""+":");
            Console.WriteLine("\""+node.getData()+"\"");

            for(int i=0; i<node.getChildren().Count; i++)
            {
                if (node.getChildren()[i] != null)
                {
                    Console.WriteLine("[\n{");
                    printJson(node.getChildren()[i]);
                    Console.WriteLine("}\n]");
                }
                Console.Write(",");
            }
            
        }

    }
}
