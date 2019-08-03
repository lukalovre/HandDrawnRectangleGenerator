using System.Drawing;

namespace HandDrawn
{
    public static class DrawTools
    {

        public static int MaxDeviation = 30;

        public static readonly Brush Brush = new SolidBrush(Color.Black);

        public static readonly int BrushSize = 2;

        public static void Draw(this Graphics graphics, int x, int y)
        {
            graphics.FillRectangle(Brush, x, y, BrushSize, BrushSize);
        }
    }
}
