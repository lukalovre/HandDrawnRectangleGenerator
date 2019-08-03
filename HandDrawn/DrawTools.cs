using System.Drawing;

namespace HandDrawn
{
    public static class DrawTools
    {

        public static readonly int MaxDeviation = 20;

        private static readonly Brush m_brush = new SolidBrush(Color.Black);

        private static readonly int m_brushSize = 2;

        public static void Draw(this Graphics graphics, int x, int y)
        {
            graphics.FillRectangle(m_brush, x, y, m_brushSize, m_brushSize);
        }
    }
}
