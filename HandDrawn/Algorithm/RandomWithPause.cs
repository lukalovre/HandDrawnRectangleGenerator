using System;
using System.Collections.Generic;
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

            var lineTop = DrawLine(width, amount);
            var lineBottom = DrawLine(width, amount);
            var lineLeft = DrawLine(height, amount).ToVertical();
            var lineRight = DrawLine(height, amount).ToVertical();


            var rectangle = new List<Point>();

            rectangle.AddRange(lineTop);
            //rectangle.AddRange(lineBottom);
            //rectangle.AddRange(lineLeft);
            //rectangle.AddRange(lineRight);

            foreach(var point in rectangle)
            {
                graphics.Draw(point.X, point.Y);
            }
        }

        private static List<Point> ToVertical(this List<Point> pointList)
        {
            var verticalPointList = new List<Point>();

            foreach(var point in pointList)
            {
                verticalPointList.Add(new Point(point.Y, point.X));
            }

            return verticalPointList;

        }

        private static List<Point> DrawLine(int length, int pauseAmount)
        {
            var pointList = new List<Point>();
            int doMoveInterval = pauseAmount;
            int moveInterval = 0;
            s_previousY = -1;

            for(int x = 0; x < length; x++)
            {
                var maxDeviation = ModifyMaxDeviation(x, length);

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
                            return DrawLine(length, pauseAmount);
                        }
                    }

                    moveInterval++;
                }

                pointList.Add(new Point(x, y));

                s_previousY = y;
            }

            return pointList;
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