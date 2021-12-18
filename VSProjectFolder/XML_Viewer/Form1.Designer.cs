
namespace XML_Viewer
{
    partial class mainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.openButton = new System.Windows.Forms.ToolStripMenuItem();
            this.saveButton = new System.Windows.Forms.ToolStripMenuItem();
            this.correctErrorsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.convertButton = new System.Windows.Forms.ToolStripMenuItem();
            this.compressButton = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTextDisplay = new System.Windows.Forms.RichTextBox();
            this.decompressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.BackColor = System.Drawing.Color.Black;
            this.mainMenuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.mainMenuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openButton,
            this.saveButton,
            this.correctErrorsButton,
            this.convertButton,
            this.compressButton,
            this.decompressToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(14, 12);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(856, 33);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // openButton
            // 
            this.openButton.BackColor = System.Drawing.Color.Transparent;
            this.openButton.ForeColor = System.Drawing.Color.White;
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(72, 29);
            this.openButton.Text = "Open";
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(65, 29);
            this.saveButton.Text = "Save";
            // 
            // correctErrorsButton
            // 
            this.correctErrorsButton.ForeColor = System.Drawing.Color.White;
            this.correctErrorsButton.Name = "correctErrorsButton";
            this.correctErrorsButton.Size = new System.Drawing.Size(136, 29);
            this.correctErrorsButton.Text = "Correct Errors";
            // 
            // convertButton
            // 
            this.convertButton.ForeColor = System.Drawing.Color.White;
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(160, 29);
            this.convertButton.Text = "Convert to JSON";
            // 
            // compressButton
            // 
            this.compressButton.ForeColor = System.Drawing.Color.White;
            this.compressButton.Name = "compressButton";
            this.compressButton.Size = new System.Drawing.Size(108, 29);
            this.compressButton.Text = "Compress";
            // 
            // mainTextDisplay
            // 
            this.mainTextDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTextDisplay.BackColor = System.Drawing.Color.Black;
            this.mainTextDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainTextDisplay.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.mainTextDisplay.Font = new System.Drawing.Font("Courier New", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainTextDisplay.ForeColor = System.Drawing.Color.White;
            this.mainTextDisplay.Location = new System.Drawing.Point(12, 50);
            this.mainTextDisplay.Name = "mainTextDisplay";
            this.mainTextDisplay.ReadOnly = true;
            this.mainTextDisplay.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.mainTextDisplay.Size = new System.Drawing.Size(1002, 540);
            this.mainTextDisplay.TabIndex = 1;
            this.mainTextDisplay.Text = "";
            // 
            // decompressToolStripMenuItem
            // 
            this.decompressToolStripMenuItem.Name = "decompressToolStripMenuItem";
            this.decompressToolStripMenuItem.Size = new System.Drawing.Size(127, 29);
            this.decompressToolStripMenuItem.Text = "Decompress";
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1026, 602);
            this.Controls.Add(this.mainTextDisplay);
            this.Controls.Add(this.mainMenuStrip);
            this.ForeColor = System.Drawing.Color.White;
            this.MainMenuStrip = this.mainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(679, 462);
            this.Name = "mainWindow";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XML Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openButton;
        private System.Windows.Forms.ToolStripMenuItem convertButton;
        private System.Windows.Forms.ToolStripMenuItem correctErrorsButton;
        private System.Windows.Forms.ToolStripMenuItem compressButton;
        private System.Windows.Forms.ToolStripMenuItem saveButton;
        private System.Windows.Forms.RichTextBox mainTextDisplay;
        private System.Windows.Forms.ToolStripMenuItem decompressToolStripMenuItem;
    }
}

