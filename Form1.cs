using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace XML_Viewer
{
    public partial class mainWindow : Form
    {
        public mainWindow()
        {
            InitializeComponent();
        }

        // Open button event implementation
        private void openButton_Click(object sender, EventArgs e)
        {
            // Opens a folder browser window
            OpenFileDialog fileBrowser = new OpenFileDialog();
            fileBrowser.Title = "Select XML file";
            fileBrowser.Filter = "XML files (*.xml)|*.xml";
            
            if (fileBrowser.ShowDialog() == DialogResult.OK)
            {
                // fileName is the full path of the file selected by the user
                string fileName = fileBrowser.FileName;
                // I currently display the file as is
                // this will change later
                this.mainTextDisplay.Text = File.ReadAllText(fileName);
                 Tree xml_tree = new Tree();
                 xml_tree.populateTree(fileName);
                 Node tree_root = xml_tree.getRoot();
                
            }

        }
    }
}
