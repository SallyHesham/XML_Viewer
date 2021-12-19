using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XML_Viewer
{
    /// <summary>
    /// tree class used for xml
    /// steps to use:
    /// Tree example = new Tree();
    /// example.populateTree(xmlFilePath);
    /// Node root = example.getRoot();
    /// </summary>

    class Tree
    {
        private Node root;
        public static Tree xml_tree = new Tree();

        public Tree()
        {
            root = null;
        }

        public Node getRoot()
        {
            return root;
        }

        /// <summary>
        /// function used to fill in the tree representing the xml file
        /// used only on valid xml file
        /// </summary>
        /// <param name="file">the xml file used to fill in the tree</param>
        public void populateTree(string file)
        {
            string line;
            string[] words;
            //Node lastPopped = null;
            Stack<Node> nodes = new Stack<Node>();
            StreamReader reader = new StreamReader(file);

            // while not at file end
            while(reader.Peek() != -1)
            {
                // read first line
                line = reader.ReadLine();
                line = line.Trim();

                // if tag
                if(line[0] == '<')
                {
                    // empty strings
                    string tag = "";
                    string data = "";

                    // if opening tag
                    if (line[1] != '/')
                    {
                        // split line into words
                        words = line.Split('<', '>');

                        // store tag
                        tag = words[1];

                        // if tag and data store data as well
                        if(words.Length == 5)
                        {
                            data = words[2];
                        }

                        // create node
                        Node n = new Node(tag, data);

                        // if first node
                        if (nodes.Count == 0)
                        {
                            root = n;
                            nodes.Push(n);
                        }
                        else
                        {
                            Node temp = nodes.Peek();
                            temp.addChild(n);
                            nodes.Push(n);
                        }

                        // if closing tag exists
                        if (words.Length == 5)
                        {
                            nodes.Pop();
                        }

                    }
                    // if closing tag
                    else
                    {
                        nodes.Pop();
                    }
                }
                // if data
                else
                {
                    Node temp = nodes.Peek();
                    temp.setData(line);
                }
            }
            reader.Close();
        }


    }
}
