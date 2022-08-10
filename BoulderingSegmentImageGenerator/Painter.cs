using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace BoulderingSegmentImageGenerator
{
    public class Painter
    {

        enum HoldsType
        {
            Holds,
            Volume,
            Background,
        }

        enum PaintSize
        {
            pt_1,
            pt_3,
            pt_5,
            pt_10,
        }

        public Painter(string InputImageFolderPath)
        {
            this.originalImageFolderPath = InputImageFolderPath;
            Init();
        }


        private void Init()
        {
            CreateWorkSpace();

            // 入出力画像を扱うためのインスタンスを初期化
            this.segmentImages = new SegmentImages(this.workspaceFolderPath, Params.SegmentImageFolderName);
            this.inputImages = new InputImages(this.workspaceFolderPath, Params.InputImageFolderName);

            // 画像を読み込み
            this.currentInputImage = this.inputImages.GetCurrentImage();
            this.currentSegmentImage = this.segmentImages.GetCurrentImage();

            SetAlpha(50);
            UpdateImage();
        }

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


        public Paint GetPiant()
        {
            return this.paint;
        }


        public Bitmap GetProcessedImage()
        {
            return this.processedImage;
        }

        // picuture box で表示する画像を現在の設定値に合わせて出力する
        // alpha値などを更新した場合この関数を実行することで反映することができる.
        public void UpdateImage()
        {
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

        public void RotateRightCurrentImage()
        {
            this.currentInputImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
            this.currentInputImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
            UpdateImage();
        }

        public void RotateLeftCurrentImage()
        {
            this.currentInputImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
            this.currentInputImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
            UpdateImage();
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

        // セグメント画像を描くためのインスタンス
        private Paint paint;

        // 処理を行いたい画像が保存されているフォルダ
        private string originalImageFolderPath;

        // 新しく生成した画像が入っているフォルダ
        private string workspaceFolderPath;
    }
}