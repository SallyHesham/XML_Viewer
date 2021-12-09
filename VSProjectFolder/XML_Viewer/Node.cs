using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_Viewer
{
    class Node
    {
        private string tag;
        private string data;
        private List<Node> children = new List<Node>();

        Node(string t, string d)
        {
            tag = t;
            data = d;
        }

        public void addChild(string t, string d)
        {
            Node child = new Node(t, d);
            children.Add(child);
            return;
        }

        public string getTag()
        {
            return tag;
        }

        public string getData()
        {
            return data;
        }

        public List<Node> getChildren()
        {
            return children;
        }
    }
}
