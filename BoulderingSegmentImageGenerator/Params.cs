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
        public const int ImgWidth = 1000;
        public const int ImgHeight = 1000;

        // セグメンテーションの色
        public static readonly Color BackgroundColor = Color.Black;
        public static readonly Color HoldColor = Color.Black;
        public static readonly Color VolumeColor = Color.Black;

    }
}