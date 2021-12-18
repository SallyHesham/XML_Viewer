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
                xml_ref.file_path = fileName;
                // I currently display the file as is
                // this will change later
                this.mainTextDisplay.Text = File.ReadAllText(fileName);
            }
            
        }

        private void correctErrorsButton_Click(object sender, EventArgs e)
        {
            ErrorCorrection.check();
            this.mainTextDisplay.Text = File.ReadAllText(xml_ref.file_path);
        }
    }
}
