using System.Drawing;

namespace HandDrawn
{
    public static class Algorithm1
    {
        public static void Draw(int width, int height)
        {
            using(Bitmap bitmap = new Bitmap(width, height + 2 * DrawTools.MaxDeviation))
            {
                using(Graphics graphics = Graphics.FromImage(bitmap))
                {
                    for(int x = 0; x < width; x++)
                    {
                        graphics.FillRectangle(DrawTools.Brush, x, DrawTools.MaxDeviation, DrawTools.BrushSize, DrawTools.BrushSize);
                    }
                }

                IO.Save(bitmap);
            }
        }
    }
}
