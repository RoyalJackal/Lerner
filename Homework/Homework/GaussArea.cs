using System;
using System.Collections.Generic;

namespace Homework
{
    public static class GaussArea
    {
        public static void Execute()
        {
            var input = new List<Point>
            {
                new Point(3, 4),
                new Point(5, 11),
                new Point(12, 8),
                new Point(9, 5),
                new Point(5, 6)
            };

            double positive = 0;
            for (int i = 0; i < input.Count; i++)
            {
                if (i == input.Count - 1)
                    positive += input[i].X * input[0].Y;
                else
                    positive += input[i].X * input[i + 1].Y;
            }

            double negative = 0;
            for (int i = 0; i < input.Count; i++)
            {
                if (i == input.Count - 1)
                    negative += input[i].Y * input[0].X;
                else
                    negative += input[i].Y * input[i + 1].X;
            }

            var result = Math.Abs(positive - negative) / 2;

            Console.WriteLine(result);
        }
    }

    public class Point
    {
        public double X;
        public double Y;

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
