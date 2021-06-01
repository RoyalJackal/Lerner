using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework
{
    public static class ChinesePostman
    {
        private static int _bestCost = int.MaxValue;
        private static List<int> _bestPath;

        public static void Execute()
        {
            var input = new List<Path>()
            {
                new Path(0, 1, 260),
                new Path(0, 2, 100),
                new Path(0, 4, 140),
                new Path(0, 7, 240),
                new Path(1, 2, 100),
                new Path(1, 3, 140),
                new Path(1, 4, 140),
                new Path(2, 4, 120),
                new Path(3, 4, 100),
                new Path(3, 5, 140),
                new Path(4, 6, 120),
                new Path(5, 6, 140),
                new Path(6, 7, 100)
            };

            var paths = new List<Path>();
            foreach (var path in input)
            {
                paths.Add(path);
                paths.Add(new Path(path.Second, path.First, path.Cost));
            }

            Recursive(0, new List<int>{0}, paths);

            Console.WriteLine(_bestCost);
            foreach (var item in _bestPath)
                Console.Write(item + " ");
        }

        private static void Recursive(int currCost, List<int> currPath, List<Path> paths)
        {
            if (currCost > _bestCost)
                return;

            if (currPath.Count == 8)
            {
                if (currCost < _bestCost)
                {
                    _bestCost = currCost;
                    _bestPath = currPath;
                }
                return;
            }

            foreach (var path in paths.Where(x => x.First == currPath[currPath.Count - 1]))
                if (!currPath.Contains(path.Second))
                    Recursive(currCost + path.Cost, new List<int>(currPath){path.Second}, paths);

            foreach (var path in paths.Where(x => x.Second == currPath[currPath.Count - 1]))
                if (!currPath.Contains(path.First))
                    Recursive(currCost + path.Cost, new List<int>(currPath){path.First}, paths);
        }
    }

    public class Path
    {
        public int First;
        public int Second;
        public int Cost;

        public Path(int first, int second, int cost)
        {
            First = first;
            Second = second;
            Cost = cost;
        }
    }
}
