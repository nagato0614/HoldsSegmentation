using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Drawing.Imaging;

namespace BoulderingSegmentImageGenerator
{
    abstract public class ImagesBase
    {

        public ImagesBase(string pathToWorkspace,
            string imageworkSpaceName)
        {
            this.pathToWorkspace = pathToWorkspace;
            this.imageworkSpaceName = imageworkSpaceName;
            init();
        }

        private void init()
        {
            GenerateImageWorkspace();
            ProcessImages();
        }

        // ワークスペース内に画像を処理するフォルダを生成する.
        private void GenerateImageWorkspace()
        {
            var imageworkSpace = Path.Combine(this.pathToWorkspace, this.imageworkSpaceName);
            Directory.CreateDirectory(imageworkSpace);
            Debug.WriteLine("creat Image workspace : " + imageworkSpace);
        }

        // currentImageを次の画像に変更する
        public void Next()
        {
            UpdateCurrentImageID();
            var filepath = GetCurrentImageFilePaht();
            this.currentImage = new Bitmap(filepath);
        }

        // 
        private void UpdateCurrentImageID()
        {
            if (this.currentImageID >= this.numOfImage)
            {
                this.currentImageID = 0;
            }
            else
            {
                this.currentImageID++;
            }
        }

        private int GetCurrentImageID()
        {
            return this.currentImageID;
        }

        // 現在処理してい画像の絶対ファイルパス
        private string GetCurrentImageFilePaht()
        {
            var filename = $"{this.imageworkSpaceName}_{this.currentImageID}.png";
            var filepath = Path.Combine(this.pathToWorkspace, this.imageworkSpaceName, filename);
            return filepath;
        }

        // 現在処理している画像のbitmapを取得
        public Bitmap GetCurrentImage()
        {
            var filepath = GetCurrentImageFilePaht();
            Bitmap img = new Bitmap(filepath);

            Debug.WriteLine("load current Image : " + filepath);
            return img;
        }

        // 処理した画像を受け取り保存する
        private void SaveCurrentImage(Bitmap processedImage)
        {
            var filepath = GetCurrentImageFilePaht();
            this.currentImage = processedImage;
            this.currentImage.Save(filepath, ImageFormat.Png);
        }


        // 入力画像の処理を記述する
        public abstract void ProcessImages();

        protected Bitmap currentImage;
        protected int numOfImage;
        protected int currentImageID;

        protected readonly string pathToWorkspace;
        protected readonly string imageworkSpaceName;
    }
}
