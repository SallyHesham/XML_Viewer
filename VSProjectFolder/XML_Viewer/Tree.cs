using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XML_Viewer
{
    class Tree
    {
        private Node root;

        Tree()
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
            char letter;
            Node lastPopped = null;
            Stack<Node> nodes = new Stack<Node>();
            StreamReader reader = new StreamReader(file);

            // while not at file end
            while(reader.Peek() != -1)
            {
                // read first character
                letter = (char)reader.Read();
                // if tag
                if(letter == '<')
                {
                    // empty strings
                    string tag = "";
                    string data = "";

                    // if opening tag
                    if ((char)reader.Peek() != '/')
                    {
                        // read and store tag
                        while((char)reader.Peek() != '>')
                        {
                            tag += (char)reader.Read();
                        }
                        //skip '>' character
                        reader.Read();

                        // if data
                        if((char)reader.Peek() != '<')
                        {
                            data += (char)reader.Read();
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

                    }
                    // if closing tag
                    else
                    {
                        while((char)reader.Peek() != '<')
                        {
                            reader.Read();
                        }
                        lastPopped = nodes.Pop();
                    }
                }
                // if data
                else if(letter != '\n' && letter != '\t')
                {

                }
            }

            // when finished set root
            root = lastPopped;
        }
    }
}
