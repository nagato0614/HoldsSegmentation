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
    class SegmentImages : ImagesBase
    {
        public SegmentImages(string pathToWorkspace, string imageworkSpaceName)
            : base(pathToWorkspace, imageworkSpaceName)
        {
        }

        // すべてbackgroundになっているsegment画像を生成
        public override void ProcessImages()
        {
            Debug.WriteLine("SegmentImages ProcessImage");
            // もとの画像がある場所取得
            var parentFolder = Directory.GetParent(this.pathToWorkspace);
            Debug.WriteLine("read data from : " + parentFolder);

            string[] filess = Directory.GetFiles(parentFolder.FullName);
            for (int i = 0; i < filess.Length; i++)
			{
				// 生成する画像のファイル名
				var filename = $"{this.imageworkSpaceName}_{i}.png";

				// すでにファイルが存在する場合はスキップ
				if (File.Exists(Path.Combine(this.pathToWorkspace, this.imageworkSpaceName, filename)))
				{
					continue;
				}

				// 背景色に設定した画像を生成
				var img = new Bitmap(Params.ImgWidth, Params.ImgHeight);
                var g = Graphics.FromImage(img);
                g.Clear(Params.BackgroundColor);

                // 画像をsegmentのワークスペースに保存
                var filepath = Path.Combine(this.pathToWorkspace, this.imageworkSpaceName, filename);

                g.Dispose();

                // png画像として保存
                img.Save(filepath, ImageFormat.Png);
                Debug.WriteLine("generate image : " + filepath);
            }
        }
    }
}
