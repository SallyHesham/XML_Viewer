using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace XML_Viewer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mainWindow());
        }
    }

    static class xml_ref
    {
        public static string file_path;
        // carmine (166, 5, 20)
        // blood red (136, 8, 8)
        public static Color highlights = Color.FromArgb(136, 5, 8);
        public static Color paragraphColor = Color.FromArgb(255, 255, 255);
    }
}
