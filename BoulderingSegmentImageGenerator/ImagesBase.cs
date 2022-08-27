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

        ~ImagesBase()
        {
            this.currentImage.Dispose();
        }

        private void init()
        {
            GetNumOfImages();
            GenerateImageWorkspace();
            ProcessImages();
            this.currentImageID = 0;
        }

        private void GetNumOfImages()
        {
            // もとの画像がある場所取得
            var parentFolder = Directory.GetParent(this.pathToWorkspace);
            string[] files = Directory.GetFiles(parentFolder.FullName);
            this.numOfImage = files.Length;
            Debug.WriteLine("Number of Images : " + this.numOfImage.ToString());
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
            this.NextImageId();
            var filepath = GetCurrentImageFilePath();
            Debug.WriteLine("Next Image : " + filepath);
            this.currentImage = new Bitmap(filepath);
        }

        public void Prev()
        {
            this.PrevImageId();
            var filepath = GetCurrentImageFilePath();
            Debug.WriteLine("Prev Image : " + filepath);
            this.currentImage = new Bitmap(filepath);
        }

        // 
        private void NextImageId()
        {
            this.currentImageID++;
            if (this.currentImageID >= this.numOfImage)
            {
                this.currentImageID = 0;
            }
        }

        private void PrevImageId()
        {
            this.currentImageID--;
            if (this.currentImageID < 0)
            {
                this.currentImageID = this.numOfImage - 1;
            }
        }

        private int GetCurrentImageID()
        {
            return this.currentImageID;
        }

        // 現在処理してい画像の絶対ファイルパス
        private string GetCurrentImageFilePath()
        {
            var filename = $"{this.imageworkSpaceName}_{this.currentImageID}.png";
            var filepath = Path.Combine(this.pathToWorkspace, this.imageworkSpaceName, filename);
            return filepath;
        }

        // 現在処理している画像のbitmapを取得
        public Bitmap GetCurrentImage()
        {
            var filepath = GetCurrentImageFilePath();
            Bitmap img = new Bitmap(filepath);
            this.currentImage = img;

            Debug.WriteLine("load current Image : " + filepath);
            return img;
        }

        // 処理した画像を受け取り保存する
        public void SaveCurrentImage()
        {
            // 一時ファイルに画像を保存
            var tmpfilepath = Path.Combine(this.pathToWorkspace, "tmp.png");
            try
            {
                this.currentImage.Save(tmpfilepath, ImageFormat.Png);
                this.currentImage.Dispose();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error occured : " + e.ToString());

            }


            // もとのファイルに画像を保存
            try
            {
                var filepath = this.GetCurrentImageFilePath();
                var bitmap = new Bitmap(tmpfilepath);
                Debug.WriteLine("Save Current Image : " + tmpfilepath);
                bitmap.Save(filepath, ImageFormat.Png);
                bitmap.Dispose();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error occured : " + e.ToString());
            }

        }



        // 入力画像の処理を記述する
        public abstract void ProcessImages();

        protected Bitmap currentImage;
        private int numOfImage;
        protected int currentImageID;

        protected readonly string pathToWorkspace;
        protected readonly string imageworkSpaceName;
    }
}
