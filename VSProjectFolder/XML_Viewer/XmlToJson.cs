using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace XML_Viewer
{
    
      class XmlToJson
    {
        
        
        public static void printJson(Node node, StreamWriter file)
        {
            //var f = File.Open("JSON.json", FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            //StreamWriter file = new StreamWriter(f);
            file.Write("\t"+"\"" + node.getTag() + "\"" + ":");
           
            if (node.getData() == "")
            {
                
                file.Write("[\n\t");
                file.Write("\t\t{\n\t");
            }
            else
            {
                
                file.Write("\"" + node.getData() + "\"");
                
            }
        
                
                for (int i = 0; i < node.getChildren().Count; i++)
                {

        
                if (node.getChildren()[i] != null && i<node.getChildren().Count-1)
                    {
                        file.Write(" \t");
                        printJson(node.getChildren()[i], file);
                    
                    file.Write(",\n\t");
                    }
                    if( i==node.getChildren().Count-1)
                {
                    printJson(node.getChildren()[i], file);
                    file.WriteLine("\n\t\t}");
                    file.Write("\t]");

                }
    
                }
               
            }
        }

    }

