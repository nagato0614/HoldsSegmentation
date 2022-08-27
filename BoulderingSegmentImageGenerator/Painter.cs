using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BoulderingSegmentImageGenerator
{
    public class Painter
    {

        public Painter(string InputImageFolderPath, Point PictureBoxLocation)
        {
            this.originalImageFolderPath = InputImageFolderPath;
            this.atomic = new Atomic();
            this.pen = new Pen(Params.HoldColor, 1);
            Init();
        }

        ~Painter()
        {
        }


        private void Init()
        {
            CreateWorkSpace();

            // 入出力画像を扱うためのインスタンスを初期化
            this.segmentImages = new SegmentImages(this.workspaceFolderPath, Params.SegmentImageFolderName);
            this.inputImages = new InputImages(this.workspaceFolderPath, Params.InputImageFolderName);

            // 画像を読み込み
            LoadCurrentImage();

            // アルファ値を設定し画像を更新する.
            SetAlpha(50);
            UpdateImage();
        }

        public void LoadCurrentImage()
        {
            this.currentInputImage = this.inputImages.GetCurrentImage();
            this.currentSegmentImage = this.segmentImages.GetCurrentImage();
        }

        // 画像にアルファ値を設定する.
        private Bitmap SetBitmapAlpha(Bitmap b, float a)
        {
            Bitmap outputImg = new Bitmap(b.Width, b.Height);
            var cm = new ColorMatrix();
            using (var g = Graphics.FromImage(outputImg))
            {
                cm.Matrix00 = 1;
                cm.Matrix11 = 1;
                cm.Matrix22 = 1;
                cm.Matrix33 = a;
                cm.Matrix44 = 1;

                ImageAttributes ia = new ImageAttributes();
                ia.SetColorMatrix(cm);
                g.DrawImage(b, new Rectangle(0, 0, b.Width, b.Height), 0, 0, b.Width, b.Height, GraphicsUnit.Pixel, ia);

            }
            return outputImg;
        }

        // ワークスペースフォルダの作成
        private void CreateWorkSpace()
        {
            // ワークスペース作成.　同名フォルダがある場合連番を振る.
            var workspacePath = Path.Combine(originalImageFolderPath, Params.WorkSpaceFolderName);
            int i = 1;
            var newPath = workspacePath;
            while (Directory.Exists(newPath))
            {
                newPath = $"{workspacePath}_{i++}";
            }
            Directory.CreateDirectory(newPath);
            this.workspaceFolderPath = newPath;
            Debug.WriteLine(newPath);
        }

        public void ChangePenColor(Color c)
        {
            pen.Color = c;
        }


        // 現在処理している画像を取得する.
        public Bitmap GetProcessedImage()
        {
            return this.processedImage;
        }

        // picuture box で表示する画像を現在の設定値に合わせて出力する
        // alpha値などを更新した場合この関数を実行することで反映することができる.
        public void UpdateImage()
        {
            // セグメント画像を更新
            Drawing();

            // 実際に画面に表示される画像を生成
            // alpha値を0.5に設定.
            var segImg = SetBitmapAlpha(this.currentSegmentImage, this.SegmentAlpha);
            var inImg = SetBitmapAlpha(this.currentInputImage, this.InputAlpha);


            // 入力画像とセグメント画像を合成.
            using (var g = Graphics.FromImage(inImg))
            {
                g.CompositingMode = CompositingMode.SourceOver;
                g.DrawImage(segImg, 0, 0, segImg.Width, segImg.Height);
            }

            this.processedImage = inImg;
        }


        // 画像を右に90度回転させる.
        public void RotateRightCurrentImage()
        {
            this.currentInputImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
            this.currentSegmentImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
        }

        // 画像を左に90度回転させる.
        public void RotateLeftCurrentImage()
        {
            this.currentInputImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
            this.currentSegmentImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
        }

        public void SaveImage()
        {
            this.inputImages.SaveCurrentImage();
            this.segmentImages.SaveCurrentImage();
        }

        // アルファ値を設定する
        // processedImage を更新したい場合は UpdateImage() を実行する必要あり
        // a = [0, 99]
        public void SetAlpha(int a)
        {
            float inputValue = a;
            if (inputValue > 99)
            {
                inputValue = 99;
            }
            else if (inputValue < 0)
            {
                inputValue = 0;
            }

            this.InputAlpha = inputValue / 100;
            this.SegmentAlpha = 1 - (inputValue / 100);

            Debug.WriteLine("input Alpha : " + this.InputAlpha.ToString());
            Debug.WriteLine("segment Alpha : " + this.SegmentAlpha.ToString());
        }

        // セグメント画像のアルファ値を取得
        public float GetSegmentAlpha()
        {
            return this.SegmentAlpha;
        }

        // 入力画像のアルファ値を取得
        public float GetInputAlpha()
        {
            return this.InputAlpha;
        }

        public void NextImage()
        {
            this.SaveImage();
            this.inputImages.Next();
            this.segmentImages.Next();

            LoadCurrentImage();
            this.strokes = new Stack<List<Point>>();
        }



        public void PrevImage()
        {
            this.SaveImage();
            this.inputImages.Prev();
            this.segmentImages.Prev();

            LoadCurrentImage();
            this.strokes = new Stack<List<Point>>();
        }

        // pictureboxが押されたときの処理
        public void MouseDown(Point p)
        {

            Point drawPoint = p;
            int width = (int)pen.Width;

            // 押された場所に色を付ける
            // クリックされたときの処理
            SolidBrush b = new SolidBrush(pen.Color);
            using (var g = Graphics.FromImage(this.currentSegmentImage))
            {
                g.FillEllipse(b, drawPoint.X - (width / 2), drawPoint.Y - (width / 2), width, width);
            }

            // 線を引くためにマウスの軌跡を保存する
            strokes.Push(new List<Point>());
            strokes.Peek().Add(drawPoint);
            UpdateImage();
            Debug.WriteLine("マウス座標 : " + System.Windows.Forms.Cursor.Position.ToString());
            Debug.WriteLine("Cliked Point : " + drawPoint.ToString());
        }

        // pictureboxからマウスが話されたとき
        public void MouseUp()
        {
            foreach (var p in strokes.Peek())
            {
                Debug.WriteLine("Stroke Points : " + p.ToString());
            }
            strokes.Pop();
        }

        // pictureBoxでマウスを押下したあと動かした場合の処理
        public void MouseMove(Point p)
        {
            Point drawPoint = p;

            // ボタンが押されていない場合は処理を終了
            if (Control.MouseButtons == MouseButtons.None)
                return;
            this.strokes.Peek().Add(drawPoint);
            this.UpdateImage();
        }


        // 描いた線を描画する
        private void Drawing()
        {
            using (var g = Graphics.FromImage(this.currentSegmentImage))
            {
                foreach (var stroke in strokes)
                {
                    GraphicsPath path = new GraphicsPath(stroke.ToArray(), Enumerable.Repeat<byte>(1, stroke.Count).ToArray());
                    g.DrawPath(pen, path);
                }
            }
        }

        public void SetHoldsType(HoldsType_t t)
        {
            this.holdsType = t;
            SetColor(this.holdsType);
        }

        public void SetColor(HoldsType_t t)
        {
            Color c;
            switch (t)
            {
                case HoldsType_t.Holds: c = Params.HoldColor; break;
                case HoldsType_t.Volume: c = Params.VolumeColor; break;
                case HoldsType_t.Background: c = Params.BackgroundColor; break;
                default: c = Params.BackgroundColor; break;
            }
            pen.Color = c;
        }

        public void SetPenSize(int s)
        {
            this.pen.Width = s;
        }

        private Stack<List<Point>> strokes = new Stack<List<Point>>();
        private Pen pen;

        // セグメント画像のアルファ値
        private float SegmentAlpha;

        // 入力画像のアルファ値
        private float InputAlpha;

        // 現在処理しているセグメント画像フォルダ
        private SegmentImages segmentImages;

        // 現在処理している入力画像フォルダ
        private InputImages inputImages;

        private Bitmap currentInputImage;
        private Bitmap currentSegmentImage;

        // 現在 picture box に表示している画像
        private Bitmap processedImage;

        // 処理を行いたい画像が保存されているフォルダ
        private string originalImageFolderPath;

        // 新しく生成した画像が入っているフォルダ
        private string workspaceFolderPath;

        // 非同期処理用
        private Atomic atomic;

        private HoldsType_t holdsType;
    }
}