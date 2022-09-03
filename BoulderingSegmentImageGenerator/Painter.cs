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
            this.pen = new Pen(Params.HoldColor, 1);
            Init();
        }

        ~Painter()
        {
        }


        // 初期化
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

        // input, sengment 画像をファイルから読み込み
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

        // ペンの色を変更
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

            Bitmap updatedImage = new Bitmap(segImg.Width, segImg.Height);
            // 入力画像とセグメント画像を合成.
            // 更に画像を拡大縮小 & 移動
            using (Graphics gUpdatedImage = Graphics.FromImage(updatedImage))
            {
                gUpdatedImage.CompositingMode = CompositingMode.SourceOver;

                // 変換行列を読み込み
                gUpdatedImage.Transform = matrix;

                // 画像を拡大時に補完を行わないようにする
                // ピクセルがそのまま拡大されることによりセグメンテーション画像を作りやすくする
                gUpdatedImage.InterpolationMode = InterpolationMode.NearestNeighbor;
                gUpdatedImage.PixelOffsetMode = PixelOffsetMode.Half;

                // アフィン変換した画像を描く
                gUpdatedImage.DrawImage(segImg, 0, 0, segImg.Width, segImg.Height);
                gUpdatedImage.DrawImage(inImg, 0, 0, inImg.Width, inImg.Height);
            }

            segImg.Dispose();
            inImg.Dispose();
            this.processedImage = updatedImage;
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

        // 現在処理している画像を一旦保存する
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

        // 次の画像を current iamge にセットする
        public void NextImage()
        {
            this.SaveImage();
            this.inputImages.Next();
            this.segmentImages.Next();


            LoadCurrentImage();
            this.strokes = new Stack<List<Point>>();
        }

        // 前の画像を current iamge にセットする
        public void PrevImage()
        {
            this.SaveImage();
            this.inputImages.Prev();
            this.segmentImages.Prev();

            LoadCurrentImage();
            this.strokes = new Stack<List<Point>>();
        }

        // pictureboxが右クリックされた時 (画像を移動させる)
        public void MouseDownRight(Point p)
        {
            Debug.WriteLine("Right Button is down");
            UpdateImage();

            oldPoint.X = p.X;
            oldPoint.Y = p.Y;
            rightButtonDown = true;
        }

        // pictureboxが押されたときの処理
        public void MouseDownLeft(Point p)
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
        public void MouseUpLeft()
        {
            foreach (var p in strokes.Peek())
            {
                Debug.WriteLine("Stroke Points : " + p.ToString());
            }
            strokes.Pop();
        }

        public void MouseUpRight()
        {
            rightButtonDown = false;
        }

        // pictureBoxでマウスを押下したあと動かした場合の処理
        public void MouseMoveLeft(Point p)
        {
            Point drawPoint = p;

            // 左クリック出ない場合は処理を行わない
            if (Control.MouseButtons != MouseButtons.Left)
                return;
            if (this.strokes == null)
                return;
            this.strokes.Peek().Add(drawPoint);
            this.UpdateImage();
        }

        // マウスが移動されたときの処理, 移動された距離に合わせて画像をずらす.
        public void MouseMoveRight(Point p)
        {
            if (!rightButtonDown)
                return;

            matrix.Translate(p.X - oldPoint.X, p.Y - oldPoint.Y, MatrixOrder.Append);
            UpdateImage();
            oldPoint = p;
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

        // ラジオボタンでホールドのタイプを指定する.
        public void SetHoldsType(HoldsType_t t)
        {
            this.holdsType = t;
            SetColor(this.holdsType);
        }

        // ラジオボタンの入力に応じてペンの色を指定する
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

        public void ZoomPicture(Point p, int zoom)
        {
            // ポインタで指定した位置を原点に移動
            matrix.Translate(-p.X, -p.Y, MatrixOrder.Append);

            // 拡大
            if (zoom > 0)
            {
                if (matrix.Elements[0] < 100)
                {
                    matrix.Scale(1.5f, 1.5f, MatrixOrder.Append);
                }
            }
            // 縮小
            else
            {
                if (matrix.Elements[0] > 0.01)
                {
                    matrix.Scale(1.0f / 1.5f, 1.0f / 1.5f, MatrixOrder.Append);
                }
            }

            // 原点からポインタへ指定した位置へ移動
            matrix.Translate(p.X, p.Y, MatrixOrder.Append);
            UpdateImage();
        }

        // ペンの幅を指定する
        public void SetPenSize(int s)
        {
            this.pen.Width = s;
        }

        // 線を描くためにマウスの軌跡を保存する
        private Stack<List<Point>> strokes = new Stack<List<Point>>();

        // 線を描くためのペン
        private Pen pen;

        // セグメント画像のアルファ値
        private float SegmentAlpha;

        // 入力画像のアルファ値
        private float InputAlpha;

        // 現在処理しているセグメント画像フォルダ
        private SegmentImages segmentImages;

        // 現在処理している入力画像フォルダ
        private InputImages inputImages;

        // 現在処理している画像
        private Bitmap currentInputImage;
        private Bitmap currentSegmentImage;

        // 現在 picture box に表示している画像
        private Bitmap processedImage;

        // 処理を行いたい画像が保存されているフォルダ
        private string originalImageFolderPath;

        // 新しく生成した画像が入っているフォルダ
        private string workspaceFolderPath;

        // 現在選択しているホールドのタイプ
        private HoldsType_t holdsType;

        // 拡大縮小の変換行列
        private Matrix matrix = new Matrix();
        private PointF oldPoint = PointF.Empty;
        private bool rightButtonDown = false;
    }
}