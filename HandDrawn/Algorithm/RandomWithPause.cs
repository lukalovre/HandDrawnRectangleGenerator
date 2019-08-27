using System;
using System.Drawing;

namespace HandDrawn.Algorithm
{
    public static class RandomWithPause
    {
        private static readonly System.Random s_random = new System.Random();

        private static int s_previousY = -1;

        public static void Draw(Graphics graphics, int width, int height, int amount)
        {
            graphics.Clear(Color.Transparent);

            DrawLine(graphics, width, height, amount);
        }

        private static void DrawLine(Graphics graphics, int width, int height, int amount)
        {
            int doMoveInterval = amount;
            int moveInterval = 0;
            s_previousY = -1;

            for(int x = 0; x < width; x++)
            {
                var maxDeviation = ModifyMaxDeviation(x, width);

                int y = 0;

                if(s_previousY < 0)
                {
                    y = maxDeviation / 2;
                }
                else
                {
                    var randomMove = s_random.Next(-1, 2);

                    if(moveInterval == doMoveInterval)
                    {
                        moveInterval = 0;
                    }
                    else
                    {
                        randomMove = 0;
                    }

                    if(Math.Abs(maxDeviation - (s_previousY + randomMove)) <= maxDeviation)
                    {
                        y = s_previousY + randomMove;
                    }
                    else if(Math.Abs(maxDeviation - (s_previousY - randomMove)) <= maxDeviation)
                    {
                        y = s_previousY - randomMove;
                    }
                    else
                    {
                        if(s_previousY > maxDeviation)
                        {
                            Draw(graphics, width, height, amount);
                            return;
                        }
                    }

                    moveInterval++;
                }

                graphics.Draw(x, y);

                s_previousY = y;
            }
        }

        private static float maxDeviationOffsetPercent = 0.1f;

        private static int ModifyMaxDeviation(int x, int width)
        {
            float percentOfLine = x / (float)width;

            if(percentOfLine <= maxDeviationOffsetPercent)
            {
                float offsetPercent = x / (float)(maxDeviationOffsetPercent * width);
                return (int)(DrawTools.MaxDeviation * offsetPercent);
            }

            if(percentOfLine >= maxDeviationOffsetPercent && percentOfLine < 1 - maxDeviationOffsetPercent)
            {
                return DrawTools.MaxDeviation;
            }

            if(percentOfLine >= 1 - maxDeviationOffsetPercent)
            {
                float offsetPercent = (width - x) / (float)(maxDeviationOffsetPercent * width);
                return (int)(DrawTools.MaxDeviation * offsetPercent);
            }



            return 0;
        }
    }
}