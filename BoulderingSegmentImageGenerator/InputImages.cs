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

			string[] files = this.GetImageFiles();

			// 保存場所のファイルパスを生成
			var inputImagePath = Path.Combine(this.pathToWorkspace, this.imageworkSpaceName);

			var i = 0;
			// 画像をトリミングして input folder に移す
			foreach (string file in files)
			{
				// 保存するファイル名
				var filename = $"{this.imageworkSpaceName}_{i++}.png";

				// すでにファイルが存在する場合はスキップ
				if (File.Exists(Path.Combine(inputImagePath, filename)))
				{
					continue;
				}

				// 画像のパスを取得
				var imagePath = Path.Combine(parentFolder.FullName, file);

				using (Bitmap img = new Bitmap(imagePath))
				{
					// 画像の切り取り
					var resizedImage = Resize(img);

					// 画像の保存
					var filepath = Path.Combine(inputImagePath, filename);
					resizedImage.Save(filepath, ImageFormat.Png);
					resizedImage.Dispose();
					Debug.WriteLine("generate input Image : " + filepath);
				}


				System.GC.Collect();
			}
		}

		private Bitmap Resize(Bitmap src)
		{
			// 描画先のサイズを決める
			Bitmap dst = new Bitmap(Params.ImgWidth, Params.ImgHeight);

			using (Graphics g = Graphics.FromImage(dst))
			{
				// 補間方法として高品質双三次補間を指定する
				g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

				// 画像を縮小して描画する
				g.DrawImage(src, 0, 0, Params.ImgWidth, Params.ImgHeight);
			}

			// 画像リソースを解放する
			src.Dispose();

			return dst;
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