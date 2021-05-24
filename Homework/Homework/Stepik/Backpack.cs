using System;
using System.IO;
using System.Linq;

namespace Homework.Stepik
{
    public static class Backpack
    {
        private static int[,] _matrix;

        public static void Execute()
        {
            var capacity = int.Parse(File.ReadLines(@"C:\Users\dimao\Downloads\rucksack.in").First().Split(" ")[1]);

            var input = File.ReadLines(@"C:\Users\dimao\Downloads\rucksack.in")
                .Skip(1)
                .Select(x => x.Split(" "))
                .Select(x => new Tuple<int, int>(int.Parse(x[0]), int.Parse(x[1])))
                .ToList();

            _matrix = new int[input.Count + 1,capacity + 1];

            for (int i = 1; i <= input.Count; i++)
            {
                for (int j = 0; j <= capacity; j++)
                {
                    _matrix[i, j] = _matrix[i - 1, j];
                    if (j - input[i - 1].Item1 >= 0)
                    {
                        _matrix[i, j] = Math.Max(_matrix[i, j], _matrix[i - 1, j - input[i - 1].Item1] + input[i - 1].Item2);
                    }
                }
            }

            Console.WriteLine(_matrix[input.Count, capacity]);
        }

    }
}
