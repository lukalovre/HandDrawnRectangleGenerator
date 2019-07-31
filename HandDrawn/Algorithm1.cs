using System.Drawing;

namespace HandDrawn
{
    public static class Algorithm1
    {
        private static int maxDeviation = 30;

        private static readonly Brush s_brush = new SolidBrush(Color.Black);

        private static int s_brushSize = 2;


        public static void Draw(int width, int height)
        {
            using(Bitmap bitmap = new Bitmap(width, height + 2 * maxDeviation))
            {
                using(Graphics graphics = Graphics.FromImage(bitmap))
                {
                    for(int x = 0; x < width; x++)
                    {
                        graphics.FillRectangle(s_brush, x, maxDeviation, s_brushSize, s_brushSize);
                    }
                }

                IO.Save(bitmap);
            }
        }
    }
}
