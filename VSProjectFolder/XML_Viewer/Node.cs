using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_Viewer
{
    /// <summary>
    /// node class
    /// not much use creating nodes outside of tree
    /// useful functions are:
    /// getTag()
    /// getData()
    /// getChildren()
    /// </summary>

    class Node
    {
        private string tag;
        private string data;
        private List<Node> children = new List<Node>();

        public Node(string t, string d)
        {
            tag = t;
            data = d;
        }

        public void addChild(Node n)
        {
            children.Add(n);
        }

        public string getTag()
        {
            return tag;
        }

        public string getData()
        {
            return data;
        }

        public void setData(string d)
        {
            data = d;
        }

        public List<Node> getChildren()
        {
            return children;
        }
    }
}
