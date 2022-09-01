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
using System.Drawing.Drawing2D;

namespace BoulderingSegmentImageGenerator
{
    public partial class BoulderingSegmentImageGenerator : Form
    {
        public BoulderingSegmentImageGenerator()
        {
            InitializeComponent();
        }

        // ラジオボタンの選択, ホールド
        private void Holds_CheckedChanged(object sender, EventArgs e)
        {
            if (this.painter != null)
            {
                painter.SetHoldsType(HoldsType_t.Holds);
            }
        }

        // ラジオボタンの選択, ボリューム
        private void Volume_CheckedChanged(object sender, EventArgs e)
        {
            if (this.painter != null)
            {
                painter.SetHoldsType(HoldsType_t.Volume);
            }
        }

        // ラジオボタンの選択, 背景描画
        private void BackgrounButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.painter != null)
            {
                painter.SetHoldsType(HoldsType_t.Background);
            }
        }

        // フォルダオープンボタンが押された時フォルダダイアログを開く
        private void open_Click(object sender, EventArgs e)
        {
            DisableButton();
            // 入力画像があるフォルダを選択
            DialogResult result = this.folderBrowserDialog.ShowDialog();
            Debug.WriteLine("filepath select : " + result);

            if (result == DialogResult.Cancel)
                return;

            // 選択したフォルダ名を出力
            FolderPath.Text = this.folderBrowserDialog.SelectedPath;
            Debug.WriteLine("input file path : " + FolderPath.Text);
            EnableButton();
        }

        // フォルダパスのテキスが変更されたときの処理
        private void FolderPath_TextChanged(object sender, EventArgs e)
        {
            this.folderBrowserDialog.SelectedPath = FolderPath.Text;
        }


        // PictureBox内でマウスホイールを動かした時, ズームorズームアウトする
        private void InputImage_MouseWheel(object sender, MouseEventArgs e)
        {
            if (painter != null)
            {
                painter.ZoomPicture(ConvertCoordinates(e.Location), e.Delta);
            }
        }

        // PictureBox をクリックされたときの処理
        // 左クリック : segmentを描く
        // 左クリック : 画像を動かす
        private void InputImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (painter == null)
                return;
            if (e.Button == MouseButtons.Left)
            {
                painter.MouseDownLeft(ConvertCoordinates(e.Location));
                InputImage.Update();
            }
            else if (e.Button == MouseButtons.Right)
            {
                painter.MouseDownRight(ConvertCoordinates(e.Location));
                InputImage.Update();
            }

        }

        // picturebox内でマウスボタンが押された後にマウスボタンが離された時
        private void InputImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (painter == null)
                return;

            if (e.Button == MouseButtons.Left)
            {
                painter.MouseUpLeft();
            }
            else if (e.Button == MouseButtons.Right)
            {
                painter.MouseUpRight();
            }
        }

        // pictureBox内でマウスドラッグされたときの処理, 左右同時押しには未対応
        private void InputImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (painter == null)
                return;

            if (e.Button == MouseButtons.Left)
            {
                painter.MouseMoveLeft(ConvertCoordinates(e.Location));
                InputImage.Update();
            }
            else if (e.Button == MouseButtons.Right)
            {
                painter.MouseMoveRight(ConvertCoordinates(e.Location));
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
            DisableButton();
            Debug.WriteLine("LoadButton Clicked");
            if (this.painter == null)
                this.painter = new Painter(FolderPath.Text, InputImage.Location);
            InputImage.Image = painter.GetProcessedImage();
            EnableButton();
        }

        private Painter painter = null;

        // AlphaBar の値が変更された時, segment画像とinput画像のアルファ値を変更する
        private void AlphaBar_ValueChanged(object sender, EventArgs e)
        {
            if (this.painter != null)
            {
                this.painter.SetAlpha(AlphaBar.Value);
                this.painter.UpdateImage();
            }
        }

        // left button 押下時画像を左へ90度回転させる
        private void LeftRotateButton_Click(object sender, EventArgs e)
        {
            this.painter.RotateLeftCurrentImage();
            UpdatePictureBox();
        }

        // right button 押下時画像を右へ90度回転させる
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

        // pictureBoxの画像を更新する
        private void UpdatePictureBox()
        {
            this.painter.UpdateImage();
            this.InputImage.Update();
        }

        // save ボタンの処理
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (painter == null)
                return;

            DisableButton();
            this.painter.SaveImage();
            EnableButton();
        }

        // 次の画像へ遷移する
        private void NextButton_Click(object sender, EventArgs e)
        {
            if (this.painter == null)
                return;
            DisableButton();
            this.painter.NextImage();
            this.painter.UpdateImage();
            EnableButton();
        }

        // 前の画像へ遷移する
        private void PrevButton_Click(object sender, EventArgs e)
        {
            if (this.painter == null)
                return;
            this.painter.PrevImage();
            this.painter.UpdateImage();
        }

        // すべてのボタンを有効化する
        private void EnableButton()
        {
            NextButton.Enabled = true;
            PrevButton.Enabled = true;
            LeftRotateButton.Enabled = true;
            RightRotateButton.Enabled = true;
            SaveButton.Enabled = true;
        }

        // すべてのボタンを無効化する
        private void DisableButton()
        {
            NextButton.Enabled = false;
            PrevButton.Enabled = false;
            LeftRotateButton.Enabled = false;
            RightRotateButton.Enabled = false;
            SaveButton.Enabled = false;
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

        private void ResetButton_Click(object sender, EventArgs e)
        {

        }
    }
}
