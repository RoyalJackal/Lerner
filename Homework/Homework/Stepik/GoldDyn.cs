using System;
using System.IO;
using System.Linq;

namespace Homework.Stepik
{
    public static class GoldDyn
    {
        private static int[,] _matrix;

        public static void Execute()
        {
            var input = File.ReadLines(@"C:\Users\dimao\Downloads\gold2.in")
                .Skip(1)
                .First()
                .Split(" ")
                .Select(x => int.Parse(x))
                .ToList();

            var capacity = input.Sum() / 2;

            _matrix = new int[input.Count + 1,capacity + 1];

            for (int i = 1; i <= input.Count; i++)
            {
                for (int j = 0; j <= capacity; j++)
                {
                    _matrix[i, j] = _matrix[i - 1, j];
                    if (j - input[i - 1] >= 0)
                    {
                        _matrix[i, j] = Math.Max(_matrix[i, j], _matrix[i - 1, j - input[i - 1]] + input[i - 1]);
                    }
                }
            }

            var result = _matrix[input.Count, capacity];
            var rest = input.Sum() - result;
            Console.WriteLine(Math.Abs(result - rest));
        }
    }
}
