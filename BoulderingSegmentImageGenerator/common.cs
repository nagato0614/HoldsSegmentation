using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace BoulderingSegmentImageGenerator
{

    public class Common
    {
        public static string GetExecutePath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        public void GenerateImageWithPNG(Bitmap b, string filename, string path)
        {
            string pngFileName = Path.ChangeExtension(filename, "png");
            b.Save(path + "\\" + pngFileName, System.Drawing.Imaging.ImageFormat.Png);
        }

        // 指定したサイズで画像の中心部分を切り取る(正方形のみ)
        public Bitmap TrimImage(Bitmap b, int size)
        {
            var centerX = b.Size.Width / 2;
            var centerY = b.Size.Height / 2;
            var imgRect = new Rectangle(centerX - 500,
                                        centerY - 500,
                                        centerX + 500,
                                        centerY + 500);

            var dst = new Bitmap(100, 100, b.PixelFormat);
            var trimmedImage = Graphics.FromImage(dst);
            return null;
        }
    }
}
