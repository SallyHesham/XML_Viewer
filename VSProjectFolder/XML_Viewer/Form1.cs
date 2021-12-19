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
                xml_ref.file_type = "xml";
                // I currently display the file as is
                // this will change later
                this.mainTextDisplay.Text = File.ReadAllText(fileName);
                
            }
            correctErrorsButton.Enabled = true;
            convertButton.Enabled = false;
            compressButton.Enabled = false;
            decompressButton.Enabled = false;
        }

        private void compressButton_Click(object sender, EventArgs e)
        {
            string cmp;
            string dcmp = File.ReadAllText(xml_ref.file_path);

            cmp = Compression.Compress(dcmp);

            //was is the compressed file's extension???
            StreamWriter writer = new StreamWriter("CompressedFile.txt");
            writer.Write(cmp);
            writer.Close();

            this.mainTextDisplay.Text = cmp;
            decompressButton.Enabled = true;
            compressButton.Enabled = false;
            convertButton.Enabled = false;
        }

        private void decompressButton_Click(object sender, EventArgs e)
        {
            string cmp;
            cmp = File.ReadAllText("CompressedFile.txt");
            string dcmp;

            dcmp = Compression.Decompress(cmp);

            if (xml_ref.file_type == "xml")
            {
                StreamWriter writer = new StreamWriter("DecompressedFile.xml");
                writer.Write(dcmp);
                writer.Close();

                this.mainTextDisplay.Text = "";
                xml_ref.file_path = Path.GetFullPath("DecompressedFile.xml");
                displayFormattedAlternate();
                convertButton.Enabled = true;
            }
            else
            {
                StreamWriter writer = new StreamWriter("DecompressedFile.json");
                writer.Write(dcmp);
                writer.Close();

                this.mainTextDisplay.Text = "";
                xml_ref.file_path = Path.GetFullPath("DecompressedFile.json");
                this.mainTextDisplay.Text = File.ReadAllText(xml_ref.file_path);
                convertButton.Enabled = false;
            }
            compressButton.Enabled = true;
            decompressButton.Enabled = false;
        }
        
        private void correctErrorsButton_Click_1(object sender, EventArgs e)
        {
            ErrorCorrection.check();
            this.mainTextDisplay.Text = "";
            displayFormattedAlternate();
            compressButton.Enabled = true;
            convertButton.Enabled = true;
            correctErrorsButton.Enabled = false;

            Tree.xml_tree.populateTree(xml_ref.file_path);
        }

        private void displayFormatted()
        {
            StreamReader reader = new StreamReader(xml_ref.file_path);
            string line;
            string lineTemp;
            string[] arrTemp;
            //string[] arr = text.Split(new string[] { "<" }, StringSplitOptions.RemoveEmptyEntries);
            
            while (reader.Peek() != -1)
            {
                line = reader.ReadLine();
                lineTemp = line.Trim();

                if (lineTemp[0] == '<')
                {
                    arrTemp = lineTemp.Split('<', '>');
                    if (arrTemp.Length == 3)
                    {
                        this.mainTextDisplay.SelectionColor = xml_ref.highlights;
                        this.mainTextDisplay.AppendText(line + Environment.NewLine);
                    }
                    else
                    {
                        arrTemp = line.Split('<', '>');
                        this.mainTextDisplay.AppendText(arrTemp[0]);
                        this.mainTextDisplay.SelectionColor = xml_ref.highlights;
                        this.mainTextDisplay.AppendText('<' + arrTemp[1] + '>');
                        this.mainTextDisplay.SelectionColor = xml_ref.paragraphColor;
                        this.mainTextDisplay.AppendText(arrTemp[2]);
                        this.mainTextDisplay.SelectionColor = xml_ref.highlights;
                        this.mainTextDisplay.AppendText('<' + arrTemp[3] + '>');
                        this.mainTextDisplay.AppendText(arrTemp[4] + Environment.NewLine);
                    }
                }
                else
                {
                    this.mainTextDisplay.SelectionColor = xml_ref.paragraphColor;
                    this.mainTextDisplay.AppendText(line + Environment.NewLine);
                }
            }
            reader.Close();
        }

        private void displayFormattedAlternate()
        {
            StreamReader reader = new StreamReader(xml_ref.file_path);
            string line;
            string lineTemp;
            string[] arrTemp;
            //string[] arr = text.Split(new string[] { "<" }, StringSplitOptions.RemoveEmptyEntries);

            while (reader.Peek() != -1)
            {
                line = reader.ReadLine();
                lineTemp = line.Trim();

                if (lineTemp[0] == '<')
                {
                    arrTemp = lineTemp.Split('<', '>');
                    if (arrTemp.Length == 3)
                    {
                        arrTemp = line.Split('<', '>');
                        this.mainTextDisplay.SelectionColor = xml_ref.paragraphColor;
                        this.mainTextDisplay.AppendText(arrTemp[0] + '<');
                        this.mainTextDisplay.SelectionColor = xml_ref.highlights;
                        this.mainTextDisplay.AppendText(arrTemp[1]);
                        this.mainTextDisplay.SelectionColor = xml_ref.paragraphColor;
                        this.mainTextDisplay.AppendText('>' + arrTemp[2] + Environment.NewLine);
                    }
                    else
                    {
                        arrTemp = line.Split('<', '>');
                        this.mainTextDisplay.SelectionColor = xml_ref.paragraphColor;
                        this.mainTextDisplay.AppendText(arrTemp[0] + '<');
                        this.mainTextDisplay.SelectionColor = xml_ref.highlights;
                        this.mainTextDisplay.AppendText(arrTemp[1]);
                        this.mainTextDisplay.SelectionColor = xml_ref.paragraphColor;
                        this.mainTextDisplay.AppendText('>' + arrTemp[2] + '<');
                        this.mainTextDisplay.SelectionColor = xml_ref.highlights;
                        this.mainTextDisplay.AppendText(arrTemp[3]);
                        this.mainTextDisplay.SelectionColor = xml_ref.paragraphColor;
                        this.mainTextDisplay.AppendText('>' + arrTemp[4] + Environment.NewLine);
                    }
                }
                else
                {
                    this.mainTextDisplay.SelectionColor = xml_ref.paragraphColor;
                    this.mainTextDisplay.AppendText(line + Environment.NewLine);
                }
            }
            reader.Close();
        }


        private void convertButton_Click_1(object sender, EventArgs e)
        {
            this.mainTextDisplay.Text = "";
            Node node = Tree.xml_tree.getRoot();
            StreamWriter file = new StreamWriter("JSON.json");

            XmlToJson.printJson(node, file);
            file.Close();

            xml_ref.file_path = Path.GetFullPath("JSON.json");
            xml_ref.file_type = "json";

            this.mainTextDisplay.Text = File.ReadAllText("JSON.json");
            convertButton.Enabled = false;
        }
    }
}
