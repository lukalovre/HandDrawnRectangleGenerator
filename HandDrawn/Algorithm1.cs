using System.Drawing;

namespace HandDrawn
{
    public static class Algorithm1
    {
        public static void Draw(Graphics graphics, int width, int height)
        {
            for(int x = 0; x < width; x++)
            {
                var y = DrawTools.MaxDeviation;
                graphics.Draw(x, y);
            }
        }
    }
}
