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
using System.Diagnostics;

namespace BoulderingSegmentImageGenerator
{
    public partial class BoulderingSegmentImageGenerator : Form
    {
        public BoulderingSegmentImageGenerator()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Holds_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void Volume_CheckedChanged(object sender, EventArgs e)
        {
            this.painter.GetPiant().selectVolume();
        }

        private void BackgrounButton_CheckedChanged(object sender, EventArgs e)
        {
            this.painter.GetPiant().selectBackground();
        }


        private void open_Click(object sender, EventArgs e)
        {

            // 入力画像があるフォルダを選択
            DialogResult result = this.folderBrowserDialog.ShowDialog();
            Debug.WriteLine("filepath select : " + result);

            if (result == DialogResult.Cancel)
                return;

            // 選択したフォルダ名を出力
            FolderPath.Text = this.folderBrowserDialog.SelectedPath;
            Debug.WriteLine("input file path : " + FolderPath.Text);

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

        private void InputImage_Click(object sender, EventArgs e)
        {
            var mousePoint = System.Windows.Forms.Cursor.Position;
            Debug.WriteLine("picture box clicked : " + mousePoint);
        }

        private void InputImage_MouseWheel(object sender, MouseEventArgs e)
        {
        }

        private void InputImage_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void InputImage_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void InputImage_Paint(object sender, PaintEventArgs e)
        {

        }


        // 入力画像のトリミングと出力画像のベースを生成
        // 既存のフォルダがある場合は新しい作業フォルダを作成
        private void LoadButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("LoadButton Clicked");
            if (this.painter == null)
                this.painter = new Painter(FolderPath.Text);
            InputImage.Image = painter.GetProcessedImage();

        }

        private Painter painter = null;

        private void folderBrowserDialog_HelpRequest(object sender, EventArgs e)
        {

        }

        private void AlphaBar_Scroll(object sender, EventArgs e)
        {
            if (this.painter != null)
                this.painter.SetAlpha(AlphaBar.Value);

        }

        private void LeftRotateButton_Click(object sender, EventArgs e)
        {
            this.painter.RotateLeftCurrentImage();
        }

        private void RightRotateButton_Click(object sender, EventArgs e)
        {
            this.painter.RotateRightCurrentImage();
        }
    }
}
