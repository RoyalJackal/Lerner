using System;
using System.IO;
using System.Linq;

namespace Homework.Stepik
{
    public static class Time
    {
        public static void Execute()
        {
            var input = File.ReadLines(@"C:\Users\dimao\Downloads\time.in")
                .Skip(1)
                .Select(x => x.Split(" "))
                .Select(x => new Tuple<int, int>(int.Parse(x[0]), int.Parse(x[1])))
                .ToList();

            var maxTime = input.Max(x => x.Item2) + 1;
            var matrix = new int[input.Count + 1, maxTime * 2];

            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < maxTime; j++)
                {
                    matrix[i + 1, j] = Math.Max(matrix[i + 1, j], matrix[i, j]);
                    if (input[i].Item2 > j)
                        matrix[i + 1, j + input[i].Item1] = Math.Max(matrix[i + 1, j + input[i].Item1], matrix[i, j] + 1);
                }
            }

            var result = 0;
            for (int i = 0; i < maxTime; i++)
                result = Math.Max(result, matrix[input.Count, i]);

            Console.WriteLine(result);
        }
    }
}
