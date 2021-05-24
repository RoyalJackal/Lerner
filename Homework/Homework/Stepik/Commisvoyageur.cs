using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Homework.Stepik
{
    public static class Commisvoyageur
    {
        private static int result = int.MaxValue;
        private static int[] path;
        private static int[] bestPath;
        private static bool[] used;

        public static void Execute()
        {
            var matrix = File.ReadLines(@"C:\Users\dimao\Downloads\salesman2.in")
                .Skip(1)
                .Select(x => x.Split(" ")
                    .Select(y => int.Parse(y))
                    .ToArray())
                .ToArray();
            path = new int[matrix.Length];
            bestPath = new int[matrix.Length];
            used = new bool[matrix.Length];

            Recursive(matrix, 1, 0);

            Console.WriteLine(result);
            foreach (var item in bestPath)
            {
                Console.Write(item + " ");
            }
        }

        private static void Recursive(int[][] matrix, int idx, int len)
        {
            if (len >= result)
                return;
            if (idx == matrix.Length)
            {
                if (len + matrix[path[idx - 1]][0] < result)
                {
                    result = len + matrix[path[idx - 1]][0];
                    for (int i = 0; i < path.Length; i++)
                        bestPath[i] = path[i];
                }
                return;
            }

            for (int i = 1; i < matrix.Length; i++)
            {
                if (used[i])
                    continue;
                path[idx] = i;
                used[i] = true;
                Recursive(matrix, idx + 1, len + matrix[path[idx - 1]][i]);
                used[i] = false;
            }
        }
    }
}
