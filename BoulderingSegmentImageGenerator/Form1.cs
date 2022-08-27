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
            if (this.painter != null)
            {
                painter.SetHoldsType(HoldsType_t.Holds);
            }
        }

        private void Volume_CheckedChanged(object sender, EventArgs e)
        {
            if (this.painter != null)
            {
                painter.SetHoldsType(HoldsType_t.Volume);
            }
        }

        private void BackgrounButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.painter != null)
            {
                painter.SetHoldsType(HoldsType_t.Background);
            }
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
            if (painter != null)
            {
            }
        }

        private void InputImage_MouseWheel(object sender, MouseEventArgs e)
        {
        }

        private void InputImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (painter != null)
            {
                painter.MouseDown(ConvertCoordinates(e.Location));
                InputImage.Update();
            }
        }

        private void InputImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (painter != null)
            {
                painter.MouseUp();
            }
        }

        private void InputImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (painter != null)
            {
                painter.MouseMove(ConvertCoordinates(e.Location));
                InputImage.Update();
            }
        }

        // picture box の再描写ハンドラ
        private void InputImage_Paint(object sender, PaintEventArgs e)
        {
            if (this.painter != null)
                this.InputImage.Image = this.painter.GetProcessedImage();
        }


        // 入力画像のトリミングと出力画像のベースを生成
        // 既存のフォルダがある場合は新しい作業フォルダを作成
        private void LoadButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("LoadButton Clicked");
            if (this.painter == null)
                this.painter = new Painter(FolderPath.Text, InputImage.Location);
            InputImage.Image = painter.GetProcessedImage();

        }

        private Painter painter = null;

        private void folderBrowserDialog_HelpRequest(object sender, EventArgs e)
        {

        }

        private void AlphaBar_Scroll(object sender, EventArgs e)
        {

        }

        private void AlphaBar_ValueChanged(object sender, EventArgs e)
        {
            if (this.painter != null)
            {
                this.painter.SetAlpha(AlphaBar.Value);
                this.painter.UpdateImage();
            }
        }

        private void LeftRotateButton_Click(object sender, EventArgs e)
        {
            this.painter.RotateLeftCurrentImage();
            UpdatePictureBox();
        }

        private void RightRotateButton_Click(object sender, EventArgs e)
        {
            this.painter.RotateRightCurrentImage();
            UpdatePictureBox();
        }

        private void paintSizeBar_Scroll(object sender, EventArgs e)
        {
            if (painter != null)
            {
                painter.SetPenSize(paintSizeBar.Value);
            }
        }

        private void UpdatePictureBox()
        {
            this.painter.UpdateImage();
            this.InputImage.Update();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (painter != null)
                this.painter.SaveImage();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (this.painter != null)
            {
                this.painter.NextImage();
                this.painter.UpdateImage();
            }
        }

        private void PrevButton_Click(object sender, EventArgs e)
        {
            if (this.painter != null)
            {
                this.painter.PrevImage();
                this.painter.UpdateImage();
            }
        }


        private void Lock(Action action)
        {
            DisableButton();
            action();
            EnableButton();
        }

        private void EnableButton()
        {
            NextButton.Enabled = true;
            PrevButton.Enabled = true;
            LeftRotateButton.Enabled = true;
            RightRotateButton.Enabled = true;
        }

        private void DisableButton()
        {
            NextButton.Enabled = false;
            PrevButton.Enabled = false;
            LeftRotateButton.Enabled = false;
            RightRotateButton.Enabled = false;
        }

        // picturebox の座標を表示している画像の座標系に変換する
        private Point ConvertCoordinates(Point location)
        {
            var x = location.X;
            var y = location.Y;
            var picH = InputImage.ClientSize.Height;
            var picW = InputImage.ClientSize.Width;
            var imgH = InputImage.Image.Height;
            var imgW = InputImage.Image.Width;

            int X0;
            int Y0;
            if (picW / (float)picH > imgW / (float)imgH)
            {
                var scaledW = imgW * picH / (float)imgH;
                var dx = (picW - scaledW) / 2;
                X0 = (int)((x - dx) * imgH / picH);

                Y0 = (int)(imgH * y / (float)picH);
            }
            else
            {
                X0 = (int)(imgW * x / (float)picW);

                var scaledH = imgH * picW / (float)imgW;
                var dy = (picH - scaledH) / 2;
                Y0 = (int)((y - dy) * imgW / picW);
            }

            if (X0 < 0 || imgW < X0 || Y0 < 0 || imgH < Y0)
            {
                return new Point(-1, -1); // 範囲外をどう表すのがいいか
            }

            return new Point(X0, Y0);
        }



    }
}
