using System.Drawing;
using System.Drawing.Imaging;

namespace HandDrawn
{
    public static class IO
    {
        public static void Save(Bitmap bitmap,string fileName)
        {
            bitmap.Save(fileName, ImageFormat.Png);
        }
    }
}
