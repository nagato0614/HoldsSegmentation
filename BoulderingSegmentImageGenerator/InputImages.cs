using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace BoulderingSegmentImageGenerator
{
    public class InputImages : ImagesBase
    {
        public InputImages(string pathToWorkspace, string imageworkSpaceName) 
            : base(pathToWorkspace, imageworkSpaceName)
        {
        }

        // 切り取った画像を生成する.
        public override void ProcessImages()
        {
            Debug.WriteLine("InputImages ProcessImage");
            var parentFolder = Directory.GetParent(this.pathToWorkspace);
            Debug.WriteLine("read data from : " + parentFolder);

            string[] filess = Directory.GetFiles(parentFolder.FullName);

            // 保存場所のファイルパスを生成
            var inputImagePath = Path.Combine(this.pathToWorkspace, this.imageworkSpaceName);

            var i = 0;
            // 画像をトリミングして input folder に移す
            foreach (string file in filess)
            {
                // 画像のパスを取得
                var imagePath = Path.Combine(parentFolder.FullName, file);
                var image = Image.FromFile(imagePath);
                var bitmap = new Bitmap(image);

                // 画像の切り取り
                var trimmedimage = Trimming(bitmap);

                // 画像の保存
                var filename = $"{this.imageworkSpaceName}_{i++}.png";
                var filepath = Path.Combine(inputImagePath, filename);
                trimmedimage.Save(filepath, ImageFormat.Png);
                trimmedimage.Dispose();
                Debug.WriteLine("generate input Image : " + filepath);
            }
        }

        private Bitmap Trimming(Bitmap src)
        {
            // 描画先のオブジェクトを生成
            Bitmap dst = new Bitmap(Params.ImgWidth, Params.ImgHeight);

            using (Graphics g = Graphics.FromImage(dst))
            {

                // 描画位置を指定
                var desRect = new Rectangle(0, 0, Params.ImgWidth, Params.ImgHeight);

                // 切り取り位置を指定
                var height = src.Height;
                var width = src.Width;
                var half_width = Params.ImgWidth / 2;
                var half_height = Params.ImgHeight / 2;
                var srcRect = new Rectangle((width / 2) - half_width,
                                              (height / 2) - half_height,
                                              (width / 2) + half_width,
                                              (height / 2) + half_height);

                g.DrawImage(src, desRect, srcRect, GraphicsUnit.Pixel);
            }

            return dst;
        }
    }
}
