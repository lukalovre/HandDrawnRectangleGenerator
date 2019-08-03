using System.Drawing;

namespace HandDrawn.Algorithm
{
    public static class Random
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