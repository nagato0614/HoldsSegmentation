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

namespace BoulderingSegmentImageGenerator
{
    public partial class BoulderingSegmentImageGenerator : Form
    {
        public BoulderingSegmentImageGenerator()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Holds_CheckedChanged(object sender, EventArgs e)
        {
            paint.selectHolds();
        }

        private void Volume_CheckedChanged(object sender, EventArgs e)
        {
            paint.selectVolume();
        }

        private void BackgrounButton_CheckedChanged(object sender, EventArgs e)
        {
            paint.selectBackground();
        }

        private void open_Click(object sender, EventArgs e)
        {
            DialogResult result = this.folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
                FolderPath.Text = this.folderBrowserDialog.SelectedPath;
            string[] files = System.IO.Directory.GetFiles(FolderPath.Text, "*", System.IO.SearchOption.AllDirectories);
            List<string> filenames = new List<string>();
            foreach (string file in files)
            {
                filenames.Add(Path.GetFileName(file));
            }
            InputImageListBox.Items.AddRange(filenames.ToArray());
        }

        private void FolderPath_TextChanged(object sender, EventArgs e)
        {
            this.folderBrowserDialog.SelectedPath = FolderPath.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
