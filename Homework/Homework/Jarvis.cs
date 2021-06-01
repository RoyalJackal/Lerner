using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace Homework
{
    public static class Jarvis
    {
        public static void Execute()
        {
            var points = new List<Point>()
            {
                new Point(200,200),
                new Point(300,100),
                new Point(200,50),
                new Point(100,100),
                new Point(200, 100),
                new Point(300, 200),
                new Point(250, 100),
            };

            var result = new List<Point>();

            var currPoint = points.Where(p => p.X == points.Min(min => min.X)).First();

            Point nextPoint;
            do
            {
                result.Add(currPoint);
                nextPoint = points[0];

                for (int i = 1; i < points.Count; i++)
                {
                    if ((currPoint == nextPoint)
                        || (Orientation(currPoint, nextPoint, points[i]) == -1))
                    {
                        nextPoint = points[i];
                    }
                }

                currPoint = nextPoint;

            }
            while (nextPoint != result[0]);

            foreach (var point in result)
            {
                Console.WriteLine($"x = {point.X}, y = {point.Y}");
            }
        }

        private static int Orientation(Point currPoint, Point nextPoint, Point newPoint)
        {
            var orientation = (nextPoint.X - currPoint.X) * (newPoint.Y - currPoint.Y) - (newPoint.X - currPoint.X) * (nextPoint.Y - currPoint.Y);

            if (orientation > 0)
                return -1;
            if (orientation < 0)
                return 1;

            return 0;
        }
    }
}
