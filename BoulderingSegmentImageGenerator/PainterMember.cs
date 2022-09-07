using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderingSegmentImageGenerator
{
    public partial class Painter
    {
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
