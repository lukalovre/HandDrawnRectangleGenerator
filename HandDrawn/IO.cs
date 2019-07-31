using System.Drawing;
using System.Drawing.Imaging;

namespace HandDrawn
{
    public static class IO
    {
        internal static readonly string FileName = "Result.png";

        public static void Save(Bitmap bitmap)
        {
            bitmap.Save(FileName, ImageFormat.Png);
        }
    }
}
