using System.Drawing;

namespace BoulderingSegmentImageGenerator
{
    class Params
    {
        // 作業フォルダ名
        public const string WorkSpaceFolderName = "workspace";
        public const string InputImageFolderName = "input";
        public const string SegmentImageFolderName = "segment";

        // 処理する画像サイズ
        public const int ImgWidth = 500;
        public const int ImgHeight = 500;

        // セグメンテーションの色
        public static readonly Color BackgroundColor = Color.Red;
        public static readonly Color HoldColor = Color.Green;
        public static readonly Color VolumeColor = Color.Blue;
		public static readonly Color Human = Color.Yellow;
		public static readonly Color Mat = Color.PaleGreen;
    }

    public enum HoldsType_t
    {
        Holds,
        Volume,
        Background,
		Human,
		Mat,
    }

    public enum PaintSize_t
    {
        pt_1 = 1,
        pt_3 = 3,
        pt_5 = 5,
        pt_10 = 10,
    }
}