using System;
using System.Drawing;

namespace HandDrawn.Algorithm
{
    public static class Random
    {
        private static readonly System.Random s_random = new System.Random();

        private static int s_previousY = -1;

        public static void Draw(Graphics graphics, int width, int height)
        {
            for(int x = 0; x < width; x++)
            {
                int y = 0;

                if(s_previousY < 0)
                {
                    y = DrawTools.MaxDeviation;
                }
                else
                {
                    var randomMove = s_random.Next(-1, 2);

                    if(Math.Abs(DrawTools.MaxDeviation - (s_previousY + randomMove)) <= DrawTools.MaxDeviation)
                    {
                        y = s_previousY + randomMove;
                    }
                    else
                    {
                        y = s_previousY - randomMove;
                    }
                }

                graphics.Draw(x, y);

                s_previousY = y;
            }
        }
    }
}