using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StringKingProcessorTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolStripButton toolStripButton99;
            toolStripButton99 = new System.Windows.Forms.ToolStripButton();

            toolStripButton99.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;

            toolStripButton99.Image = Bitmap.FromFile(@"..\..\..\icons\videocamera_stop.ico");
            //toolStripButton99.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButton99.Name = "toolStripButton99";
            toolStripButton99.Size = new System.Drawing.Size(36, 36);
            toolStripButton99.Text = "toolStripButton99";

            toolStrip1.Items.Add(toolStripButton99);
        }
    }
}
