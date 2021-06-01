using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;

namespace Homework
{
    public static class Intersection
    {
        public static void Execute()
        {
            var input = new List<(Point, Point)>();
            var lines = input
                .Select(points => points.Item1.X > points.Item2.X ? (points.Item2, points.Item1) : (points.Item1, points.Item2))
                .OrderBy(points => points.Item1.X)
                .ToList();
            var currLines = new List<(Point, Point)>();
            var max = Math.Max(lines.Max(x => x.Item1.X), lines.Max(x => x.Item2.X));
            var min = Math.Min(lines.Min(x => x.Item1.X), lines.Min(x => x.Item2.X));

            var foundY = new Dictionary<double, int>();
            for (double x = min; x <= max; x++)
            {
                foundY.Clear();
                currLines = currLines
                    .Where(coords => !(coords.Item2.X < x))
                    .ToList();
                currLines = currLines.Concat(lines.Where(coords => coords.Item1.X == x)).ToList();

                foreach (var line in currLines)
                {
                    if (line.Item1.X == line.Item2.X)
                        if (line.Item1.Y > line.Item2.Y)
                            for (double y = line.Item2.Y; y <= line.Item1.Y; y++)
                            {
                                if (!foundY.ContainsKey(y))
                                    foundY.Add(y, 0);
                                foundY[y]++;
                            }
                        else
                            for (double y = line.Item1.Y; y <= line.Item2.Y; y++)
                            {
                                if (!foundY.ContainsKey(y))
                                    foundY.Add(y, 0);
                                foundY[y]++;
                            }
                    else
                    {
                        var y = GetY(line, x);
                        if (!foundY.ContainsKey(y))
                            foundY.Add(y, 0);
                        foundY[y]++;
                    }
                }

                if (foundY.Any(y => y.Value > 1))
                {
                    Console.WriteLine($"x = {x}, y = {foundY.First(y => y.Value > 1).Key}");
                }
            }
        }

        private static double GetY((Point, Point) coords, double x) =>
            coords.Item1.Y + (coords.Item2.Y - coords.Item1.Y) * (x -  coords.Item1.X) / (coords.Item2.X - coords.Item1.X);

    }
}
