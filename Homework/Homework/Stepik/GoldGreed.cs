using System;
using System.IO;
using System.Linq;

namespace Homework.Stepik
{
    public static class GoldGreed
    {
        public static void Execute()
        {
            var input = File.ReadLines(@"C:\Users\dimao\Downloads\gold4.in")
                .Skip(1)
                .First()
                .Split(" ")
                .Select(x => int.Parse(x))
                .OrderBy(x => x)
                .ToList();

            var first = 0;
            var second = 0;
            for (int i = 0; i < input.Count / 2; i++)
            {
                first += input[i];
                second += input[input.Count - 1 - i];
            }

            Console.WriteLine(second - first);
        }
    }
}
